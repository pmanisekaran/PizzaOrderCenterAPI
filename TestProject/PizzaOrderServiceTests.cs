using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using System;

namespace TestProject
{
	public class PizzaOrderServiceTests
	{
		IPizzaOrderCenterDbContext _context;
		public PizzaOrderServiceTests() { 

			_context = new PizzaOrderCenterDbContext(
				new DbContextOptionsBuilder<PizzaOrderCenterDbContext>()
					.UseInMemoryDatabase("TestDatabase")
					.Options, null);
		}
		// SOME WORK NEEDS TO BE DONE HERE as MOCKING ALL DBCONTEXT is bit complex. It is work in progress

		// Test Save method when adding a new PizzaOrder
		[Fact]
		public void Save_NewPizzaOrder_ShouldAddToContext()
		{
			// Arrange
			
			var pizzaOrder = new PizzaOrder { PizzaOrderId = 1, PizzaOrderItems = new List<PizzaOrderItem>(), CustomerName = "XX", OrderTotal = 0m };
			var service = new PizzaOrderService(_context);
			
			// Act
			var result = service.Save(pizzaOrder);

			// Assert
	
			result.Should().Be(pizzaOrder);
			
			//remove
			service.Delete(1);
		}

		// Test Save method when updating an existing PizzaOrder
		[Fact]
		public void Save_ExistingPizzaOrder_ShouldUpdateInContext()
		{
			// Arrange
			
			var pizzaOrderItems = new List<PizzaOrderItem>();
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			var updatedPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			_context.PizzaOrders.Add(existingPizzaOrder);
			_context.Save();

			var service = new PizzaOrderService(_context);

			// Act
			var result = service.Save(updatedPizzaOrder);

			// Assert
			
			result.Should().Be(existingPizzaOrder);
			existingPizzaOrder.Should().BeEquivalentTo(updatedPizzaOrder);
			service.Delete(1);
		}

		// Test GetAll method
		[Fact]
		public void GetAll_ShouldReturnListOfPizzaOrders()
		{
			// Arrange
			
			var pizzaOrders = new List<PizzaOrder> { new PizzaOrder { PizzaOrderId = 1, OrderTotal = 0, CustomerName = "XX", PizzaOrderItems = new List<PizzaOrderItem>() }, new PizzaOrder { PizzaOrderId = 2, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = new List<PizzaOrderItem>() } };
			_context.PizzaOrders.AddRange(pizzaOrders);

			_context.Save();
			var service = new PizzaOrderService(_context);

			// Act
			var result = service.GetAll();

			// Assert
			result.Should().BeEquivalentTo(pizzaOrders);

			service.Delete(1);
			service.Delete(2);
		}

		// Test Delete method
		[Fact]
		public void Delete_ExistingPizzaOrder_ShouldRemoveFromContext()
		{
			// Arrange
			

			var pizzaOrderId = 1;
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "ZZ", PizzaOrderItems = new List<PizzaOrderItem>(), OrderTotal = 0 };
			_context.PizzaOrders.Add(existingPizzaOrder);
			_context.Save();

			var service = new PizzaOrderService(_context);

			// Act
			var result = service.Delete(pizzaOrderId);

			// Assert
			result.Should().Be(existingPizzaOrder);
		}

		// Test GetPizzaOrder method
		[Fact]
		public void GetPizzaOrder_ExistingPizzaOrder_ShouldReturnPizzaOrder()
		{
			// arange
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "aa", OrderTotal = 0m, PizzaOrderItems = new List<PizzaOrderItem>() };
			_context.PizzaOrders.Add(existingPizzaOrder);
			_context.Save();

			var pizzaOrderService = new PizzaOrderService(_context);
			// Act
			var result = pizzaOrderService.Delete(1);

			// Assert
			result.Should().NotBeNull();
			result.PizzaOrderId.Should().Be(1);

		}
	}
}
