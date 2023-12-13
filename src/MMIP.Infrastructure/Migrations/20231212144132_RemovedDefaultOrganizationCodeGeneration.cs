using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDefaultOrganizationCodeGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "enrollment_code",
                table: "organizations",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8,
                oldDefaultValue: "GUH6K87D"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "enrollment_code",
                table: "organizations",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "GUH6K87D",
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8
            );
        }
    }
}
