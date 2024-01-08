using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLogoPathToChallengeCardView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS challenge_card_view;");
            migrationBuilder.Sql(
                @"
CREATE OR REPLACE VIEW challenge_card_view
AS SELECT c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
    c.challenge_visibility,
    c.organization_id,
    o.profile_avatar_path,
    o.name AS organization_name,
    string_agg(t.value::text, ';'::text) AS tags
   FROM challenges c
    LEFT JOIN organizations o ON c.organization_id = o.id
    LEFT JOIN challenge_tags ct ON c.id = ct.challenge_id
    LEFT JOIN tags t ON ct.tag_id = t.id
  GROUP BY c.id, c.title, c.short_description, c.banner_image_path, c.challenge_visibility, c.organization_id, o.profile_avatar_path, o.name
  ORDER BY c.created_date DESC;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS challenge_card_view;");
            migrationBuilder.Sql(
                @"
CREATE OR REPLACE VIEW challenge_card_view
AS SELECT c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
    c.challenge_visibility,
    c.organization_id,
    o.name AS organization_name,
    string_agg(t.value::text, ';'::text) AS tags
   FROM challenges c
    LEFT JOIN organizations o ON c.organization_id = o.id
    LEFT JOIN challenge_tags ct ON c.id = ct.challenge_id
    LEFT JOIN tags t ON ct.tag_id = t.id
  GROUP BY c.id, c.title, c.short_description, c.banner_image_path, c.challenge_visibility, c.organization_id, o.name
  ORDER BY c.created_date DESC;"
            );
        }
    }
}
