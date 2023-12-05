using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzaOrderService : IPizzaOrderService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzaOrderService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public PizzaOrder? Save(PizzaOrder pizzaOrder)
		{
			var existingPizzaOrder = _context.PizzaOrders
									.Where(x => x.PizzaOrderId == pizzaOrder.PizzaOrderId)
									.Include(x=>x.PizzaOrderItems)
									.SingleOrDefault();
									
			if (existingPizzaOrder != null)
			{
				
				
				existingPizzaOrder.PizzaOrderId = pizzaOrder.PizzaOrderId;
				existingPizzaOrder.CustomerName = Guid.NewGuid().ToString();
				existingPizzaOrder.PizzaOrderItems = pizzaOrder.PizzaOrderItems;
				
				
			}
			else
				_context.PizzaOrders.Add(pizzaOrder);
			
			pizzaOrder = existingPizzaOrder == null ? pizzaOrder : existingPizzaOrder;

			OrderCalculator.CalculateAndSetOrderTotal(pizzaOrder, _context);
			_context.Save();
			return _context.PizzaOrders.FirstOrDefault(x => x.PizzaOrderId == pizzaOrder.PizzaOrderId);
		}

		public List<PizzaOrder> GetAll()
		{
			return 	_context.PizzaOrders
					.Include(order=> order.PizzaOrderItems)
					.ThenInclude(item=> item.PizzaOrderItemToppings)
					.ToList();
		}

		public PizzaOrder? Delete(int pizzaOrderId)
		{ 
			var pizzaOrder = _context.PizzaOrders.FirstOrDefault(x => x.PizzaOrderId == pizzaOrderId);
			if (pizzaOrder != null)
			{
				_context.PizzaOrders.Remove(pizzaOrder);
				_context.Save();
			}
			return pizzaOrder;
			



		}

		public PizzaOrder? GetPizzaOrder(int PizzaOrderId) {

			return _context.PizzaOrders.FirstOrDefault(x => x.PizzaOrderId == PizzaOrderId);
		}

	}
}
