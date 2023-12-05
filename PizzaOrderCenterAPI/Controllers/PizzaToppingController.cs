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
		public List<PizzaTopping> Get()
		{
			return _pizzaToppingService.GetAll().ToList();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public PizzaTopping? Get(int id)
		{
			return _pizzaToppingService.GetPizzaTopping(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public PizzaTopping? Save(PizzaTopping pizzaTopping)
		{
			return _pizzaToppingService.Save(pizzaTopping);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public PizzaTopping? Delete(int id)
		{
			return _pizzaToppingService.Delete(id);
		}
	}
}
