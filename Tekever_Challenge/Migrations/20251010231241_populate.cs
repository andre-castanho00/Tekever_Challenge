using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tekever_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class populate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "TvShows",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, null, "John Carter" },
                    { 2, null, "Emma Wilson" },
                    { 3, null, "Carlos Vega" },
                    { 4, null, "Mia Chen" },
                    { 5, null, "Tom Novak" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 101, "Drama" },
                    { 102, "Comedy" },
                    { 103, "Action" },
                    { 104, "Sci-Fi" },
                    { 105, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "TvShows",
                columns: new[] { "Id", "Description", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 2001, null, 9.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peaky Blinders" },
                    { 2002, null, 8.8000000000000007, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suits" },
                    { 2003, null, 5.2000000000000002, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friends" },
                    { 2004, null, 9.5, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern Family" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "EpisodeNumber", "ReleaseDate", "SeasonNumber", "Title", "TvShowId" },
                values: new object[,]
                {
                    { 30001, 0, new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Peaky Blinders - Episode 1", 2001 },
                    { 30002, 0, new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Peaky Blinders - Episode 2", 2001 },
                    { 30003, 0, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Peaky Blinders - Episode 3", 2001 },
                    { 30004, 0, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Peaky Blinders - Episode 4", 2001 },
                    { 30005, 0, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Peaky Blinders - Episode 5", 2001 },
                    { 30006, 0, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Suits - Episode 1", 2002 },
                    { 30007, 0, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Suits - Episode 2", 2002 },
                    { 30008, 0, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Suits - Episode 3", 2002 },
                    { 30009, 0, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Suits - Episode 4", 2002 },
                    { 30010, 0, new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Friends - Episode 1", 2003 },
                    { 30011, 0, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Friends - Episode 2", 2003 },
                    { 30012, 0, new DateTime(2021, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Friends - Episode 3", 2003 },
                    { 30013, 0, new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Friends - Episode 4", 2003 },
                    { 30014, 0, new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Friends - Episode 5", 2003 },
                    { 30015, 0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Modern Family - Episode 1", 2004 },
                    { 30016, 0, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Modern Family - Episode 2", 2004 },
                    { 30017, 0, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Modern Family - Episode 3", 2004 }
                });

            migrationBuilder.InsertData(
                table: "TvShowActors",
                columns: new[] { "ActorId", "TvShowId" },
                values: new object[,]
                {
                    { 1, 2001 },
                    { 5, 2001 },
                    { 1, 2002 },
                    { 5, 2002 },
                    { 1, 2003 },
                    { 2, 2003 },
                    { 5, 2003 },
                    { 2, 2004 },
                    { 3, 2004 },
                    { 5, 2004 }
                });

            migrationBuilder.InsertData(
                table: "TvShowGenres",
                columns: new[] { "GenreId", "TvShowId" },
                values: new object[,]
                {
                    { 105, 2001 },
                    { 103, 2002 },
                    { 105, 2003 },
                    { 103, 2004 },
                    { 105, 2004 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30001);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30002);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30003);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30004);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30005);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30006);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30007);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30008);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30009);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30010);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30011);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30012);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30013);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30014);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30015);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30016);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 30017);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 1, 2001 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 5, 2001 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 1, 2002 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 5, 2002 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 1, 2003 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 2, 2003 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 5, 2003 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 2, 2004 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 3, 2004 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 5, 2004 });

            migrationBuilder.DeleteData(
                table: "TvShowGenres",
                keyColumns: new[] { "GenreId", "TvShowId" },
                keyValues: new object[] { 105, 2001 });

            migrationBuilder.DeleteData(
                table: "TvShowGenres",
                keyColumns: new[] { "GenreId", "TvShowId" },
                keyValues: new object[] { 103, 2002 });

            migrationBuilder.DeleteData(
                table: "TvShowGenres",
                keyColumns: new[] { "GenreId", "TvShowId" },
                keyValues: new object[] { 105, 2003 });

            migrationBuilder.DeleteData(
                table: "TvShowGenres",
                keyColumns: new[] { "GenreId", "TvShowId" },
                keyValues: new object[] { 103, 2004 });

            migrationBuilder.DeleteData(
                table: "TvShowGenres",
                keyColumns: new[] { "GenreId", "TvShowId" },
                keyValues: new object[] { 105, 2004 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "TvShows",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Comedy" },
                    { 3, "Action" },
                    { 4, "Sci-Fi" },
                    { 5, "Fantasy" }
                });
        }
    }
}
