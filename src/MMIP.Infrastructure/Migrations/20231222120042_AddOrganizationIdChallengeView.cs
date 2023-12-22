using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationIdChallengeView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.challenge_view;");
            migrationBuilder.Sql(
                @"CREATE OR REPLACE VIEW public.challenge_view
AS  SELECT c.id AS challenge_id,
    c.title,
    c.description,
    c.banner_image_path,
    c.final_report,
    c.start_date,
    c.deadline,
    c.organization_id,
    p.name AS phase_name,
    round((100 * p.""order"" / count(cp.*))::numeric, 1) AS progress,
    o.name AS organization_name
   FROM challenges c
     LEFT JOIN challenge_phases cp ON c.id = cp.challenge_id
     LEFT JOIN phases p ON c.current_phase_id = p.id
     LEFT JOIN organizations o ON c.organization_id = o.id
  GROUP BY c.id, c.title, c.description, c.banner_image_path, c.final_report, c.start_date, c.deadline, p.name, p.""order"", o.name
  ORDER BY c.id;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW public.challenge_view;");
            migrationBuilder.Sql(
                @"CREATE OR REPLACE VIEW public.challenge_view
AS  SELECT c.id AS challenge_id,
    c.title,
    c.description,
    c.banner_image_path,
    c.final_report,
    c.start_date,
    c.deadline,
    p.name AS phase_name,
    round((100 * p.""order"" / count(cp.*))::numeric, 1) AS progress,
    o.name AS organization_name
   FROM challenges c
     LEFT JOIN challenge_phases cp ON c.id = cp.challenge_id
     LEFT JOIN phases p ON c.current_phase_id = p.id
     LEFT JOIN organizations o ON c.organization_id = o.id
  GROUP BY c.id, c.title, c.description, c.banner_image_path, c.final_report, c.start_date, c.deadline, p.name, p.""order"", o.name
  ORDER BY c.id;"
            );
        }
    }
}
