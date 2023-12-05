using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using SQLitePCL;

namespace PizzaOrderCenterAPI.Services
{
	public static class OrderCalculator
	{


		public static void CalculateAndSetOrderTotal(PizzaOrder pizzaOrder, List<Pizza> pizzas, List<PizzaTopping> toppings)
		{

			decimal total = 0m;
			foreach (PizzaOrderItem item in pizzaOrder.PizzaOrderItems)
			{
				decimal toppingPrice = 0m;
				var pizza = pizzas.First(x => x.PizzaId == item.PizzaId);
				foreach (PizzaOrderItemTopping topping in item.PizzaOrderItemToppings)
				{
					var pizzaTopping = toppings.First(x => x.PizzaToppingId == topping.PizzaToppingId);
					toppingPrice += pizzaTopping.PizzaToppingPrice * topping.Qty;
				}
				item.LineTotal = toppingPrice + (pizza.PizzaPrice * item.Qty);
				total += item.LineTotal;

			}
			pizzaOrder.OrderTotal = total;
		}
	}
}
