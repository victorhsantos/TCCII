using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCII.Infrastructure.Migrations
{
    public partial class AjusteCampoDeputado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeputados_Deputados_DeputadosId",
                table: "UserDeputados");

            migrationBuilder.DropTable(
                name: "Deputados");

            migrationBuilder.CreateTable(
                name: "Deputado",
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
                    table.PrimaryKey("PK_Deputado", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "1bee093a-2834-415c-8ea3-fb3756ea696c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "82498cde-2c4f-4080-89e0-82c1b857252b");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeputados_Deputado_DeputadosId",
                table: "UserDeputados",
                column: "DeputadosId",
                principalTable: "Deputado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeputados_Deputado_DeputadosId",
                table: "UserDeputados");

            migrationBuilder.DropTable(
                name: "Deputado");

            migrationBuilder.CreateTable(
                name: "Deputados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    ExcludedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDeputado = table.Column<int>(type: "int", nullable: false),
                    IdLegislatura = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    SiglaPartido = table.Column<string>(type: "varchar(25)", nullable: false),
                    SiglaUf = table.Column<string>(type: "varchar(25)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uri = table.Column<string>(type: "varchar(300)", nullable: false),
                    UriPartido = table.Column<string>(type: "varchar(300)", nullable: false),
                    UrlFoto = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deputados", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeputados_Deputados_DeputadosId",
                table: "UserDeputados",
                column: "DeputadosId",
                principalTable: "Deputados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
