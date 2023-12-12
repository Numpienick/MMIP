using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeftJoinToChallengeCardView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.challenge_card_view;");
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
