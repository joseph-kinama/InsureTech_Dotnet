using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsureTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdatedPoliciesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_PersonalInformations_PersonalInformationId",
                table: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Policies_PersonalInformationId",
                table: "Policies");

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "PersonalInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformations_PolicyId",
                table: "PersonalInformations",
                column: "PolicyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformations_Policies_PolicyId",
                table: "PersonalInformations",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformations_Policies_PolicyId",
                table: "PersonalInformations");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformations_PolicyId",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "PersonalInformations");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PersonalInformationId",
                table: "Policies",
                column: "PersonalInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_PersonalInformations_PersonalInformationId",
                table: "Policies",
                column: "PersonalInformationId",
                principalTable: "PersonalInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
