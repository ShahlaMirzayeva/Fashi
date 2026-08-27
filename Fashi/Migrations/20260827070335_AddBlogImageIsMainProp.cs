using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashi.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogImageIsMainProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "BlogImages",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "BlogImages");
        }
    }
}
