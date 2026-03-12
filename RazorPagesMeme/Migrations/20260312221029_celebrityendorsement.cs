using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMeme.Migrations
{
    /// <inheritdoc />
    public partial class celebrityendorsement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CelebrityEndorsement",
                table: "Meme",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CelebrityEndorsement",
                table: "Meme");
        }
    }
}
