using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookCollectionAPI.Migrations
{
    public partial class comicTraitID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "comicID",
                table: "CBTrait",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comicID",
                table: "CBTrait");
        }
    }
}
