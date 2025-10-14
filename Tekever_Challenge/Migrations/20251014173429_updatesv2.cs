using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tekever_Challenge.Migrations
{
    /// <inheritdoc />
    public partial class updatesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TvShowActors",
                columns: new[] { "ActorId", "TvShowId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 2, 3 },
                    { 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TvShowActors",
                keyColumns: new[] { "ActorId", "TvShowId" },
                keyValues: new object[] { 3, 4 });
        }
    }
}
