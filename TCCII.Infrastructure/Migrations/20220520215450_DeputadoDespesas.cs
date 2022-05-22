using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCCII.Infrastructure.Migrations
{
    public partial class DeputadoDespesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeputadoDespesas",
                columns: table => new
                {
                    DeputadoId = table.Column<int>(type: "int", nullable: false),
                    DespesasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeputadoDespesas", x => new { x.DeputadoId, x.DespesasId });
                    table.ForeignKey(
                        name: "FK_DeputadoDespesas_Deputado_DeputadoId",
                        column: x => x.DeputadoId,
                        principalTable: "Deputado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeputadoDespesas_Despesa_DespesasId",
                        column: x => x.DespesasId,
                        principalTable: "Despesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeputadoDespesas_DespesasId",
                table: "DeputadoDespesas",
                column: "DespesasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeputadoDespesas");
        }
    }
}
