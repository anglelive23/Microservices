using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.API.Migrations
{
    /// <inheritdoc />
    public partial class DeleteImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Images_ImageId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Images_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
