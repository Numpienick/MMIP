using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsToChallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenge_tags",
                columns: table =>
                    new
                    {
                        challenge_id = table.Column<Guid>(type: "uuid", nullable: false),
                        tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_tags", x => new { x.challenge_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_challenge_tags_challenges_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "challenges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_challenge_tags_tags_tags_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenge_tags_tags_id",
                table: "challenge_tags",
                column: "tag_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "challenge_tags");
        }
    }
}
