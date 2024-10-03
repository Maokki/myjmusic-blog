using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMusicBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLyricsColumnToJMusic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lyrics",
                table: "JMusic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lyrics",
                table: "JMusic");
        }
    }
}
