using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSectorConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_branches_sector_sector_id",
                table: "branches"
            );

            migrationBuilder.DropTable(name: "sector");

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        name = table.Column<string>(
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
                    table.PrimaryKey("pk_sectors", x => x.id);
                }
            );

            migrationBuilder.AddForeignKey(
                name: "fk_branches_sectors_sector_id",
                table: "branches",
                column: "sector_id",
                principalTable: "sectors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_branches_sectors_sector_id",
                table: "branches"
            );

            migrationBuilder.DropTable(name: "sectors");

            migrationBuilder.CreateTable(
                name: "sector",
                columns: table =>
                    new
                    {
                        id = table.Column<Guid>(type: "uuid", nullable: false),
                        created_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        ),
                        name = table.Column<string>(type: "text", nullable: false),
                        updated_date = table.Column<DateTimeOffset>(
                            type: "timestamp with time zone",
                            nullable: false
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sector", x => x.id);
                }
            );

            migrationBuilder.AddForeignKey(
                name: "fk_branches_sector_sector_id",
                table: "branches",
                column: "sector_id",
                principalTable: "sector",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
