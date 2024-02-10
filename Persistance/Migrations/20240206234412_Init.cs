using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "birthCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIN = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_birthCertificates_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NIN = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_degrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_degrees_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professionalCert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NIN = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionalCert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professionalCert_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "birthCertificatesImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthCertificateID = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birthCertificatesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_birthCertificatesImages_birthCertificates_BirthCertificateID",
                        column: x => x.BirthCertificateID,
                        principalTable: "birthCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "degreeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_degreeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_degreeImages_degrees_DegreeID",
                        column: x => x.DegreeID,
                        principalTable: "degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professionalCertImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalCertID = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionalCertImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_professionalCertImages_professionalCert_ProfessionalCertID",
                        column: x => x.ProfessionalCertID,
                        principalTable: "professionalCert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_birthCertificates_UserId",
                table: "birthCertificates",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_birthCertificatesImages_BirthCertificateID",
                table: "birthCertificatesImages",
                column: "BirthCertificateID");

            migrationBuilder.CreateIndex(
                name: "IX_degreeImages_DegreeID",
                table: "degreeImages",
                column: "DegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_degrees_UserId",
                table: "degrees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalCert_UserId",
                table: "professionalCert",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalCertImages_ProfessionalCertID",
                table: "professionalCertImages",
                column: "ProfessionalCertID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "birthCertificatesImages");

            migrationBuilder.DropTable(
                name: "degreeImages");

            migrationBuilder.DropTable(
                name: "professionalCertImages");

            migrationBuilder.DropTable(
                name: "birthCertificates");

            migrationBuilder.DropTable(
                name: "degrees");

            migrationBuilder.DropTable(
                name: "professionalCert");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
