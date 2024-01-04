using Microsoft.AspNetCore.Mvc;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaOrderCenterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaToppingController : ControllerBase
	{
		private IPizzaToppingService _pizzaToppingService;

		public PizzaToppingController(IPizzaToppingService pizzaToppingService)
			=> _pizzaToppingService = pizzaToppingService;


		// GET: api/<PizzeriaController>
		[HttpGet]
		public async Task<List<PizzaTopping>> Get()
		{
			return await _pizzaToppingService.GetAll();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public async Task<PizzaTopping?> Get(int id)
		{
			return await _pizzaToppingService.GetPizzaTopping(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public async Task<PizzaTopping?> Save(PizzaTopping pizzaTopping)
		{
			return await _pizzaToppingService.Save(pizzaTopping);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public async Task<PizzaTopping?> Delete(int id)
		{
			return await _pizzaToppingService.Delete(id);
		}
	}
}
