using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.Models;
using System.Reflection.Emit;

namespace PizzaOrderCenterAPI.DataAccess
{
	public class PizzaOrderCenterDbContext : DbContext, IPizzaOrderCenterDbContext
	{
	
		public DbSet<Pizzeria> Pizzerias { get; set; }
		public DbSet<Pizza> Pizzas { get; set; }
		public DbSet<PizzaTopping> Toppings { get; set; }

		public DbSet<PizzaOrder> PizzaOrders { get; set; }
		public DbSet<PizzaOrderItem> PizzaOrderItems { get; set; }

		public DbSet<PizzaOrderItemTopping> PizzaOrderItemToppings { get; set; }

		public PizzaOrderCenterDbContext(DbContextOptions<PizzaOrderCenterDbContext> options) : base(options)
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SeedInitialData(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private void SeedInitialData(ModelBuilder modelBuilder)
		{
			SeedPizzeria(modelBuilder);
			SeedPizzas(modelBuilder);
			SeedToppings(modelBuilder);
			SeedPizzaOrder(modelBuilder);
			SeedPizzaOrderItems(modelBuilder);
			SeedPizzaOrderItemToppings(modelBuilder);

		}


		private static void SeedPizzaOrder(ModelBuilder modelBuilder)
		{
			List<PizzaOrder> toppings = new List<PizzaOrder>()
			{
				new PizzaOrder {  PizzaOrderId=1, CustomerName ="some name", OrderTotal=0m },
				new PizzaOrder { PizzaOrderId=2, CustomerName ="some name 2", OrderTotal=0m },
			};

			modelBuilder.Entity<PizzaOrder>().HasData(toppings);
		}

		private static void SeedPizzaOrderItems(ModelBuilder modelBuilder)
		{
			List<PizzaOrderItem> pizzaOrderItems = new List<PizzaOrderItem>()
			{
				new PizzaOrderItem { PizzaOrderItemId=1, PizzaId =1, PizzaOrderId=1, Qty =2  },
				new PizzaOrderItem { PizzaOrderItemId=2, PizzaId =2, PizzaOrderId=1, Qty =2  },
				new PizzaOrderItem { PizzaOrderItemId=3, PizzaId =3, PizzaOrderId=1, Qty =3  },
			};

			modelBuilder.Entity<PizzaOrderItem>().HasData(pizzaOrderItems);
		}

		private static void SeedPizzaOrderItemToppings(ModelBuilder modelBuilder)
		{
			List<PizzaOrderItemTopping> pizzaOrderItemsTopping = new List<PizzaOrderItemTopping>()
			{
				new PizzaOrderItemTopping {  PizzaOrderItemToppingId =1, PizzaOrderItemId =1, PizzaToppingId=1, Qty=2},
				new PizzaOrderItemTopping {  PizzaOrderItemToppingId =2, PizzaOrderItemId =1, PizzaToppingId=2, Qty=2},
				new PizzaOrderItemTopping {  PizzaOrderItemToppingId =3, PizzaOrderItemId =2, PizzaToppingId=3, Qty=2},
			};

			modelBuilder.Entity<PizzaOrderItemTopping>().HasData(pizzaOrderItemsTopping);
		}

		private static void SeedToppings(ModelBuilder modelBuilder)
		{
			List<PizzaTopping> toppings = new List<PizzaTopping>()
			{
				new PizzaTopping { PizzaToppingId =1, PizzaToppingName= "Cheese" },
				new PizzaTopping { PizzaToppingId =2, PizzaToppingName= "Capsicum" },
				new PizzaTopping { PizzaToppingId =3, PizzaToppingName= "Salami" },
				new PizzaTopping { PizzaToppingId =4, PizzaToppingName= "Olives" },
			};
			modelBuilder.Entity<PizzaTopping>().HasData(toppings);
		}

		private static void SeedPizzas(ModelBuilder modelBuilder)
		{
			List<Pizza> pizzas = new List<Pizza>() {
				new Pizza {  PizzaId =1, PizzaName="Capricciosa", PizzaPrice= 20.0m, PizzeriaId= 1  },
				new Pizza {  PizzaId =2, PizzaName="Mexicana", PizzaPrice= 20.0m, PizzeriaId= 1  },
				new Pizza {  PizzaId =3, PizzaName="Margherita", PizzaPrice= 20.0m, PizzeriaId= 1  },
				new Pizza {  PizzaId =4, PizzaName="Vegetarian", PizzaPrice= 20.0m, PizzeriaId= 2  },
				new Pizza {  PizzaId =5, PizzaName="Capricciosa", PizzaPrice= 20.0m, PizzeriaId= 2  },
				new Pizza {  PizzaId =6, PizzaName="Super Supreme", PizzaPrice= 20.0m, PizzeriaId= 3  },
				new Pizza {  PizzaId =7, PizzaName="The Lot", PizzaPrice= 20.0m, PizzeriaId= 3  },
				new Pizza {  PizzaId =8, PizzaName="Meat Lover", PizzaPrice= 20.0m, PizzeriaId= 4  },
				new Pizza {  PizzaId =9, PizzaName="Cheese Pizza", PizzaPrice= 20.0m, PizzeriaId= 4  },
			};
			modelBuilder.Entity<Pizza>().HasData(pizzas);
		}

		private void SeedPizzeria(ModelBuilder modelBuilder)
		{
			List<Pizzeria> pizzerias = new List<Pizzeria>() {
				new Pizzeria { PizzeriaId =1,  PizzeriaName = "Preston Pizzeria", Location = "Preston" },
				new Pizzeria { PizzeriaId =2, PizzeriaName = "South Bank Pizzeria", Location = "South Bank" },
				new Pizzeria { PizzeriaId =3, PizzeriaName = "Mulgrave Pizzeria", Location = "Mulgrave" },
				new Pizzeria { PizzeriaId =4, PizzeriaName = "Mulgrave East Pizzeria", Location = "Mulgrave" }
			};
			modelBuilder.Entity<Pizzeria>().HasData(pizzerias);
		}

		public void Save()
		{
			this.SaveChanges();
		}
	}
}
