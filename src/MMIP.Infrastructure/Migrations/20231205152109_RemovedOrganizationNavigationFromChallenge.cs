using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOrganizationNavigationFromChallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenges_organizations_organization_id1",
                table: "challenges"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_organizations_organization_id",
                table: "challenges",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenges_organizations_organization_id",
                table: "challenges"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_organizations_organization_id1",
                table: "challenges",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull
            );
        }
    }
}
