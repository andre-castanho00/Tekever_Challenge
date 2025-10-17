using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Tekever_Challenge.Data;
using Tekever_Challenge.Data.ViewModels.Auth;
using Tekever_Challenge.EmailService;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        private readonly IEmailSender _emailSender;

        public AuthController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            DatabaseContext context,
            IConfiguration configuration,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="data">The registration details including email, username, and password.</param>
        /// <returns>
        /// 201 Created if the user is created successfully,
        /// 400 Bad Request if the user already exists or validation fails.
        /// </returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterView data)
        {
            var userExists = await _userManager.FindByEmailAsync(data.Email);

            if (userExists != null)
            {
                return BadRequest($"User {data.Email} already exists");
            }

            User newUser = new User()
            {
                Email = data.Email,
                UserName = data.Username,
                SecurityStamp = Guid.NewGuid().ToString(), // extra security
            };

            var result = await _userManager.CreateAsync(newUser, data.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "User could not be created.", errors });
            }


            return Created(nameof(Register), $"User {data.Email} created");
        }

        /// <summary>
        /// Sends an email to the specified user containing TV show recommendations
        /// based on the genres of their favorite shows.
        /// </summary>
        /// <param name="email">The email address of the recipient.</param>
        /// <param name="userId">The ID of the user for whom recommendations are generated.</param>
        /// <returns>
        /// 200 OK if the email was sent successfully.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendEmailRecommendations(string email, string userId)
        {
            var subject = "TvShow Recommendations";

            var favoriteGenreIds = _context.UserFavorites
                .Where(f => f.UserId == userId)
                .Include(f => f.TvShow)
                    .ThenInclude(t => t.TvShowGenres)
                .SelectMany(f => f.TvShow.TvShowGenres.Select(tg => tg.GenreId))
                .Distinct()
                .ToList();

            var recommendedShows = _context.TvShows
                .Include(t => t.TvShowGenres)
                    .ThenInclude(tg => tg.Genre)
                .Where(t => t.TvShowGenres.Any(tg => favoriteGenreIds.Contains(tg.GenreId)))
                .Select(t => new
                {
                    t.Title
                })
                .ToList();

            if (!recommendedShows.Any())
            {
                return Ok(new { message = "No recommendations available to send." });
            }

            string message = "Here is the list of shows we think you might enjoy:\n\n";
            foreach (var show in recommendedShows)
            {
                message += "- " + show.Title + "\n";
            }

            await _emailSender.SendEmailAsync(email, subject, message);

            return Ok(new { message = "Recommendations sent successfully." });
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token along with a refresh token.
        /// </summary>
        /// <param name="data">The login credentials including email and password.</param>
        /// <returns>
        /// 200 OK with JWT and refresh token if authentication succeeds,
        /// 401 Unauthorized if credentials are invalid.
        /// </returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginView data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, data.Password))
            {
                var jwtToken = await GenerateToken(user);

                // Calls the method without awaiting it, so the login response is returned immediately.
                _ = SendEmailRecommendations(data.Email, user.Id);

                return Ok(jwtToken);
            }

            return Unauthorized();
        }

        /// <summary>
        /// Generates a JWT token and a refresh token for the authenticated user.
        /// </summary>
        /// <param name="user">The authenticated user object.</param>
        /// <returns>An AuthResultView containing the JWT token, refresh token, and expiration time.</returns>
        private async Task<AuthResultView> GenerateToken(User user)
        {
            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token); // Serializes the JwtSecurityToken into compact serialization format

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsRevoked = false,
                UserId = user.Id,
                AddedtAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddMonths(6),
                Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString(),
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            var res = new AuthResultView()
            {
                Token = jwt,
                RefreshToken = refreshToken.Token,
                ExpiresAt = token.ValidTo
            };

            return res;
        }
    }
}
