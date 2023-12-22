using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFullNameToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "users",
                type: "text",
                nullable: true,
                computedColumnSql: "\r\n        CASE\r\n            WHEN preposition IS NOT NULL THEN first_name || ' ' || preposition || ' ' || last_name\r\n            ELSE first_name || ' ' || last_name\r\n        END\r\n    ",
                stored: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "full_name", table: "users");
        }
    }
}
