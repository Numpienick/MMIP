using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TagEntityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "challenge_tags");

            migrationBuilder.DropPrimaryKey(name: "pk_tag", table: "tag");

            migrationBuilder.RenameTable(name: "tag", newName: "tags");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "tags",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AddPrimaryKey(name: "pk_tags", table: "tags", column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_value",
                table: "tags",
                column: "value",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "pk_tags", table: "tags");

            migrationBuilder.DropIndex(name: "ix_tags_value", table: "tags");

            migrationBuilder.RenameTable(name: "tags", newName: "tag");

            migrationBuilder.AlterColumn<string>(
                name: "value",
                table: "tag",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "tag",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "tag",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AddPrimaryKey(name: "pk_tag", table: "tag", column: "id");

            migrationBuilder.CreateTable(
                name: "challenge_tags",
                columns: table =>
                    new
                    {
                        tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                        challenge_id = table.Column<Guid>(type: "uuid", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_tags", x => new { x.tag_id, x.challenge_id });
                    table.ForeignKey(
                        name: "fk_challenge_tags_challenges_challenges_id",
                        column: x => x.challenge_id,
                        principalTable: "challenges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_challenge_tags_tag__tags_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenge_tags_challenges_id",
                table: "challenge_tags",
                column: "challenge_id"
            );
        }
    }
}
