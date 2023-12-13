using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.challenge_card_view;");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "organizations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "organizations",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text"
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "organizations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone"
            );

            migrationBuilder.AddColumn<string>(
                name: "enrollment_code",
                table: "organizations",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "GUH6K87D"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "sector_id",
                table: "organizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(
                name: "ix_organizations_sector_id",
                table: "organizations",
                column: "sector_id"
            );

            migrationBuilder.AddForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations",
                column: "sector_id",
                principalTable: "sectors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.Sql(
                @"CREATE OR REPLACE VIEW public.challenge_card_view
AS SELECT c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
    o.name AS organization_name,
    string_agg(t.value::text, ';'::text) AS tags
   FROM challenges c
     LEFT JOIN organizations o ON c.organization_id = o.id
     LEFT JOIN challenge_tags ct ON c.id = ct.challenge_id
     LEFT JOIN tags t ON ct.tag_id = t.id
  GROUP BY c.id, c.title, c.short_description, c.banner_image_path, o.name
  ORDER BY c.start_date ASC;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.challenge_card_view;");

            migrationBuilder.DropForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations"
            );

            migrationBuilder.DropIndex(name: "ix_organizations_sector_id", table: "organizations");

            migrationBuilder.DropColumn(name: "enrollment_code", table: "organizations");

            migrationBuilder.DropColumn(name: "sector_id", table: "organizations");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_date",
                table: "organizations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "organizations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128
            );

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "organizations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()"
            );

            migrationBuilder.Sql(
                @"CREATE OR REPLACE VIEW public.challenge_card_view
AS SELECT c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
    o.name AS organization_name,
    string_agg(t.value::text, ';'::text) AS tags
   FROM challenges c
     JOIN organizations o ON c.organization_id = o.id
     JOIN challenge_tags ct ON c.id = ct.challenge_id
     JOIN tags t ON ct.tag_id = t.id
  GROUP BY c.id, c.title, c.short_description, c.banner_image_path, o.name
  ORDER BY c.start_date ASC;"
            );
        }
    }
}
