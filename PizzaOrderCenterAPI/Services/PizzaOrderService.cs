using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzaOrderService : IPizzaOrderService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzaOrderService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public async Task<PizzaOrder?> Save(PizzaOrder pizzaOrder)
		{
			//skipping topping for now
			// you cannot delete items from existing order when you update

			var existingPizzaOrder = await _context.PizzaOrders
									.Where(x => x.PizzaOrderId == pizzaOrder.PizzaOrderId)
									.Include(x=>x.PizzaOrderItems)
									.SingleOrDefaultAsync();
									
			if (existingPizzaOrder != null)
			{
				
				
				existingPizzaOrder.PizzaOrderId = pizzaOrder.PizzaOrderId;
				existingPizzaOrder.CustomerName = pizzaOrder.CustomerName== null ? "XX" :pizzaOrder.CustomerName;
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
			await 	_context.PizzaOrders.AddAsync(pizzaOrder);
			
			pizzaOrder = existingPizzaOrder == null ? pizzaOrder : existingPizzaOrder;

			OrderCalculator.CalculateAndSetOrderTotal(pizzaOrder, _context.Pizzas.ToList(), _context.Toppings.ToList());
			_context.Save();
			return await _context.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderId == pizzaOrder.PizzaOrderId);
		}

		public async Task<List<PizzaOrder>> GetAll()
		{
			return  await _context.PizzaOrders
					.Include(order=> order.PizzaOrderItems)
					.ThenInclude(item=> item.PizzaOrderItemToppings)
					.ToListAsync();
		}

		public async Task<PizzaOrder?> Delete(int pizzaOrderId)
		{ 
			var pizzaOrder = await _context.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderId == pizzaOrderId);
			if (pizzaOrder != null)
			{
				_context.PizzaOrders.Remove(pizzaOrder);
				_context.Save();
			}
			return pizzaOrder;
			



		}

		public async Task<PizzaOrder?> GetPizzaOrder(int PizzaOrderId) {

			return await _context.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderId == PizzaOrderId);
		}

	}
}
