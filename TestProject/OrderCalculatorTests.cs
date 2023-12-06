using Xunit;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Collections.Generic;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace TestProject
{
	public class OrderCalculatorTests
	{
		[Fact]
		public void CalculateAndSetOrderTotal_CalculatesCorrectly()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();

			var pizza1 = new Pizza { PizzaId = 1, PizzaPrice = 10m };
			var pizza2 = new Pizza { PizzaId = 2, PizzaPrice = 15m };

			var topping1 = new PizzaTopping { PizzaToppingId = 1, PizzaToppingPrice = 1m };
			var topping2 = new PizzaTopping { PizzaToppingId = 2, PizzaToppingPrice = 1m };

			var pizzas = new List<Pizza>()
			{
				pizza1,
				pizza2,
			};


			var toppings = new List<PizzaTopping>()
			{
				topping1,
				topping2,
			};

			//// create a mock DbSet exposing both DbSet and IQueryable interfaces for setup
			//var mockSetPizza = Substitute.For<DbSet<Pizza>, IQueryable<Pizza>>();
			//// setup all IQueryable methods using what you have from "data"
			//((IQueryable<Pizza>)mockSetPizza).Provider.Returns(pizzas.Provider);
			//((IQueryable<Pizza>)mockSetPizza).Expression.Returns(pizzas.Expression);
			//((IQueryable<Pizza>)mockSetPizza).ElementType.Returns(pizzas.ElementType);
			//((IQueryable<Pizza>)mockSetPizza).GetEnumerator().Returns(pizzas.GetEnumerator());

			//// create a mock DbSet exposing both DbSet and IQueryable interfaces for setup
			//var mockSetTopping= Substitute.For<DbSet<PizzaTopping>, IQueryable<PizzaTopping>>();
			//// setup all IQueryable methods using what you have from "data"
			//((IQueryable<PizzaTopping>)mockSetTopping).Provider.Returns(toppings.Provider);
			//((IQueryable<PizzaTopping>)mockSetTopping).Expression.Returns(toppings.Expression);
			//((IQueryable<PizzaTopping>)mockSetTopping).ElementType.Returns(toppings.ElementType);
			//((IQueryable<PizzaTopping>)mockSetTopping).GetEnumerator().Returns(toppings.GetEnumerator());




			var pizzaOrderItem1 = new PizzaOrderItem
			{
				PizzaId = 1,
				Qty = 2,
				PizzaOrderItemToppings = new List<PizzaOrderItemTopping>
			{
				new PizzaOrderItemTopping { PizzaToppingId = 1, Qty = 1 },
				new PizzaOrderItemTopping { PizzaToppingId = 2, Qty = 1 }
			}
			};

			var pizzaOrderItem2 = new PizzaOrderItem
			{
				PizzaId = 2,
				Qty = 1,
				PizzaOrderItemToppings = new List<PizzaOrderItemTopping>
			{
				new PizzaOrderItemTopping { PizzaToppingId = 2, Qty = 1 }
			}
			};

			var pizzaOrder = new PizzaOrder
			{
				PizzaOrderItems = new List<PizzaOrderItem> { pizzaOrderItem1, pizzaOrderItem2 }
			};

			// Act
			OrderCalculator.CalculateAndSetOrderTotal(pizzaOrder, pizzas, toppings);

			// Assert
			pizzaOrder.OrderTotal.Should().Be(38m); // Expected total based on the provided data
			pizzaOrder.PizzaOrderItems[0].LineTotal.Should().Be(22m); // Expected line total for first item
			pizzaOrder.PizzaOrderItems[1].LineTotal.Should().Be(16m); // Expected line total for second item
		}

		// Negative test case for CalculateAndSetOrderTotal method with empty PizzaOrderItems
		[Fact]
		public void CalculateAndSetOrderTotal_EmptyPizzaOrderItems_ShouldNotCalculateOrderTotal()
		{
			// Arrange
			var pizzaOrder = new PizzaOrder { PizzaOrderItems = new List<PizzaOrderItem>() };
			var pizza1 = new Pizza { PizzaId = 1, PizzaPrice = 10m };
			var pizza2 = new Pizza { PizzaId = 2, PizzaPrice = 15m };

			var topping1 = new PizzaTopping { PizzaToppingId = 1, PizzaToppingPrice = 1m };
			var topping2 = new PizzaTopping { PizzaToppingId = 2, PizzaToppingPrice = 1m };

			var pizzas = new List<Pizza>()
			{
				pizza1,
				pizza2,
			};


			var toppings = new List<PizzaTopping>()
			{
				topping1,
				topping2,
			};

			// Mock the context using NSubstitute
			var context = Substitute.For<IPizzaOrderCenterDbContext>();

			// Act
			OrderCalculator.CalculateAndSetOrderTotal(pizzaOrder, pizzas, toppings);

			// Assert
			pizzaOrder.OrderTotal.Should().Be(0); // The total should remain 0 for an empty list
		}
	}
}
