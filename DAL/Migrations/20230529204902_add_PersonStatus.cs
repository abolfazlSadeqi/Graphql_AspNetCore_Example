using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_PersonStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonStatusId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStatus", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonStatusId",
                table: "Persons",
                column: "PersonStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PersonStatus_PersonStatusId",
                table: "Persons",
                column: "PersonStatusId",
                principalTable: "PersonStatus",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PersonStatus_PersonStatusId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PersonStatus");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonStatusId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonStatusId",
                table: "Persons");
        }
    }
}
