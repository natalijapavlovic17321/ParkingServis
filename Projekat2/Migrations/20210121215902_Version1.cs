using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat2.Migrations
{
    public partial class Version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Num = table.Column<int>(type: "int", nullable: false),
                    N = table.Column<int>(type: "int", nullable: false),
                    M = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Naselje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    N = table.Column<int>(type: "int", nullable: false),
                    M = table.Column<int>(type: "int", nullable: false),
                    BrojZauzetih = table.Column<int>(type: "int", nullable: false),
                    ParkinziID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Naselje);
                    table.ForeignKey(
                        name: "FK_Parking_Park_ParkinziID",
                        column: x => x.ParkinziID,
                        principalTable: "Park",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesta",
                columns: table => new
                {
                    Tablica = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Dani = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Povrsina = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Naselje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParkingNaselje = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ParkinziID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesta", x => x.Tablica);
                    table.ForeignKey(
                        name: "FK_Mesta_Park_ParkinziID",
                        column: x => x.ParkinziID,
                        principalTable: "Park",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesta_Parking_ParkingNaselje",
                        column: x => x.ParkingNaselje,
                        principalTable: "Parking",
                        principalColumn: "Naselje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesta_ParkingNaselje",
                table: "Mesta",
                column: "ParkingNaselje");

            migrationBuilder.CreateIndex(
                name: "IX_Mesta_ParkinziID",
                table: "Mesta",
                column: "ParkinziID");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_ParkinziID",
                table: "Parking",
                column: "ParkinziID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesta");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
