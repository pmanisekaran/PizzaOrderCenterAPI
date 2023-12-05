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
		public List<PizzaOrder> Get()
		{
			return _pizzaOrderService.GetAll().ToList();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public PizzaOrder? Get(int id)
		{
			return _pizzaOrderService.GetPizzaOrder(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public PizzaOrder? Save(PizzaOrder pizzaOrder)
		{
			return _pizzaOrderService.Save(pizzaOrder);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public PizzaOrder? Delete(int id)
		{
			return _pizzaOrderService.Delete(id);
		}
	}
}
