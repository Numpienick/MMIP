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
                        comment_type = table.Column<string>(type: "text", nullable: false),
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
                name: "sector",
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
                    table.PrimaryKey("pk_sector", x => x.id);
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
                name: "branches",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name = table.Column<string>(type: "text", nullable: false),
                        sector_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "fk_branches_sector_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sector",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
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
                        deadline = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        start_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        final_report = table.Column<string>(type: "text", nullable: true),
                        organization_id = table.Column<Guid>(type: "uuid", nullable: false),
                        challenge_visibility = table.Column<string>(type: "text", nullable: false),
                        current_phase_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "phases",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name = table.Column<string>(type: "text", nullable: false),
                        order = table.Column<int>(type: "integer", nullable: false),
                        description = table.Column<string>(type: "text", nullable: false),
                        challenge_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "fk_phases_challenges_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "challenges",
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
                        name = table.Column<string>(type: "text", nullable: false),
                        description = table.Column<string>(type: "text", nullable: false),
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
                name: "ix_branches_sector_id",
                table: "branches",
                column: "sector_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenges_current_phase_id",
                table: "challenges",
                column: "current_phase_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_challenges_organization_id",
                table: "challenges",
                column: "organization_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_phases_challenge_id",
                table: "phases",
                column: "challenge_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_user_groups_phase_id",
                table: "user_groups",
                column: "phase_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_challenges_phases_current_phase_id",
                table: "challenges",
                column: "current_phase_id",
                principalTable: "phases",
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

            migrationBuilder.DropForeignKey(
                name: "fk_challenges_phases_current_phase_id",
                table: "challenges"
            );

            migrationBuilder.DropTable(name: "branches");

            migrationBuilder.DropTable(name: "comments");

            migrationBuilder.DropTable(name: "user_groups");

            migrationBuilder.DropTable(name: "users");

            migrationBuilder.DropTable(name: "sector");

            migrationBuilder.DropTable(name: "organizations");

            migrationBuilder.DropTable(name: "phases");

            migrationBuilder.DropTable(name: "challenges");
        }
    }
}
