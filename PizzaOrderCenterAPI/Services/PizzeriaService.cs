using PizzaOrderCenterAPI.DataAccess;
using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public class PizzeriaService : IPizzeriaService
	{
		private IPizzaOrderCenterDbContext _context;
		public PizzeriaService(IPizzaOrderCenterDbContext pizzaOrderCenterDbContext) => _context = pizzaOrderCenterDbContext;

		public Pizzeria? Add(Pizzeria pizzeria)
		{
			_context.Pizzerias.Add(pizzeria);
			_context.Save();
			return _context.Pizzerias.FirstOrDefault(x => x.PizzeriaId == pizzeria.PizzeriaId);
		}

		public List<Pizzeria> GetAll() => _context.Pizzerias.ToList();


	}
}
