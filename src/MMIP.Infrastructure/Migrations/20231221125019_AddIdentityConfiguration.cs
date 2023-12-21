using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "created_date", table: "users");

            migrationBuilder.DropColumn(name: "updated_date", table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid"
            );

            migrationBuilder.AddColumn<int>(
                name: "access_failed_count",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<string>(
                name: "avatar_path",
                table: "users",
                type: "character varying(254)",
                maxLength: 254,
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "concurrency_stamp",
                table: "users",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "users",
                type: "character varying(100000)",
                maxLength: 100000,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<bool>(
                name: "email_confirmed",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "users",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "users",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<bool>(
                name: "lockout_enabled",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "lockout_end",
                table: "users",
                type: "timestamp with time zone",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "normalized_email",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "normalized_user_name",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "users",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "preposition",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "security_stamp",
                table: "users",
                type: "text",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "two_factor_enabled",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table =>
                    new
                    {
                        id = table.Column<string>(type: "text", nullable: false),
                        name = table.Column<string>(
                            type: "character varying(256)",
                            maxLength: 256,
                            nullable: true
                        ),
                        normalized_name = table.Column<string>(
                            type: "character varying(256)",
                            maxLength: 256,
                            nullable: true
                        ),
                        concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table =>
                    new
                    {
                        id = table
                            .Column<int>(type: "integer", nullable: false)
                            .Annotation(
                                "Npgsql:ValueGenerationStrategy",
                                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                            ),
                        user_id = table.Column<string>(type: "text", nullable: false),
                        claim_type = table.Column<string>(type: "text", nullable: true),
                        claim_value = table.Column<string>(type: "text", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table =>
                    new
                    {
                        login_provider = table.Column<string>(type: "text", nullable: false),
                        provider_key = table.Column<string>(type: "text", nullable: false),
                        provider_display_name = table.Column<string>(type: "text", nullable: true),
                        user_id = table.Column<string>(type: "text", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_logins",
                        x => new { x.login_provider, x.provider_key }
                    );
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table =>
                    new
                    {
                        user_id = table.Column<string>(type: "text", nullable: false),
                        login_provider = table.Column<string>(type: "text", nullable: false),
                        name = table.Column<string>(type: "text", nullable: false),
                        value = table.Column<string>(type: "text", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_tokens",
                        x =>
                            new
                            {
                                x.user_id,
                                x.login_provider,
                                x.name
                            }
                    );
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table =>
                    new
                    {
                        user_code = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: false
                        ),
                        device_code = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: false
                        ),
                        subject_id = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: true
                        ),
                        session_id = table.Column<string>(
                            type: "character varying(100)",
                            maxLength: 100,
                            nullable: true
                        ),
                        client_id = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: true
                        ),
                        creation_time = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        expiration = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        data = table.Column<string>(
                            type: "character varying(50000)",
                            maxLength: 50000,
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_codes", x => x.user_code);
                }
            );

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table =>
                    new
                    {
                        id = table.Column<string>(type: "text", nullable: false),
                        version = table.Column<int>(type: "integer", nullable: false),
                        created = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        use = table.Column<string>(type: "text", nullable: true),
                        algorithm = table.Column<string>(
                            type: "character varying(100)",
                            maxLength: 100,
                            nullable: false
                        ),
                        is_x509certificate = table.Column<bool>(type: "boolean", nullable: false),
                        data_protected = table.Column<bool>(type: "boolean", nullable: false),
                        data = table.Column<string>(type: "text", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_keys", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table =>
                    new
                    {
                        key = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: false
                        ),
                        type = table.Column<string>(
                            type: "character varying(50)",
                            maxLength: 50,
                            nullable: false
                        ),
                        subject_id = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: true
                        ),
                        session_id = table.Column<string>(
                            type: "character varying(100)",
                            maxLength: 100,
                            nullable: true
                        ),
                        client_id = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "character varying(200)",
                            maxLength: 200,
                            nullable: true
                        ),
                        creation_time = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        expiration = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: true
                        ),
                        consumed_time = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: true
                        ),
                        data = table.Column<string>(
                            type: "character varying(50000)",
                            maxLength: 50000,
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table =>
                    new
                    {
                        id = table
                            .Column<int>(type: "integer", nullable: false)
                            .Annotation(
                                "Npgsql:ValueGenerationStrategy",
                                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                            ),
                        role_id = table.Column<string>(type: "text", nullable: false),
                        claim_type = table.Column<string>(type: "text", nullable: true),
                        claim_value = table.Column<string>(type: "text", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table =>
                    new
                    {
                        user_id = table.Column<string>(type: "text", nullable: false),
                        role_id = table.Column<string>(type: "text", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalized_email"
            );

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalized_user_name",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id"
            );

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_device_code",
                table: "DeviceCodes",
                column: "device_code",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_expiration",
                table: "DeviceCodes",
                column: "expiration"
            );

            migrationBuilder.CreateIndex(name: "ix_keys_use", table: "Keys", column: "use");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_consumed_time",
                table: "PersistedGrants",
                column: "consumed_time"
            );

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_expiration",
                table: "PersistedGrants",
                column: "expiration"
            );

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_client_id_type",
                table: "PersistedGrants",
                columns: new[] { "subject_id", "client_id", "type" }
            );

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_session_id_type",
                table: "PersistedGrants",
                columns: new[] { "subject_id", "session_id", "type" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AspNetRoleClaims");

            migrationBuilder.DropTable(name: "AspNetUserClaims");

            migrationBuilder.DropTable(name: "AspNetUserLogins");

            migrationBuilder.DropTable(name: "AspNetUserRoles");

            migrationBuilder.DropTable(name: "AspNetUserTokens");

            migrationBuilder.DropTable(name: "DeviceCodes");

            migrationBuilder.DropTable(name: "Keys");

            migrationBuilder.DropTable(name: "PersistedGrants");

            migrationBuilder.DropTable(name: "AspNetRoles");

            migrationBuilder.DropIndex(name: "EmailIndex", table: "users");

            migrationBuilder.DropIndex(name: "UserNameIndex", table: "users");

            migrationBuilder.DropColumn(name: "access_failed_count", table: "users");

            migrationBuilder.DropColumn(name: "avatar_path", table: "users");

            migrationBuilder.DropColumn(name: "concurrency_stamp", table: "users");

            migrationBuilder.DropColumn(name: "description", table: "users");

            migrationBuilder.DropColumn(name: "email", table: "users");

            migrationBuilder.DropColumn(name: "email_confirmed", table: "users");

            migrationBuilder.DropColumn(name: "first_name", table: "users");

            migrationBuilder.DropColumn(name: "last_name", table: "users");

            migrationBuilder.DropColumn(name: "lockout_enabled", table: "users");

            migrationBuilder.DropColumn(name: "lockout_end", table: "users");

            migrationBuilder.DropColumn(name: "normalized_email", table: "users");

            migrationBuilder.DropColumn(name: "normalized_user_name", table: "users");

            migrationBuilder.DropColumn(name: "password_hash", table: "users");

            migrationBuilder.DropColumn(name: "preposition", table: "users");

            migrationBuilder.DropColumn(name: "security_stamp", table: "users");

            migrationBuilder.DropColumn(name: "two_factor_enabled", table: "users");

            migrationBuilder.DropColumn(name: "user_name", table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new TimeSpan(0, 0, 0, 0, 0)
                )
            );

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated_date",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new TimeSpan(0, 0, 0, 0, 0)
                )
            );
        }
    }
}
