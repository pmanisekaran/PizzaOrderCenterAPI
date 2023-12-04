using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzeriaService
	{
		Pizzeria? Add(Pizzeria pizzeria);
		List<Pizzeria> GetAll();
	}
}