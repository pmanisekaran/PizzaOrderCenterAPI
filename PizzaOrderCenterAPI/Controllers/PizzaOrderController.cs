using Microsoft.AspNetCore.Mvc;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaOrderCenterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaOrderController : ControllerBase
	{
		private IPizzaOrderService _pizzaOrderService;

		public PizzaOrderController(IPizzaOrderService pizzaOrderService)
			=> _pizzaOrderService = pizzaOrderService;


		// GET: api/<PizzeriaController>
		[HttpGet]
		public async Task<List<PizzaOrder>> Get()
		{
			return await _pizzaOrderService.GetAll();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public async Task<PizzaOrder?> Get(int id) => await _pizzaOrderService.GetPizzaOrder(id);

		// POST api/<PizzeriaController>
		[HttpPost]
		public async Task<PizzaOrder?> Save(PizzaOrder pizzaOrder)
		{
			return await _pizzaOrderService.Save(pizzaOrder);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public async Task<PizzaOrder?> Delete(int id)
		{
			return await _pizzaOrderService.Delete(id);
		}
	}
}
