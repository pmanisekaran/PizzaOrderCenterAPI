using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	public class PizzaTopping
	{
		[Key]
		[Required]
		public int PizzaToppingId { get; set; }

		[Required]
		[MaxLength(255)]
		public string PizzaToppingName { get; set; }


		/// <summary>
		/// Pizza topping price. Read only set $1
		/// </summary>
		[Required]
		public decimal PizzaToppingPrice { get; set; } = 1.0m;

	}
}
