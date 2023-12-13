using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnterAtToChallengePhases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "entered_at",
                table: "challenge_phases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "entered_at", table: "challenge_phases");
        }
    }
}
