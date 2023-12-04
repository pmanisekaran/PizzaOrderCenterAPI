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
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PizzeriaController>
		[HttpPost]
		public Pizzeria? Post(Pizzeria pizzeria)
		{
			return _pizzeriaService.Add(pizzeria);
		}

		// PUT api/<PizzeriaController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PizzeriaController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
