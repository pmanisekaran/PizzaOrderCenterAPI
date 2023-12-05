using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using SQLitePCL;

namespace PizzaOrderCenterAPI.Services
{
	public static class OrderCalculator
	{


		public static void CalculateAndSetOrderTotal(PizzaOrder pizzaOrder, IPizzaOrderCenterDbContext context)
		{

			decimal total = 0m;
			foreach (PizzaOrderItem item in pizzaOrder.PizzaOrderItems)
			{
				decimal toppingPrice = 0m;
				var pizza = context.Pizzas.First(x => x.PizzaId == item.PizzaId);
				foreach (PizzaOrderItemTopping topping in item.PizzaOrderItemToppings)
				{
					var pizzaTopping = context.Toppings.First(x => x.PizzaToppingId == topping.PizzaToppingId);
					toppingPrice += pizzaTopping.PizzaToppingPrice * topping.Qty;
				}
				item.LineTotal = toppingPrice + (pizza.PizzaPrice * item.Qty);
				total += item.LineTotal;

			}
			pizzaOrder.OrderTotal = total;
		}
	}
}
