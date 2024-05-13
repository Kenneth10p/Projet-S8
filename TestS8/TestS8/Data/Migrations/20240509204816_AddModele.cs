using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestS8.Data.Migrations
{
    public partial class AddModele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Simulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modele",
                columns: table => new
                {
                    IdModele = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Hyperparametre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SimulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modele", x => x.IdModele);
                    table.ForeignKey(
                        name: "FK_Modele_Simulation_SimulationId",
                        column: x => x.SimulationId,
                        principalTable: "Simulation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plot",
                columns: table => new
                {
                    IdPlot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chemin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeleIdModele = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot", x => x.IdPlot);
                    table.ForeignKey(
                        name: "FK_Plot_Modele_ModeleIdModele",
                        column: x => x.ModeleIdModele,
                        principalTable: "Modele",
                        principalColumn: "IdModele");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modele_SimulationId",
                table: "Modele",
                column: "SimulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plot_ModeleIdModele",
                table: "Plot",
                column: "ModeleIdModele");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plot");

            migrationBuilder.DropTable(
                name: "Modele");

            migrationBuilder.DropTable(
                name: "Simulation");
        }
    }
}
