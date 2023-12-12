using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhaseConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_groups_phases_phase_id",
                table: "user_groups"
            );

            migrationBuilder.DropIndex(name: "ix_user_groups_phase_id", table: "user_groups");

            migrationBuilder.DropColumn(name: "phase_id", table: "user_groups");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "phases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "phases",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "phases",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "phases",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.CreateTable(
                name: "phase_visible_to_user_groups",
                columns: table =>
                    new
                    {
                        phase_id = table.Column<Guid>(type: "uuid", nullable: false),
                        user_group_id = table.Column<Guid>(type: "uuid", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_phase_visible_to_user_groups",
                        x => new { x.phase_id, x.user_group_id }
                    );
                    table.ForeignKey(
                        name: "fk_phase_visible_to_user_groups_phases_phase_id",
                        column: x => x.phase_id,
                        principalTable: "phases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_phase_visible_to_user_groups_user_groups_visible_to_id",
                        column: x => x.user_group_id,
                        principalTable: "user_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_phase_visible_to_user_groups_visible_to_id",
                table: "phase_visible_to_user_groups",
                column: "user_group_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "phase_visible_to_user_groups");

            migrationBuilder.AddColumn<Guid>(
                name: "phase_id",
                table: "user_groups",
                type: "uuid",
                nullable: true
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "phases",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "phases",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24
            );

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "phases",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(254)",
                oldMaxLength: 254
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "phases",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.CreateIndex(
                name: "ix_user_groups_phase_id",
                table: "user_groups",
                column: "phase_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_user_groups_phases_phase_id",
                table: "user_groups",
                column: "phase_id",
                principalTable: "phases",
                principalColumn: "id"
            );
        }
    }
}
