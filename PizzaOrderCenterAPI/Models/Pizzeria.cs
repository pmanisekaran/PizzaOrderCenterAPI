using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	public class Pizzeria
	{

		[Required]
		[Key]
		public int PizzeriaId { get; set; }

		[Required]
		[MaxLength(255)]
		public string PizzeriaName { get; set; }

		[Required]
		[MaxLength(255)]
		public int Location { get; set; }

		[Required]
		ICollection<Pizza> Pizzas { get; set; }

	}
}
