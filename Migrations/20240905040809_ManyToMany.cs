using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneAPiano.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GenreId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "SingId",
                table: "SongsGenres",
                newName: "SongId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 4, "Impressionist" },
                    { 5, "Modern" }
                });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GenreId", "SongId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GenreId", "SongId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GenreId", "SongId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GenreId", "SongId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "SongsGenres",
                columns: new[] { "Id", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 6, 2, 3 },
                    { 7, 1, 4 },
                    { 8, 2, 4 },
                    { 9, 3, 4 },
                    { 10, 1, 5 },
                    { 11, 2, 5 },
                    { 12, 1, 6 },
                    { 13, 2, 6 },
                    { 14, 3, 7 },
                    { 16, 3, 8 },
                    { 22, 1, 11 },
                    { 23, 2, 11 },
                    { 24, 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "SongsGenres",
                columns: new[] { "Id", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 15, 4, 7 },
                    { 17, 4, 8 },
                    { 18, 4, 9 },
                    { 19, 5, 9 },
                    { 20, 4, 10 },
                    { 21, 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Genres_GenreId",
                table: "SongsGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Genres_GenreId",
                table: "SongsGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres");

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "SongsGenres",
                newName: "SingId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Songs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GenreId", "SingId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GenreId", "SingId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GenreId", "SingId" },
                values: new object[] { 3, 7 });

            migrationBuilder.UpdateData(
                table: "SongsGenres",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GenreId", "SingId" },
                values: new object[] { 2, 9 });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
