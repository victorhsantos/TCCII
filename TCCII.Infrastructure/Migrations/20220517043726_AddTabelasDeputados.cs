using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCII.Infrastructure.Migrations
{
    public partial class AddTabelasDeputados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deputados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDeputado = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    IdLegislatura = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    SiglaPartido = table.Column<string>(type: "varchar(25)", nullable: false),
                    SiglaUf = table.Column<string>(type: "varchar(25)", nullable: false),
                    Uri = table.Column<string>(type: "varchar(300)", nullable: false),
                    UriPartido = table.Column<string>(type: "varchar(300)", nullable: false),
                    UrlFoto = table.Column<string>(type: "varchar(300)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExcludedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deputados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDeputados",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeputadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeputados", x => new { x.UserId, x.DeputadosId });
                    table.ForeignKey(
                        name: "FK_UserDeputados_Deputados_DeputadosId",
                        column: x => x.DeputadosId,
                        principalTable: "Deputados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDeputados_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "9219ad8d-7eb3-4e36-ad14-3bcd28a50bf9");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c41e114b-cfd4-4e96-b915-ffe41d26ab34");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeputados_DeputadosId",
                table: "UserDeputados",
                column: "DeputadosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDeputados");

            migrationBuilder.DropTable(
                name: "Deputados");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "1eac0c9b-b84a-494a-8127-d0bc45b38b8c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a8e571b0-0986-4b63-a042-cac77a2b851d");
        }
    }
}
