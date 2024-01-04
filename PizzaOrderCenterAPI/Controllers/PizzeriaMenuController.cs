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
		public async Task<List<Pizza>> Get()
		{
			return await _pizzeriaMenuService.GetAll();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public async Task<Pizza?> Get(int id)
		{
			return await _pizzeriaMenuService.GetPizza(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public async Task<Pizza?> Save(Pizza pizza)
		{
			return await _pizzeriaMenuService.Save(pizza);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public async Task<Pizza?> Delete(int id)
		{
			return await _pizzeriaMenuService.Delete(id);
		}
	}
}
