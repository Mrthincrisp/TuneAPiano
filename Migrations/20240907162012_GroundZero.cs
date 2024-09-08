using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TuneAPiano.Migrations
{
    public partial class GroundZero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    Album = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SongsGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongsGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongsGenres_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 56, "A German composer and pianist, a crucial figure in the transition between the classical and romantic eras in classical music.", "Ludwig van Beethoven" },
                    { 2, 35, "A prolific and influential composer of the classical era, born in Salzburg.", "Wolfgang Amadeus Mozart" },
                    { 3, 39, "A Polish composer and virtuoso pianist of the Romantic era, known for his solo piano compositions.", "Frederic Chopin" },
                    { 4, 65, "A German composer and musician of the Baroque period, known for instrumental compositions such as the Brandenburg Concertos.", "Johann Sebastian Bach" },
                    { 5, 55, "A French composer, a prominent figure in the impressionist music movement.", "Claude Debussy" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Classical" },
                    { 2, "Romantic" },
                    { 3, "Baroque" },
                    { 4, "Impressionist" },
                    { 5, "Modern" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Beethoven: Symphonies", 1, 425, "Symphony No. 5" },
                    { 2, "Beethoven: Piano Sonatas", 1, 900, "Moonlight Sonata" },
                    { 3, "Mozart: Serenades", 2, 360, "Eine kleine Nachtmusik" },
                    { 4, "Mozart: Requiem", 2, 1800, "Requiem" },
                    { 5, "Chopin: Nocturnes", 3, 290, "Nocturne in E-flat Major" },
                    { 6, "Chopin: Preludes", 3, 270, "Prelude in D-flat Major" },
                    { 7, "Bach: Organ Works", 4, 540, "Toccata and Fugue in D minor" },
                    { 8, "Bach: Brandenburg Concertos", 4, 1190, "Brandenburg Concerto No. 3" },
                    { 9, "Debussy: Suite bergamasque", 5, 300, "Clair de Lune" },
                    { 10, "Debussy: Orchestral Works", 5, 1200, "La Mer" },
                    { 11, "Beethoven: Symphonies", 1, 4500, "Symphony No. 9" },
                    { 12, "Mozart: Operas", 2, 7200, "Don Giovanni" }
                });

            migrationBuilder.InsertData(
                table: "SongsGenres",
                columns: new[] { "Id", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 1, 3 },
                    { 6, 2, 3 },
                    { 7, 1, 4 },
                    { 8, 2, 4 },
                    { 9, 3, 4 },
                    { 10, 1, 5 },
                    { 11, 2, 5 },
                    { 12, 1, 6 },
                    { 13, 2, 6 },
                    { 14, 3, 7 },
                    { 15, 4, 7 },
                    { 16, 3, 8 },
                    { 17, 4, 8 },
                    { 18, 4, 9 },
                    { 19, 5, 9 },
                    { 20, 4, 10 },
                    { 21, 5, 10 },
                    { 22, 1, 11 },
                    { 23, 2, 11 },
                    { 24, 1, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongsGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
