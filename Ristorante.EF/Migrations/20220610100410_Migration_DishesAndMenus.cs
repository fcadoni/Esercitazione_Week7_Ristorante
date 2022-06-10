using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ristorante.EF.Migrations
{
    public partial class Migration_DishesAndMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Piatto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    KindOfDish = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piatto_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piatto_MenuId",
                table: "Piatto",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatto");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
