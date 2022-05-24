using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class MakeDetailNullableBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_Detail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_Detail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookAuthor_Author_Id",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Books_Detail_Id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Fluent_Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceRange",
                table: "Fluent_Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Detail_Id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_BookDetail_Id",
                table: "Fluent_Books",
                column: "BookDetail_Id",
                unique: true,
                filter: "[BookDetail_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthor_Book_Id",
                table: "Fluent_BookAuthor",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                unique: true,
                filter: "[Detail_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                principalTable: "Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_BookDetail_Id",
                table: "Fluent_Books",
                column: "BookDetail_Id",
                principalTable: "Fluent_Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookAuthor_Book_Id",
                table: "Fluent_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Books_Detail_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "PriceRange",
                table: "Fluent_Books");

            migrationBuilder.AlterColumn<int>(
                name: "Detail_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthor",
                table: "Fluent_BookAuthor",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_Detail_Id",
                table: "Fluent_Books",
                column: "Detail_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthor_Author_Id",
                table: "Fluent_BookAuthor",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Details_Detail_Id",
                table: "Books",
                column: "Detail_Id",
                principalTable: "Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_Detail_Id",
                table: "Fluent_Books",
                column: "Detail_Id",
                principalTable: "Fluent_Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
