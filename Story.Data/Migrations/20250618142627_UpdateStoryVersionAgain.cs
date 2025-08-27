using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Story.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStoryVersionAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "StoryVersions",
                type: "nvarchar(4000)", 
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
