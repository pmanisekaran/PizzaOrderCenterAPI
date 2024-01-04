using FluentAssertions;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace TestProject
{
	public class PizzaOrderServiceTests
	{
		IPizzaOrderCenterDbContext _context;
		public PizzaOrderServiceTests() { 

			_context = new PizzaOrderCenterDbContext(
				new DbContextOptionsBuilder<PizzaOrderCenterDbContext>()
					.UseInMemoryDatabase("TestDatabase")
					.Options);
		}
		// SOME WORK NEEDS TO BE DONE HERE as MOCKING ALL DBCONTEXT is bit complex. It is work in progress

		// Test Save method when adding a new PizzaOrder
		[Fact]
		public async void Save_NewPizzaOrder_ShouldAddToContext()
		{
			// Arrange
			
			var pizzaOrder = new PizzaOrder { PizzaOrderId = new Random().Next(0,int.MaxValue), PizzaOrderItems = new List<PizzaOrderItem>(), CustomerName = "XX", OrderTotal = 0m };
			var service = new PizzaOrderService(_context);
			
			// Act
			var result = await service.Save(pizzaOrder);

			// Assert
	
			result.Should().Be(pizzaOrder);
			
			//remove
			await service.Delete(pizzaOrder.PizzaOrderId);
		}

		// Test Save method when updating an existing PizzaOrder
		[Fact]
		public async void Save_ExistingPizzaOrder_ShouldUpdateInContext()
		{
			// Arrange
			
			var pizzaOrderItems = new List<PizzaOrderItem>();
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			var updatedPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			await _context.PizzaOrders.AddAsync(existingPizzaOrder);
			_context.Save();

			var service = new PizzaOrderService(_context);

			// Act
			var result = await service.Save(updatedPizzaOrder);

			// Assert
			
			result.Should().Be(existingPizzaOrder);
			existingPizzaOrder.Should().BeEquivalentTo(updatedPizzaOrder);
			await service.Delete(1);
		}

		// Test GetAll method
		[Fact]
		public async void GetAll_ShouldReturnListOfPizzaOrders()
		{
			// Arrange
			
			var pizzaOrders = new List<PizzaOrder> { new PizzaOrder { PizzaOrderId = new Random().Next(0,int.MaxValue), OrderTotal = 0, CustomerName = "XX", PizzaOrderItems = new List<PizzaOrderItem>() }, new PizzaOrder { PizzaOrderId = new Random().Next(0,int.MaxValue), CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = new List<PizzaOrderItem>() } };
			_context.PizzaOrders.AddRange(pizzaOrders);

			_context.Save();
			var service = new PizzaOrderService(_context);

			// Act
			var result = await service.GetAll();

			// Assert
			result.Should().BeEquivalentTo(pizzaOrders);

			await service.Delete(pizzaOrders[0].PizzaOrderId);
			await service.Delete(pizzaOrders[1].PizzaOrderId);
		}

		// Test Delete method
		[Fact]
		public async void Delete_ExistingPizzaOrder_ShouldRemoveFromContext()
		{
			// Arrange
			

			var pizzaOrderId = new System.Random().Next(0, int.MaxValue);
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = pizzaOrderId, CustomerName = "ZZ", PizzaOrderItems = new List<PizzaOrderItem>(), OrderTotal = 0 };
			_context.PizzaOrders.Add(existingPizzaOrder);
			_context.Save();

			var service = new PizzaOrderService(_context);

			// Act
			var result = await service.Delete(pizzaOrderId);

			// Assert
			result.Should().Be(existingPizzaOrder);
		}

		// Test GetPizzaOrder method
		[Fact]
		public async  void GetPizzaOrder_ExistingPizzaOrder_ShouldReturnPizzaOrder()
		{
			// arange
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 1, CustomerName = "aa", OrderTotal = 0m, PizzaOrderItems = new List<PizzaOrderItem>() };
			_context.PizzaOrders.Add(existingPizzaOrder);
			_context.Save();

			var pizzaOrderService = new PizzaOrderService(_context);
			// Act
			var result = await pizzaOrderService.Delete(1);

			// Assert
			result.Should().NotBeNull();
			result.PizzaOrderId.Should().Be(1);

		}
	}
}
