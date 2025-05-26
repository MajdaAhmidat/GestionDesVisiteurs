using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_des_visiteurs.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superviseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idAdministrateur = table.Column<int>(type: "int", nullable: false),
                    administrateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superviseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Superviseurs_Administrateurs_administrateurId",
                        column: x => x.administrateurId,
                        principalTable: "Administrateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visiteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idSuperviseur = table.Column<int>(type: "int", nullable: false),
                    SuperviseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visiteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visiteurs_Superviseurs_SuperviseurId",
                        column: x => x.SuperviseurId,
                        principalTable: "Superviseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idVisiteur = table.Column<int>(type: "int", nullable: false),
                    idSuperviseur = table.Column<int>(type: "int", nullable: false),
                    SuperviseurId = table.Column<int>(type: "int", nullable: true),
                    VisiteurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandes_Superviseurs_SuperviseurId",
                        column: x => x.SuperviseurId,
                        principalTable: "Superviseurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demandes_Superviseurs_idSuperviseur",
                        column: x => x.idSuperviseur,
                        principalTable: "Superviseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Demandes_Visiteurs_VisiteurId",
                        column: x => x.VisiteurId,
                        principalTable: "Visiteurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demandes_Visiteurs_idVisiteur",
                        column: x => x.idVisiteur,
                        principalTable: "Visiteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateVisite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    heureDebut = table.Column<TimeOnly>(type: "time", nullable: false),
                    heureFin = table.Column<TimeOnly>(type: "time", nullable: false),
                    duree = table.Column<TimeOnly>(type: "time", nullable: false),
                    idVisiteur = table.Column<int>(type: "int", nullable: false),
                    VisiteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visites_Visiteurs_VisiteurId",
                        column: x => x.VisiteurId,
                        principalTable: "Visiteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_idSuperviseur",
                table: "Demandes",
                column: "idSuperviseur");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_idVisiteur",
                table: "Demandes",
                column: "idVisiteur");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_SuperviseurId",
                table: "Demandes",
                column: "SuperviseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_VisiteurId",
                table: "Demandes",
                column: "VisiteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Superviseurs_administrateurId",
                table: "Superviseurs",
                column: "administrateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Visites_VisiteurId",
                table: "Visites",
                column: "VisiteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Visiteurs_SuperviseurId",
                table: "Visiteurs",
                column: "SuperviseurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "Visites");

            migrationBuilder.DropTable(
                name: "Visiteurs");

            migrationBuilder.DropTable(
                name: "Superviseurs");

            migrationBuilder.DropTable(
                name: "Administrateurs");
        }
    }
}
