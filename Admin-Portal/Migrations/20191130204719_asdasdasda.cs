using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin_Portal.Migrations
{
    public partial class asdasdasda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    LinkName = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    RolesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.ID);
                    table.ForeignKey(
                        name: "FK_links_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_links_RolesId",
                table: "links",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "links");
        }
    }
}
