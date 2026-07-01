using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashi.Migrations
{
    /// <inheritdoc />
    public partial class changeLikeCountType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

      
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "LikeIcon",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
