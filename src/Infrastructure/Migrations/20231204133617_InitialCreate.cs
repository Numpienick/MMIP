using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branches",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("pk_branches", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        text = table.Column<string>(
                            type: "character varying(1000)",
                            maxLength: 1000,
                            nullable: false
                        ),
                        concluded = table.Column<bool>(type: "boolean", nullable: false),
                        comment_type = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("pk_comments", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("pk_organizations", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "users",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("pk_users", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "challenges",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        title = table.Column<string>(type: "text", nullable: false),
                        description = table.Column<string>(type: "text", nullable: false),
                        short_description = table.Column<string>(
                            type: "character varying(1000)",
                            maxLength: 1000,
                            nullable: false
                        ),
                        banner_image_path = table.Column<string>(type: "text", nullable: true),
                        deadline = table.Column<DateTime>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        start_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        final_report = table.Column<string>(type: "text", nullable: true),
                        tags = table.Column<string[]>(type: "text[]", nullable: true),
                        organization_id = table.Column<Guid>(type: "uuid", nullable: true),
                        challenge_visibility = table.Column<int>(type: "integer", nullable: false),
                        phase_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_challenges", x => x.id);
                    table.ForeignKey(
                        name: "fk_challenges_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "field",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        required_fields = table.Column<string[]>(type: "text[]", nullable: false),
                        phase_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_field", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "phases",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name_id = table.Column<Guid>(type: "uuid", nullable: false),
                        order = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("pk_phases", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "text",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        value = table.Column<string>(type: "text", nullable: false),
                        parent_id = table.Column<Guid>(type: "uuid", nullable: false),
                        language_iso = table.Column<string>(type: "text", nullable: false),
                        phase_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_text", x => x.id);
                    table.ForeignKey(
                        name: "fk_text_phases_phase_id",
                        column: x => x.phase_id,
                        principalTable: "phases",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        phase_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_user_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_groups_phases_phase_id",
                        column: x => x.phase_id,
                        principalTable: "phases",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenges_organization_id",
                table: "challenges",
                column: "organization_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenges_phase_id",
                table: "challenges",
                column: "phase_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_field_phase_id",
                table: "field",
                column: "phase_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_phases_name_id",
                table: "phases",
                column: "name_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_text_phase_id",
                table: "text",
                column: "phase_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_user_groups_phase_id",
                table: "user_groups",
                column: "phase_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_phases_phase_id",
                table: "challenges",
                column: "phase_id",
                principalTable: "phases",
                principalColumn: "id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_field_phases_phase_id",
                table: "field",
                column: "phase_id",
                principalTable: "phases",
                principalColumn: "id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_phases_text_name_id",
                table: "phases",
                column: "name_id",
                principalTable: "text",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "fk_text_phases_phase_id", table: "text");

            migrationBuilder.DropTable(name: "branches");

            migrationBuilder.DropTable(name: "challenges");

            migrationBuilder.DropTable(name: "comments");

            migrationBuilder.DropTable(name: "field");

            migrationBuilder.DropTable(name: "user_groups");

            migrationBuilder.DropTable(name: "users");

            migrationBuilder.DropTable(name: "organizations");

            migrationBuilder.DropTable(name: "phases");

            migrationBuilder.DropTable(name: "text");
        }
    }
}
