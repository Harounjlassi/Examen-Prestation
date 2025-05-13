using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intitule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Prestataire",
                columns: table => new
                {
                    PrestataireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appreciation = table.Column<int>(type: "int", nullable: false),
                    PrestataireNom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrestatairePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestataireTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarifHoraire = table.Column<double>(type: "float", nullable: false),
                    SpecialiteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestataire", x => x.PrestataireId);
                    table.ForeignKey(
                        name: "FK_Prestataire_Specialite_SpecialiteFK",
                        column: x => x.SpecialiteFK,
                        principalTable: "Specialite",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestation",
                columns: table => new
                {
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestataireFK = table.Column<int>(type: "int", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    NbHeures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestation", x => new { x.PrestataireFK, x.ClientFK, x.HeureDebut });
                    table.ForeignKey(
                        name: "FK_Prestation_Client_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestation_Prestataire_PrestataireFK",
                        column: x => x.PrestataireFK,
                        principalTable: "Prestataire",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestataire_SpecialiteFK",
                table: "Prestataire",
                column: "SpecialiteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prestation_ClientFK",
                table: "Prestation",
                column: "ClientFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestation");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Prestataire");

            migrationBuilder.DropTable(
                name: "Specialite");
        }
    }
}
