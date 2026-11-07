using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojeCV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doswiadczenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stanowisko = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Firma = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataOd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doswiadczenie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Stanowisko = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Miasto = table.Column<string>(type: "TEXT", nullable: true),
                    OMnie = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Umiejetnosc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Poziom = table.Column<int>(type: "INTEGER", nullable: false),
                    Kategoria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umiejetnosc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wyksztalcenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uczelnia = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Kierunek = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Stopien = table.Column<string>(type: "TEXT", nullable: true),
                    RokOd = table.Column<int>(type: "INTEGER", nullable: false),
                    RokDo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wyksztalcenie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doswiadczenie");

            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "Umiejetnosc");

            migrationBuilder.DropTable(
                name: "Wyksztalcenie");
        }
    }
}
