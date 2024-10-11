using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsureTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatePoliciesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalIdOrPassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_PersonalInformations_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PersonalInformationId",
                table: "Policies",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PolicyTypeId",
                table: "Policies",
                column: "PolicyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "PolicyTypes");
        }
    }
}
