using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzeriaMenuService
	{
		Task<Pizza?> Save(Pizza pizza);
		Task<List<Pizza>> GetAll();

		Task<Pizza?> Delete(int id);

		Task<Pizza?> GetPizza(int id);
	}
}