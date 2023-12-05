using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzaOrderService
	{
		PizzaOrder? Save(PizzaOrder pizza);
		List<PizzaOrder> GetAll();

		PizzaOrder? Delete(int id);

		PizzaOrder? GetPizzaOrder(int id);
	}
}