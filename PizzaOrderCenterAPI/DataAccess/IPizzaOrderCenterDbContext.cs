using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.DataAccess
{
	public interface IPizzaOrderCenterDbContext
	{
	public	DbSet<Pizzeria> Pizzerias { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		public DbSet<PizzaTopping> Toppings { get; set; }

		public DbSet<PizzaOrder> PizzaOrders { get; set; }
		public DbSet<PizzaOrderItem> PizzaOrderItems { get; set; }

		public DbSet<PizzaOrderItemTopping> PizzaOrderItemToppings { get; set; }

		public void Save();
		
	}
}