using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentAndTypeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "comment_type", table: "comments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "comments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "comment_type_id",
                table: "comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "creator_id",
                table: "comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateTable(
                name: "comment_types",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name = table.Column<string>(
                            type: "character varying(64)",
                            maxLength: 64,
                            nullable: false
                        ),
                        icon_path = table.Column<string>(
                            type: "character varying(254)",
                            maxLength: 254,
                            nullable: false
                        ),
                        description = table.Column<string>(
                            type: "character varying(254)",
                            maxLength: 254,
                            nullable: false
                        ),
                        created_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "NOW()"
                        ),
                        updated_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "NOW()"
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comment_types", x => x.id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_comments_comment_type_id",
                table: "comments",
                column: "comment_type_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_comment_types_name",
                table: "comment_types",
                column: "name",
                unique: true
            );

            migrationBuilder.AddForeignKey(
                name: "fk_comments_comment_types_comment_type_id",
                table: "comments",
                column: "comment_type_id",
                principalTable: "comment_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_comment_types_comment_type_id",
                table: "comments"
            );

            migrationBuilder.DropTable(name: "comment_types");

            migrationBuilder.DropIndex(name: "ix_comments_comment_type_id", table: "comments");

            migrationBuilder.DropColumn(name: "comment_type_id", table: "comments");

            migrationBuilder.DropColumn(name: "creator_id", table: "comments");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "comments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "comments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AddColumn<string>(
                name: "comment_type",
                table: "comments",
                type: "text",
                nullable: false,
                defaultValue: ""
            );
        }
    }
}
