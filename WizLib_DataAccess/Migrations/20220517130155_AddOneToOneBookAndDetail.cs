using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneBookAndDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Category_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Category_Id",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Books",
                newName: "Detail_Id");

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Detail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Detail_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Detail_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                principalTable: "Detail",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Detail_Detail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropIndex(
                name: "IX_Books_Detail_Id",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Detail_Id",
                table: "Books",
                newName: "Category_Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Category_Id",
                table: "Books",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Category_Id",
                table: "Books",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
