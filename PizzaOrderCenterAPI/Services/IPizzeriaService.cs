using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzeriaService
	{
		Pizzeria? Save(Pizzeria pizzeria);
		List<Pizzeria> GetAll();

		Pizzeria? Delete(int id);

		Pizzeria? GetPizzeria(int id);
	}
}