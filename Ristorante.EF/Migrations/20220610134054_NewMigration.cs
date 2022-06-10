using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ristorante.EF.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amministratore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Username = table.Column<string>(type: "varchar(20)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EMail = table.Column<string>(type: "varchar(40)", nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amministratore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", nullable: false),
                    Username = table.Column<string>(type: "varchar(20)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EMail = table.Column<string>(type: "varchar(40)", nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amministratore");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
