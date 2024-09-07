using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneAPiano.Migrations
{
    public partial class SCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
