using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrderCenterAPI.Models
{
	/// <summary>
	/// Pizza defintion. It has price and to which pizzeria it belongs to
	/// </summary>
	public class Pizza
	{
		[Key]
		[Required]
		public int PizzaId { get; set; }

		/// <summary>
		/// Pizza Name
		/// </summary>
		[Required]
		[MaxLength(255)]
		public string PizzaName { get; set; } = "Default Pizza Name";

		
		/// <summary>
		/// To which pizzeria this menu/pizza belongs to
		/// </summary>
		[Required]
		public int PizzeriaId { get; set; }


		/// <summary>
		/// Price of the pizza
		/// </summary>
		[Required]
		public decimal PizzaPrice { get; set; } = 0m;

	}
}
