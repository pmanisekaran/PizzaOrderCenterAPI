using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzeriaMenuService : IPizzeriaMenuService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzeriaMenuService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public Pizza? Save(Pizza pizza)
		{
			var existingPizza = _context.Pizzas.FirstOrDefault(x => x.PizzaId == pizza.PizzaId);
			if (existingPizza != null)
			{
				existingPizza.PizzaId = pizza.PizzaId;
				existingPizza.PizzaName = pizza.PizzaName;
				existingPizza.PizzaPrice = pizza.PizzaPrice;
			}
			else
				_context.Pizzas.Add(pizza);
			_context.Save();
			return _context.Pizzas.FirstOrDefault(x => x.PizzaId == pizza.PizzaId);
		}

		public List<Pizza> GetAll()
		{
			return 	_context.Pizzas.ToList();
		}

		public Pizza? Delete(int pizzaId)
		{ 
			var Pizza = _context.Pizzas.FirstOrDefault(x => x.PizzaId == pizzaId);
			if (Pizza != null)
			{
				_context.Pizzas.Remove(Pizza);
				_context.Save();
			}
			return Pizza;
			



		}

		public Pizza? GetPizza(int pizzaId) {

			return _context.Pizzas.FirstOrDefault(x => x.PizzaId == pizzaId);
		}

	}
}
