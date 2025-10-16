using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tekever_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TvShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShows", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JwtId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRevoked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AddedtAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TvShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TvShowActors",
                columns: table => new
                {
                    TvShowId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowActors", x => new { x.TvShowId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_TvShowActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowActors_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TvShowGenres",
                columns: table => new
                {
                    TvShowId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowGenres", x => new { x.TvShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TvShowGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowGenres_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TvShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.TvShowId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeasonEpisodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AirDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonEpisodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonEpisodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, null, "Cillian Murphy" },
                    { 2, null, "Bryan Cranston" },
                    { 3, null, "Jennifer Aniston" },
                    { 4, null, "Pedro Pascal" },
                    { 5, null, "Millie Bobby Brown" },
                    { 6, null, "Henry Cavill" },
                    { 7, null, "Emma D'Arcy" },
                    { 8, null, "Tom Hiddleston" },
                    { 9, null, "Anya Taylor-Joy" },
                    { 10, null, "Matthew McConaughey" },
                    { 11, null, "Zendaya" },
                    { 12, null, "Rami Malek" },
                    { 13, null, "Elizabeth Olsen" },
                    { 14, null, "Kit Harington" },
                    { 15, null, "Oscar Isaac" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Comedy" },
                    { 3, "Action" },
                    { 4, "Sci-Fi" },
                    { 5, "Thriller" },
                    { 6, "Fantasy" },
                    { 7, "Crime" },
                    { 8, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "TvShows",
                columns: new[] { "Id", "Description", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "British crime drama", 9.0999999999999996, new DateTime(2013, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peaky Blinders" },
                    { 2, "Chemistry teacher turns to crime", 9.5, new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breaking Bad" },
                    { 3, "Six friends navigate life in NYC", 8.9000000000000004, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friends" },
                    { 4, "Star Wars bounty hunter saga", 8.6999999999999993, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Mandalorian" },
                    { 5, "A monster hunter struggles with his destiny", 8.1999999999999993, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher" },
                    { 6, "Noble families vie for control of Westeros", 9.3000000000000007, new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game of Thrones" },
                    { 7, "A group of kids uncover supernatural mysteries", 8.9000000000000004, new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stranger Things" },
                    { 8, "God of Mischief faces the TVA", 8.4000000000000004, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loki" },
                    { 9, "Chess prodigy battles addiction and rivals", 8.5999999999999996, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Queen’s Gambit" },
                    { 10, "Targaryen civil war begins", 8.8000000000000007, new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "House of the Dragon" },
                    { 11, "Hacker tries to take down corporate America", 8.5999999999999996, new DateTime(2015, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Robot" },
                    { 12, "Teens navigate love and addiction", 8.4000000000000004, new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Euphoria" },
                    { 13, "A group of vigilantes fight corrupt superheroes", 8.9000000000000004, new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Boys" },
                    { 14, "Superhero sitcom blending reality and fantasy", 8.0, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WandaVision" },
                    { 15, "Detectives uncover dark truths", 9.0, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "True Detective" },
                    { 16, "A lawyer's descent into moral ambiguity", 8.9000000000000004, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Better Call Saul" },
                    { 17, "The story of Pablo Escobar and the DEA", 8.8000000000000007, new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Narcos" },
                    { 18, "A sci-fi political thriller set in space", 8.5, new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Expanse" },
                    { 19, "Survivors navigate a post-apocalyptic world", 9.1999999999999993, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us" },
                    { 20, "Modern adaptation of Sherlock Holmes", 9.0999999999999996, new DateTime(2010, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sherlock" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "ReleaseDate", "SeasonNumber", "TvShowId" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2014, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, new DateTime(2009, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 5, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 6, new DateTime(1995, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 7, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 8, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 9, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 10, new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 11, new DateTime(2012, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 12, new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 13, new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 14, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 15, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 16, new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 17, new DateTime(2015, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 18, new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12 },
                    { 19, new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13 },
                    { 20, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14 },
                    { 21, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15 },
                    { 22, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 16 },
                    { 23, new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 17 },
                    { 24, new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 18 },
                    { 25, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 19 },
                    { 26, new DateTime(2010, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20 },
                    { 27, new DateTime(2011, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20 }
                });

            migrationBuilder.InsertData(
                table: "TvShowActors",
                columns: new[] { "ActorId", "TvShowId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 14, 1 },
                    { 2, 2 },
                    { 12, 2 },
                    { 3, 3 },
                    { 13, 3 },
                    { 4, 4 },
                    { 8, 4 },
                    { 6, 5 },
                    { 9, 5 },
                    { 6, 6 },
                    { 14, 6 },
                    { 5, 7 },
                    { 11, 7 },
                    { 8, 8 },
                    { 15, 8 },
                    { 9, 9 },
                    { 10, 9 },
                    { 7, 10 },
                    { 14, 10 },
                    { 12, 11 },
                    { 3, 12 },
                    { 11, 12 },
                    { 2, 13 },
                    { 15, 13 },
                    { 13, 14 },
                    { 10, 15 },
                    { 2, 16 },
                    { 15, 17 },
                    { 15, 18 },
                    { 4, 19 },
                    { 5, 19 },
                    { 1, 20 },
                    { 10, 20 }
                });

            migrationBuilder.InsertData(
                table: "TvShowGenres",
                columns: new[] { "GenreId", "TvShowId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 7, 2 },
                    { 2, 3 },
                    { 8, 3 },
                    { 4, 4 },
                    { 8, 4 },
                    { 3, 5 },
                    { 6, 5 },
                    { 5, 6 },
                    { 6, 6 },
                    { 1, 7 },
                    { 4, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 1, 9 },
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 10 },
                    { 1, 11 },
                    { 5, 11 },
                    { 1, 12 },
                    { 3, 13 },
                    { 5, 13 },
                    { 2, 14 },
                    { 4, 14 },
                    { 1, 15 },
                    { 7, 15 },
                    { 1, 16 },
                    { 7, 16 },
                    { 1, 17 },
                    { 7, 17 },
                    { 4, 18 },
                    { 8, 18 },
                    { 1, 19 },
                    { 8, 19 },
                    { 5, 20 },
                    { 7, 20 }
                });

            migrationBuilder.InsertData(
                table: "SeasonEpisodes",
                columns: new[] { "Id", "AirDate", "EpisodeNumber", "Rating", "SeasonId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.5999999999999996, 1, "Episode 1" },
                    { 2, new DateTime(2013, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.6999999999999993, 1, "Episode 2" },
                    { 3, new DateTime(2014, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.9000000000000004, 2, "Episode 1" },
                    { 4, new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9.0, 3, "Pilot" },
                    { 5, new DateTime(2008, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.6999999999999993, 3, "Cat's in the Bag..." },
                    { 6, new DateTime(2009, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9.0999999999999996, 4, "Season 2 Premiere" },
                    { 7, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.3000000000000007, 5, "The One Where It All Began" },
                    { 8, new DateTime(1994, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.4000000000000004, 5, "The One with the Sonogram" },
                    { 9, new DateTime(1995, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.5, 6, "Season 2 Premiere" },
                    { 10, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.9000000000000004, 7, "Chapter 1: The Mandalorian" },
                    { 11, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.8000000000000007, 7, "Chapter 2: The Child" },
                    { 12, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.1999999999999993, 8, "Episode 1" },
                    { 13, new DateTime(2019, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.4000000000000004, 8, "Episode 2" },
                    { 14, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.5, 9, "Episode 1" },
                    { 15, new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9.0, 10, "Episode 1" },
                    { 16, new DateTime(2011, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.9000000000000004, 10, "Episode 2" },
                    { 17, new DateTime(2012, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9.0999999999999996, 11, "Episode 1" },
                    { 18, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.4000000000000004, 12, "Episode 1" },
                    { 19, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.5999999999999996, 12, "Episode 2" },
                    { 20, new DateTime(2021, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8.5, 12, "Episode 3" },
                    { 21, new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.7999999999999998, 13, "Episode 1" },
                    { 22, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7.9000000000000004, 13, "Episode 2" },
                    { 23, new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0, 14, "Episode 1" },
                    { 24, new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.1999999999999993, 14, "Episode 2" },
                    { 25, new DateTime(2022, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8.0999999999999996, 14, "Episode 3" },
                    { 26, new DateTime(2015, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.3000000000000007, 15, "Episode 1" },
                    { 27, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.1999999999999993, 15, "Episode 2" },
                    { 28, new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.5, 16, "Episode 1" },
                    { 29, new DateTime(2019, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.5999999999999996, 16, "Episode 2" },
                    { 30, new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.9000000000000004, 17, "Episode 1" },
                    { 31, new DateTime(2019, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.0, 17, "Episode 2" },
                    { 32, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0999999999999996, 18, "Episode 1" },
                    { 33, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.1999999999999993, 18, "Episode 2" },
                    { 34, new DateTime(2014, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0, 19, "Episode 1" },
                    { 35, new DateTime(2014, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8.0999999999999996, 19, "Episode 2" },
                    { 36, new DateTime(2015, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.9000000000000004, 20, "Episode 1" },
                    { 37, new DateTime(2015, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.3000000000000007, 21, "Episode 1" },
                    { 38, new DateTime(2015, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.1999999999999993, 22, "Episode 1" },
                    { 39, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.4000000000000004, 23, "Episode 1" },
                    { 40, new DateTime(2010, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7.7999999999999998, 24, "Episode 1" },
                    { 41, new DateTime(2010, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7.9000000000000004, 24, "Episode 2" },
                    { 42, new DateTime(2011, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.0, 25, "Episode 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonEpisodes_SeasonId",
                table: "SeasonEpisodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvShowId",
                table: "Seasons",
                column: "TvShowId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowActors_ActorId",
                table: "TvShowActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowGenres_GenreId",
                table: "TvShowGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_TvShowId",
                table: "UserFavorites",
                column: "TvShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SeasonEpisodes");

            migrationBuilder.DropTable(
                name: "TvShowActors");

            migrationBuilder.DropTable(
                name: "TvShowGenres");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TvShows");
        }
    }
}
