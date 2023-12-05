using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzaToppingService
	{
		PizzaTopping? Save(PizzaTopping pizza);
		List<PizzaTopping> GetAll();

		PizzaTopping? Delete(int id);

		PizzaTopping? GetPizzaTopping(int id);
	}
}