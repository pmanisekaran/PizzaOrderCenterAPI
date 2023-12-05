using Microsoft.EntityFrameworkCore;
using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzeriaService : IPizzeriaService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzeriaService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public Pizzeria? Save(Pizzeria pizzeria)
		{
			var existingPizzeria = _context.Pizzerias.FirstOrDefault(x => x.PizzeriaId == pizzeria.PizzeriaId);
			if (existingPizzeria != null)
			{
				existingPizzeria.PizzeriaId = pizzeria.PizzeriaId;
				existingPizzeria.PizzeriaName = pizzeria.PizzeriaName;
				existingPizzeria.Location = pizzeria.Location;
			}
			else
				_context.Pizzerias.Add(pizzeria);
			_context.Save();
			return _context.Pizzerias.FirstOrDefault(x => x.PizzeriaId == pizzeria.PizzeriaId);
		}

		public List<Pizzeria> GetAll()
		{
			return 	_context.Pizzerias
							.Include(pizzeria => pizzeria.Pizzas)
							.ToList();
		}

		public Pizzeria? Delete(int pizzeriaId)
		{ 
			var pizzeria = _context.Pizzerias.FirstOrDefault(x => x.PizzeriaId == pizzeriaId);
			if (pizzeria != null)
			{
				_context.Pizzerias.Remove(pizzeria);
				_context.Save();
			}
			return pizzeria;
			



		}

		public Pizzeria? GetPizzeria(int pizzeriaId) {

			return _context.Pizzerias.FirstOrDefault(x => x.PizzeriaId == pizzeriaId);
		}

	}
}
