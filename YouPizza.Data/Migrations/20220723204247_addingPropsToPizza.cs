using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouPizza.Data.Migrations
{
    public partial class addingPropsToPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alergens",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price30",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price40",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price50",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alergens",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price30",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price40",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price50",
                table: "Pizzas");
        }
    }
}
