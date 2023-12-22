using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR REPLACE VIEW public.comment_view
AS SELECT c.id AS comment_id,
    c.concluded,
    c.created_date,
    c.text,
    c.challenge_id,
    ct.name AS comment_type_name,
    ct.description AS comment_type_description,
    ct.icon_path AS comment_type_icon_path
   FROM comments c
     LEFT JOIN comment_types ct ON c.comment_type_id = ct.id
  ORDER BY c.challenge_id;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view if exists public.comment_view;");
        }
    }
}
