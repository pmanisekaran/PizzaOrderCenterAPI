using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	/// <summary>
	/// Pizzeria definition. It defines it location and its menu
	/// </summary>
	public class Pizzeria
	{

		[Required]
		[Key]
		public int PizzeriaId { get; set; }

		/// <summary>
		/// Name of the pizzeria
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string PizzeriaName { get; set; }

		/// <summary>
		/// Location where pizzeria resides. Free text.
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string Location { get; set; } = "Default Location";

		/// <summary>
		/// This is pizzeria menu. A list of pizzas
		/// </summary>
		ICollection<Pizza> Pizzas { get; set; }

	}
}
