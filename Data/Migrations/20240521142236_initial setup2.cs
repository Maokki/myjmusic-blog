using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMusicBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JMusic",
                columns: table => new
                {
                    JMusicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Song = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lyrics = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JMusic", x => x.JMusicId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JMusic");
        }
    }
}
