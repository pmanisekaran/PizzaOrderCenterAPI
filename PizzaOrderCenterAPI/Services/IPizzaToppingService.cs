using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzaToppingService
	{
		Task<PizzaTopping?> Save(PizzaTopping pizza);
		Task<List<PizzaTopping>> GetAll();

		Task<PizzaTopping?> Delete(int id);

		Task<PizzaTopping?> GetPizzaTopping(int id);
	}
}