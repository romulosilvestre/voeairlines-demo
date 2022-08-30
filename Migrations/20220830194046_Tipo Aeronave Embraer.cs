using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoeAirlines.Migrations
{
    public partial class TipoAeronaveEmbraer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celebridade",
                table: "Aeronaves");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Aeronaves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Aeronaves");

            migrationBuilder.AddColumn<string>(
                name: "Celebridade",
                table: "Aeronaves",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");
        }
    }
}
