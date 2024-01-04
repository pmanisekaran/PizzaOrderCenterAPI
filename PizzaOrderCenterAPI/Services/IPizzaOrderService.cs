using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzaOrderService
	{
		Task<PizzaOrder?> Save(PizzaOrder pizza);
		Task<List<PizzaOrder>> GetAll();

		Task<PizzaOrder?> Delete(int id);

		Task<PizzaOrder?> GetPizzaOrder(int id);
	}
}