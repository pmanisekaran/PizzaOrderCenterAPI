using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzaToppingService : IPizzaToppingService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzaToppingService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public async  Task<PizzaTopping?> Save(PizzaTopping PizzaTopping)
		{
			var existingPizzaTopping = await _context.Toppings.FirstOrDefaultAsync(x => x.PizzaToppingId == PizzaTopping.PizzaToppingId);
			if (existingPizzaTopping != null)
			{
				existingPizzaTopping.PizzaToppingId = PizzaTopping.PizzaToppingId;
				existingPizzaTopping.PizzaToppingName = PizzaTopping.PizzaToppingName;
				
			}
			else
				await _context.Toppings.AddAsync(PizzaTopping);
			_context.Save();
			return await _context.Toppings.FirstOrDefaultAsync(x => x.PizzaToppingId == PizzaTopping.PizzaToppingId);
		}

		public async Task<List<PizzaTopping>> GetAll()
		{
			return 	await _context.Toppings.ToListAsync();
		}

		public async Task<PizzaTopping?> Delete(int pizzaToppingId)
		{ 
			var PizzaTopping = await _context.Toppings.FirstOrDefaultAsync(x => x.PizzaToppingId == pizzaToppingId);
			if (PizzaTopping != null)
			{
				_context.Toppings.Remove(PizzaTopping);
				_context.Save();
			}
			return PizzaTopping;
			



		}

		public async Task<PizzaTopping?> GetPizzaTopping(int PizzaToppingId) {

			return await _context.Toppings.FirstOrDefaultAsync(x => x.PizzaToppingId == PizzaToppingId);
		}

	}
}
