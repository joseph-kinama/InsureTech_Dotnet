using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsureTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformations_Policies_PolicyId",
                table: "PersonalInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInformations",
                table: "PersonalInformations");

            migrationBuilder.RenameTable(
                name: "PersonalInformations",
                newName: "PersonalInformation");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInformations_PolicyId",
                table: "PersonalInformation",
                newName: "IX_PersonalInformation_PolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformation_Policies_PolicyId",
                table: "PersonalInformation",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformation_Policies_PolicyId",
                table: "PersonalInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation");

            migrationBuilder.RenameTable(
                name: "PersonalInformation",
                newName: "PersonalInformations");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalInformation_PolicyId",
                table: "PersonalInformations",
                newName: "IX_PersonalInformations_PolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInformations",
                table: "PersonalInformations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformations_Policies_PolicyId",
                table: "PersonalInformations",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
