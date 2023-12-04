using Microsoft.AspNetCore.Mvc;
using PizzaOrderCenterAPI.Models;
using PizzaOrderCenterAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaOrderCenterAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzeriaController : ControllerBase
	{
		private IPizzeriaService _pizzeriaService;

		public PizzeriaController(IPizzeriaService pizzeriaService)
			=> _pizzeriaService = pizzeriaService;


		// GET: api/<PizzeriaController>
		[HttpGet]
		public List<Pizzeria> Get()
		{
			return _pizzeriaService.GetAll().ToList();
		}

		// GET api/<PizzeriaController>/5
		// if id does not exists, no content is returned, otherwise code 204 and the actual object
		[HttpGet("{id}")]
		public Pizzeria? Get(int id)
		{
			return _pizzeriaService.GetPizzeria(id);
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public Pizzeria? Save(Pizzeria pizzeria)
		{
			return _pizzeriaService.Save(pizzeria);
		}

		
		// DELETE api/<PizzeriaController>/5
		// if id does not exists, no content is returned otherwise code 204 and the actual object
		[HttpDelete("{id}")]
		public Pizzeria? Delete(int id)
		{
			return _pizzeriaService.Delete(id);
		}
	}
}
