using Microsoft.EntityFrameworkCore.Migrations;

namespace Distance.WebAPI.Migrations
{
    public partial class addAmigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeAmigo",
                table: "CalculoHistoricoLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeAmigo",
                table: "CalculoHistoricoLog");
        }
    }
}
