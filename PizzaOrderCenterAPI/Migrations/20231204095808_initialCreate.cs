using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaOrderCenterAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaOrderItems",
                columns: table => new
                {
                    PizzaOrderItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false),
                    LineTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    PizzaOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrderItems", x => x.PizzaOrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrderItemToppings",
                columns: table => new
                {
                    PizzaOrderItemToppingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzaToppingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false),
                    PizzaOrderItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToppingLineItemTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrderItemToppings", x => x.PizzaOrderItemToppingId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrders",
                columns: table => new
                {
                    PizzaOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrders", x => x.PizzaOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzaName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PizzeriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PizzaPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzerias",
                columns: table => new
                {
                    PizzeriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzeriaName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzerias", x => x.PizzeriaId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    PizzaToppingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PizzaToppingName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.PizzaToppingId);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "PizzaName", "PizzaPrice", "PizzeriaId" },
                values: new object[,]
                {
                    { 1, "Capricciosa", 20.0m, 1 },
                    { 2, "Mexicana", 20.0m, 1 },
                    { 3, "Margherita", 20.0m, 1 },
                    { 4, "Vegetarian", 20.0m, 2 },
                    { 5, "Capricciosa", 20.0m, 2 },
                    { 6, "Super Supreme", 20.0m, 3 },
                    { 7, "The Lot", 20.0m, 3 },
                    { 8, "Meat Lover", 20.0m, 4 },
                    { 9, "Cheese Pizza", 20.0m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Pizzerias",
                columns: new[] { "PizzeriaId", "Location", "PizzeriaName" },
                values: new object[,]
                {
                    { 1, "Preston", "Preston Pizzeria" },
                    { 2, "South Bank", "South Bank Pizzeria" },
                    { 3, "Mulgrave", "Mulgrave Pizzeria" },
                    { 4, "Mulgrave", "Mulgrave East Pizzeria" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "PizzaToppingId", "PizzaToppingName" },
                values: new object[,]
                {
                    { 1, "Cheese" },
                    { 2, "Capsicum" },
                    { 3, "Salami" },
                    { 4, "Olives" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrderItems");

            migrationBuilder.DropTable(
                name: "PizzaOrderItemToppings");

            migrationBuilder.DropTable(
                name: "PizzaOrders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Pizzerias");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
