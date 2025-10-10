using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Tekever_Challenge.Data;
using Tekever_Challenge.Data.ViewModels.Auth;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            DatabaseContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginView data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if(user != null && await _userManager.CheckPasswordAsync(user, data.Password))
            {
                var jwtToken = await GenerateToken(user);

                return Ok(jwtToken);
            }

            return Unauthorized();
        }

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
