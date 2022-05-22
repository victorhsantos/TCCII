using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCII.Infrastructure.Migrations
{
    public partial class AddTabelaDespesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpjCpfFornecedor = table.Column<string>(type: "varchar(50)", nullable: false),
                    codDocumento = table.Column<int>(type: "int", nullable: false),
                    codLote = table.Column<int>(type: "int", nullable: false),
                    codTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    dataDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    mes = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    nomeFornecedor = table.Column<string>(type: "varchar(200)", nullable: false),
                    numDocumento = table.Column<string>(type: "varchar(50)", nullable: false),
                    numRessarcimento = table.Column<string>(type: "varchar(50)", nullable: false),
                    parcela = table.Column<int>(type: "int", nullable: false),
                    tipoDespesa = table.Column<string>(type: "varchar(200)", nullable: false),
                    tipoDocumento = table.Column<string>(type: "varchar(200)", nullable: false),
                    urlDocumento = table.Column<string>(type: "varchar(200)", nullable: false),
                    valorDocumento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valorGlosa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valorLiquido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExcludedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "1bee093a-2834-415c-8ea3-fb3756ea696c", "AceleroID User", "ACELEROID USER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99999, "82498cde-2c4f-4080-89e0-82c1b857252b", "AceleroID Administrator", "ACELEROID ADMINISTRATOR" });
        }
    }
}
