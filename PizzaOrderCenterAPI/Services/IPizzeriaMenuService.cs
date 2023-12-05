using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzeriaMenuService
	{
		Pizza? Save(Pizza pizza);
		List<Pizza> GetAll();

		Pizza? Delete(int id);

		Pizza? GetPizza(int id);
	}
}