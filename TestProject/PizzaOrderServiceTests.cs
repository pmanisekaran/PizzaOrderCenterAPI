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

namespace TestProject
{
	public class PizzaOrderServiceTests
	{
		// SOME WORK NEEDS TO BE DONE HERE as MOCKING ALL DBCONTEXT is bit complex. It is work in progress

		// Test Save method when adding a new PizzaOrder
		[Fact]
		public void Save_NewPizzaOrder_ShouldAddToContext()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();
			var pizzaOrder = new PizzaOrder { PizzaOrderId = 1, PizzaOrderItems = new List<PizzaOrderItem>(), CustomerName = "XX", OrderTotal = 0m };
			var service = new PizzaOrderService(context);

			// Act
			var result = service.Save(pizzaOrder);

			// Assert
			context.Received(1).PizzaOrders.Add(pizzaOrder);
			context.Received(1).Save();
			result.Should().Be(pizzaOrder);
		}

		// Test Save method when updating an existing PizzaOrder
		[Fact]
		public void Save_ExistingPizzaOrder_ShouldUpdateInContext()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();
			var pizzaOrderItems = new List<PizzaOrderItem>();
			var existingPizzaOrder = new PizzaOrder { PizzaOrderId = 11, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			var updatedPizzaOrder = new PizzaOrder { PizzaOrderId = 11, CustomerName = "XX", OrderTotal = 0, PizzaOrderItems = pizzaOrderItems };
			context.PizzaOrders.SingleOrDefault(Arg.Any<System.Linq.Expressions.Expression<System.Func<PizzaOrder, bool>>>())
				.Returns(existingPizzaOrder);

			var service = new PizzaOrderService(context);

			// Act
			var result = service.Save(updatedPizzaOrder);

			// Assert
			context.Received(1).Save();
			result.Should().Be(existingPizzaOrder);
			existingPizzaOrder.Should().BeEquivalentTo(updatedPizzaOrder);
		}

		// Test GetAll method
		[Fact]
		public void GetAll_ShouldReturnListOfPizzaOrders()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();
			var pizzaOrders = new List<PizzaOrder> { new PizzaOrder { PizzaOrderId =1, OrderTotal= 0, CustomerName="XX", PizzaOrderItems = new List<PizzaOrderItem>() }, new PizzaOrder { PizzaOrderId=2, CustomerName="AA", OrderTotal=0, PizzaOrderItems = new List<PizzaOrderItem>() } };
			context.PizzaOrders
				//.Include(Arg.Any<System.Linq.Expressions.Expression<System.Func<PizzaOrder, object>>>())
				//.ThenInclude(Arg.Any<System.Linq.Expressions.Expression<System.Func<PizzaOrderItem, object>>>())
				.ToList()
				.Returns(pizzaOrders);

			var service = new PizzaOrderService(context);

			// Act
			var result = service.GetAll();

			// Assert
			result.Should().BeEquivalentTo(pizzaOrders);
		}

		// Test Delete method
		[Fact]
		public void Delete_ExistingPizzaOrder_ShouldRemoveFromContext()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();
			var pizzaOrderId = 1;
			var existingPizzaOrder = new PizzaOrder {  PizzaOrderId=1, CustomerName= "ZZ", PizzaOrderItems= new List<PizzaOrderItem>(), OrderTotal=0 };
			context.PizzaOrders.FirstOrDefault(Arg.Any<System.Linq.Expressions.Expression<System.Func<PizzaOrder, bool>>>())
				.Returns(existingPizzaOrder);

			var service = new PizzaOrderService(context);

			// Act
			var result = service.Delete(pizzaOrderId);

			// Assert
			context.Received(1).PizzaOrders.Remove(existingPizzaOrder);
			context.Received(1).Save();
			result.Should().Be(existingPizzaOrder);
		}

		// Test GetPizzaOrder method
		[Fact]
		public void GetPizzaOrder_ExistingPizzaOrder_ShouldReturnPizzaOrder()
		{
			// Arrange
			var context = Substitute.For<IPizzaOrderCenterDbContext>();
			var pizzaOrderId = 1;
			var existingPizzaOrder = new PizzaOrder {  PizzaOrderId=1, OrderTotal= 0, CustomerName= "ZZ", PizzaOrderItems = new List<PizzaOrderItem>() };
			context.PizzaOrders.FirstOrDefault(Arg.Any<System.Linq.Expressions.Expression<System.Func<PizzaOrder, bool>>>())
				.Returns(existingPizzaOrder);

			var service = new PizzaOrderService(context);

			// Act
			var result = service.GetPizzaOrder(pizzaOrderId);

			// Assert
			result.Should().Be(existingPizzaOrder);
		}
	}
}
