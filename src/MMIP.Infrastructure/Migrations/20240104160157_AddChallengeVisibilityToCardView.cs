﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChallengeVisibilityToCardView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS public.challenge_card_view;");
            migrationBuilder.Sql(
                @"
CREATE OR REPLACE VIEW challenge_card_view
AS SELECT 
	c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
	c.challenge_visibility,
    o.name AS organization_name,
    string_agg(t.value, ';') as tags
   FROM challenges c
 	JOIN organizations o ON c.organization_id = o.id
	join  challenge_tags ct on c.id = ct.challenge_id
  	join tags t on ct.tag_id = t.id
GROUP BY 
  c.id, c.title, c.short_description, c.banner_image_path, c.challenge_visibility, o.name;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS public.challenge_card_view;");
            migrationBuilder.Sql(
                @"
CREATE OR REPLACE VIEW challenge_card_view
AS SELECT 
	c.id AS challenge_id,
    c.title,
    c.short_description,
    c.banner_image_path,
    o.name AS organization_name,
    string_agg(t.value, ';') as tags
   FROM challenges c
 	JOIN organizations o ON c.organization_id = o.id
	join  challenge_tags ct on c.id = ct.challenge_id
  	join tags t on ct.tag_id = t.id
GROUP BY 
  c.id, c.title, c.short_description, c.banner_image_path, o.name;"
            );
        }
    }
}
