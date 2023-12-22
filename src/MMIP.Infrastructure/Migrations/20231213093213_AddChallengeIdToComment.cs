using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChallengeIdToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "challenge_id",
                table: "comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(
                name: "ix_comments_challenge_id",
                table: "comments",
                column: "challenge_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_comments_challenges_challenge_id",
                table: "comments",
                column: "challenge_id",
                principalTable: "challenges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_challenges_challenge_id",
                table: "comments"
            );

            migrationBuilder.DropIndex(name: "ix_comments_challenge_id", table: "comments");

            migrationBuilder.DropColumn(name: "challenge_id", table: "comments");
        }
    }
}
