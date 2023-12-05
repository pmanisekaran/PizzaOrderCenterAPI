using Microsoft.AspNetCore.Mvc;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaOrderCenterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzeriaMenuController : ControllerBase
	{
		private IPizzeriaMenuService _pizzeriaMenuService;

		public PizzeriaMenuController(IPizzeriaMenuService pizzeriaMenuService)
			=> _pizzeriaMenuService = pizzeriaMenuService;


		// GET: api/<PizzeriaController>
		[HttpGet]
		public List<Pizza> Get()
		{
			return _pizzeriaMenuService.GetAll().ToList();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public Pizza? Get(int id)
		{
			return _pizzeriaMenuService.GetPizza(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public Pizza? Save(Pizza pizza)
		{
			return _pizzeriaMenuService.Save(pizza);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public Pizza? Delete(int id)
		{
			return _pizzeriaMenuService.Delete(id);
		}
	}
}
