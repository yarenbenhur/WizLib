using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddDetailToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Detail_Detail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                table: "Detail");

            migrationBuilder.RenameTable(
                name: "Detail",
                newName: "Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "Detail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                principalTable: "Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "Detail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                table: "Detail",
                column: "Detail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Detail_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                principalTable: "Detail",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
