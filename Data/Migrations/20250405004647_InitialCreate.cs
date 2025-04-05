using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appAgencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    id_region = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    num_tours = table.Column<int>(type: "INTEGER", nullable: false),
                    desc_region = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImgReg_url = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.id_region);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    id_destino = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_region = table.Column<int>(type: "INTEGER", nullable: false),
                    nom_destino = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    desc_destino = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    precio_tour = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    num_entradas = table.Column<int>(type: "INTEGER", nullable: false),
                    time_tour = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ImgDest_url = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.id_destino);
                    table.ForeignKey(
                        name: "FK_Destinos_Regiones_id_region",
                        column: x => x.id_region,
                        principalTable: "Regiones",
                        principalColumn: "id_region",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_id_region",
                table: "Destinos",
                column: "id_region");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Regiones");
        }
    }
}
