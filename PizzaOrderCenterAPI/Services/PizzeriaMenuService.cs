using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzeriaMenuService : IPizzeriaMenuService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzeriaMenuService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public async Task<Pizza?> Save(Pizza pizza)
		{
			var existingPizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == pizza.PizzaId);
			if (existingPizza != null)
			{
				existingPizza.PizzaId = pizza.PizzaId;
				existingPizza.PizzaName = pizza.PizzaName;
				existingPizza.PizzaPrice = pizza.PizzaPrice;
			}
			else
				await _context.Pizzas.AddAsync(pizza);
			_context.Save();
			return await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == pizza.PizzaId);
		}

		public async Task<List<Pizza>> GetAll()
		{
			return await _context.Pizzas.ToListAsync();
		}

		public async Task<Pizza?> Delete(int pizzaId)
		{
			var Pizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == pizzaId);
			if (Pizza != null)
			{
				_context.Pizzas.Remove(Pizza);
				_context.Save();
			}
			return Pizza;
		}

		public async Task<Pizza?> GetPizza(int pizzaId)
		{
			return await _context.Pizzas.FirstOrDefaultAsync(x => x.PizzaId == pizzaId);
		}

	}
}
