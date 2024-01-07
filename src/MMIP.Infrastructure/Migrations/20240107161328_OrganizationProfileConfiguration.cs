using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationProfileConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations");

            migrationBuilder.AddColumn<Guid>(
                name: "organization_id",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "organization_id",
                table: "tags",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profile_avatar_path",
                table: "organizations",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profile_banner_image_path",
                table: "organizations",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profile_description",
                table: "organizations",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "profile_id",
                table: "organizations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "profile_name",
                table: "organizations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profile_sector",
                table: "organizations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "profile_tags",
                table: "organizations",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.CreateIndex(
                name: "ix_users_organization_id",
                table: "users",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_organization_id",
                table: "tags",
                column: "organization_id");

            migrationBuilder.AddForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations",
                column: "sector_id",
                principalTable: "sectors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_organizations_organization_id",
                table: "tags",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_organizations_organization_id",
                table: "users",
                column: "organization_id",
                principalTable: "organizations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations");

            migrationBuilder.DropForeignKey(
                name: "fk_tags_organizations_organization_id",
                table: "tags");

            migrationBuilder.DropForeignKey(
                name: "fk_users_organizations_organization_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_organization_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_tags_organization_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "organization_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "organization_id",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "profile_avatar_path",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_banner_image_path",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_description",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_id",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_name",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_sector",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "profile_tags",
                table: "organizations");

            migrationBuilder.AddForeignKey(
                name: "fk_organizations_sectors_sector_id",
                table: "organizations",
                column: "sector_id",
                principalTable: "sectors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
