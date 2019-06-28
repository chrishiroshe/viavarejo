using Microsoft.EntityFrameworkCore.Migrations;

namespace Distance.WebAPI.Migrations
{
    public partial class addlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistanciaId",
                table: "CalculoHistoricoLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalculoHistoricoLog_DistanciaId",
                table: "CalculoHistoricoLog",
                column: "DistanciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculoHistoricoLog_Distancia_DistanciaId",
                table: "CalculoHistoricoLog",
                column: "DistanciaId",
                principalTable: "Distancia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculoHistoricoLog_Distancia_DistanciaId",
                table: "CalculoHistoricoLog");

            migrationBuilder.DropIndex(
                name: "IX_CalculoHistoricoLog_DistanciaId",
                table: "CalculoHistoricoLog");

            migrationBuilder.DropColumn(
                name: "DistanciaId",
                table: "CalculoHistoricoLog");
        }
    }
}
