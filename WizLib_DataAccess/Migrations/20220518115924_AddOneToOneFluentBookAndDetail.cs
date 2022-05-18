using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneFluentBookAndDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Detail_Id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_Detail_Id",
                table: "Fluent_Books",
                column: "Detail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_Detail_Id",
                table: "Fluent_Books",
                column: "Detail_Id",
                principalTable: "Fluent_Details",
                principalColumn: "Detail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Details_Detail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_Detail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "Detail_Id",
                table: "Fluent_Books");
        }
    }
}
