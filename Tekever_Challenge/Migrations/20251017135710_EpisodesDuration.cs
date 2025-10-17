using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tekever_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class EpisodesDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "SeasonEpisodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 52);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 53);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 68);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 35);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 51);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 60);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration",
                value: 48);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 42);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration",
                value: 51);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 43);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Duration",
                value: 37);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration",
                value: 42);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Duration",
                value: 41);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Duration",
                value: 52);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Duration",
                value: 45);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Duration",
                value: 60);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Duration",
                value: 39);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Duration",
                value: 52);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Duration",
                value: 51);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Duration",
                value: 37);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 21,
                column: "Duration",
                value: 57);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 22,
                column: "Duration",
                value: 42);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 23,
                column: "Duration",
                value: 59);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 24,
                column: "Duration",
                value: 70);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 25,
                column: "Duration",
                value: 70);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 26,
                column: "Duration",
                value: 35);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 27,
                column: "Duration",
                value: 40);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 28,
                column: "Duration",
                value: 44);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 29,
                column: "Duration",
                value: 53);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 30,
                column: "Duration",
                value: 58);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 31,
                column: "Duration",
                value: 53);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 32,
                column: "Duration",
                value: 68);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 33,
                column: "Duration",
                value: 65);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 34,
                column: "Duration",
                value: 51);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 35,
                column: "Duration",
                value: 49);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 36,
                column: "Duration",
                value: 54);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 37,
                column: "Duration",
                value: 68);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 38,
                column: "Duration",
                value: 50);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 39,
                column: "Duration",
                value: 45);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 40,
                column: "Duration",
                value: 47);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 41,
                column: "Duration",
                value: 53);

            migrationBuilder.UpdateData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 42,
                column: "Duration",
                value: 52);

            migrationBuilder.InsertData(
                table: "SeasonEpisodes",
                columns: new[] { "Id", "AirDate", "Duration", "EpisodeNumber", "Rating", "SeasonId", "Title" },
                values: new object[,]
                {
                    { 43, new DateTime(2011, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 1, 5.0, 26, "Episode 1" },
                    { 44, new DateTime(2011, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2, 6.2000000000000002, 26, "Episode 2" },
                    { 45, new DateTime(2012, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 1, 7.7999999999999998, 27, "Episode 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SeasonEpisodes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "SeasonEpisodes");
        }
    }
}
