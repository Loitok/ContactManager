using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class AddFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "CsvModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CsvModels_FileId",
                table: "CsvModels",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CsvModels_FileModels_FileId",
                table: "CsvModels",
                column: "FileId",
                principalTable: "FileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsvModels_FileModels_FileId",
                table: "CsvModels");

            migrationBuilder.DropTable(
                name: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_CsvModels_FileId",
                table: "CsvModels");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "CsvModels");
        }
    }
}
