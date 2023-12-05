using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialChallengeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenges_organizations_organization_id",
                table: "challenges"
            );

            migrationBuilder.DropForeignKey(
                name: "fk_challenges_phases_current_phase_id",
                table: "challenges"
            );

            migrationBuilder.DropForeignKey(
                name: "fk_phases_challenges_challenge_id",
                table: "phases"
            );

            migrationBuilder.DropIndex(name: "ix_phases_challenge_id", table: "phases");

            migrationBuilder.DropIndex(name: "ix_challenges_current_phase_id", table: "challenges");

            migrationBuilder.DropColumn(name: "challenge_id", table: "phases");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "challenges",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "start_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<string>(
                name: "final_report",
                table: "challenges",
                type: "character varying(100000)",
                maxLength: 100000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "challenges",
                type: "character varying(100000)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<string>(
                name: "banner_image_path",
                table: "challenges",
                type: "character varying(254)",
                maxLength: 254,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true
            );

            migrationBuilder.CreateTable(
                name: "challenge_phases",
                columns: table =>
                    new
                    {
                        challenge_id = table.Column<Guid>(type: "uuid", nullable: false),
                        phase_id = table.Column<Guid>(type: "uuid", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_challenge_phases",
                        x => new { x.challenge_id, x.phase_id }
                    );
                    table.ForeignKey(
                        name: "fk_challenge_phases_challenges_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "challenges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_challenge_phases_phases_phases_id",
                        column: x => x.phase_id,
                        principalTable: "phases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        value = table.Column<string>(type: "text", nullable: false),
                        created_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        updated_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag", x => x.id);
                }
            );

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
                name: "ix_challenge_phases_phases_id",
                table: "challenge_phases",
                column: "phase_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenge_tags_challenges_id",
                table: "challenge_tags",
                column: "challenge_id"
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_challenges_organizations_organization_id1",
                table: "challenges"
            );

            migrationBuilder.DropTable(name: "challenge_phases");

            migrationBuilder.DropTable(name: "challenge_tags");

            migrationBuilder.DropTable(name: "tag");

            migrationBuilder.AddColumn<Guid>(
                name: "challenge_id",
                table: "phases",
                type: "uuid",
                nullable: true
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "challenges",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "start_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<string>(
                name: "final_report",
                table: "challenges",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100000)",
                oldMaxLength: 100000,
                oldNullable: true
            );

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "challenges",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100000)",
                oldMaxLength: 100000
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "challenges",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<string>(
                name: "banner_image_path",
                table: "challenges",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(254)",
                oldMaxLength: 254,
                oldNullable: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_phases_challenge_id",
                table: "phases",
                column: "challenge_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenges_current_phase_id",
                table: "challenges",
                column: "current_phase_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_organizations_organization_id",
                table: "challenges",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_phases_current_phase_id",
                table: "challenges",
                column: "current_phase_id",
                principalTable: "phases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "fk_phases_challenges_challenge_id",
                table: "phases",
                column: "challenge_id",
                principalTable: "challenges",
                principalColumn: "id"
            );
        }
    }
}
