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
			//skipping topping for now
			// you cannot delete items from existing order when you update

			var existingPizzaOrder = _context.PizzaOrders
									.Where(x => x.PizzaOrderId == pizzaOrder.PizzaOrderId)
									.Include(x=>x.PizzaOrderItems)
									.SingleOrDefault();
									
			if (existingPizzaOrder != null)
			{
				
				
				existingPizzaOrder.PizzaOrderId = pizzaOrder.PizzaOrderId;
				existingPizzaOrder.CustomerName = Guid.NewGuid().ToString();
				foreach (var item in pizzaOrder.PizzaOrderItems)
				{
					var existingItem = existingPizzaOrder.PizzaOrderItems.FirstOrDefault(x => x.PizzaOrderItemId == x.PizzaOrderItemId);
					if (existingItem != null)
					{
						existingItem.Qty = item.Qty;
						existingItem.PizzaId = item.PizzaId;
					}
					else
					{ 
						existingPizzaOrder.PizzaOrderItems.Add(item);
					}
				}
			
				
				
			}
			else
				_context.PizzaOrders.Add(pizzaOrder);
			
			pizzaOrder = existingPizzaOrder == null ? pizzaOrder : existingPizzaOrder;

			OrderCalculator.CalculateAndSetOrderTotal(pizzaOrder, _context.Pizzas.ToList(), _context.Toppings.ToList());
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
