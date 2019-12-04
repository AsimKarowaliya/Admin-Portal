using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin_Portal.Migrations
{
    public partial class asdasda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "links",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "links",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
