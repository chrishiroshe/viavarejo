using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Distance.WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculoHistoricoLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LongitudeOrigem = table.Column<int>(nullable: false),
                    LatitudeOrigem = table.Column<int>(nullable: false),
                    LongitudeDestino = table.Column<int>(nullable: false),
                    LatitudeDestino = table.Column<int>(nullable: false),
                    Distancia = table.Column<int>(nullable: false),
                    LogData = table.Column<DateTime>(nullable: false),
                    DistanciaOrigemId = table.Column<int>(nullable: false),
                    DistanciaDestinoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoHistoricoLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distancia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<int>(nullable: false),
                    Latitude = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distancia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoHistoricoLog");

            migrationBuilder.DropTable(
                name: "Distancia");
        }
    }
}
