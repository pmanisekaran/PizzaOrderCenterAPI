using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzeriaService : IPizzeriaService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzeriaService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public async Task<Pizzeria?> Save(Pizzeria pizzeria)
		{
			var existingPizzeria = await _context.Pizzerias.FirstOrDefaultAsync(x => x.PizzeriaId == pizzeria.PizzeriaId);
			if (existingPizzeria != null)
			{
				existingPizzeria.PizzeriaId = pizzeria.PizzeriaId;
				existingPizzeria.PizzeriaName = pizzeria.PizzeriaName;
				existingPizzeria.Location = pizzeria.Location;
			}
			else
				await _context.Pizzerias.AddAsync(pizzeria);
			_context.Save();
			return await _context.Pizzerias.FirstOrDefaultAsync(x => x.PizzeriaId == pizzeria.PizzeriaId);
		}

		public async  Task<List<Pizzeria>> GetAll()
		{
			return 	await _context.Pizzerias
							.Include(pizzeria => pizzeria.Pizzas)
							.ToListAsync();
		}

		public async Task< Pizzeria?> Delete(int pizzeriaId)
		{ 
			var pizzeria = await _context.Pizzerias.FirstOrDefaultAsync(x => x.PizzeriaId == pizzeriaId);
			if (pizzeria != null)
			{
				_context.Pizzerias.Remove(pizzeria);
				_context.Save();
			}
			return pizzeria;
			



		}

		public async Task< Pizzeria?> GetPizzeria(int pizzeriaId) {

			return await _context.Pizzerias.FirstOrDefaultAsync(x => x.PizzeriaId == pizzeriaId);
		}

	}
}
