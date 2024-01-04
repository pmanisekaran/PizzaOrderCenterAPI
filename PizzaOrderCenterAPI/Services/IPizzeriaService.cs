using PizzaOrderCenterAPI.Models;

namespace PizzaOrderCenterAPI.Services
{
	public interface IPizzeriaService
	{
		Task<Pizzeria?> Save(Pizzeria pizzeria);
		Task<List<Pizzeria>> GetAll();

		Task<Pizzeria?> Delete(int id);

		Task<Pizzeria?> GetPizzeria(int id);
	}
}