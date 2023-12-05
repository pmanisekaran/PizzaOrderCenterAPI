using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzaToppingService : IPizzaToppingService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzaToppingService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public PizzaTopping? Save(PizzaTopping PizzaTopping)
		{
			var existingPizzaTopping = _context.Toppings.FirstOrDefault(x => x.PizzaToppingId == PizzaTopping.PizzaToppingId);
			if (existingPizzaTopping != null)
			{
				existingPizzaTopping.PizzaToppingId = PizzaTopping.PizzaToppingId;
				existingPizzaTopping.PizzaToppingName = PizzaTopping.PizzaToppingName;
				
			}
			else
				_context.Toppings.Add(PizzaTopping);
			_context.Save();
			return _context.Toppings.FirstOrDefault(x => x.PizzaToppingId == PizzaTopping.PizzaToppingId);
		}

		public List<PizzaTopping> GetAll()
		{
			return 	_context.Toppings.ToList();
		}

		public PizzaTopping? Delete(int pizzaToppingId)
		{ 
			var PizzaTopping = _context.Toppings.FirstOrDefault(x => x.PizzaToppingId == pizzaToppingId);
			if (PizzaTopping != null)
			{
				_context.Toppings.Remove(PizzaTopping);
				_context.Save();
			}
			return PizzaTopping;
			



		}

		public PizzaTopping? GetPizzaTopping(int PizzaToppingId) {

			return _context.Toppings.FirstOrDefault(x => x.PizzaToppingId == PizzaToppingId);
		}

	}
}
