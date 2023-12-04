using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	/// <summary>
	/// Toppings for given line item. Note if someone orders 2 Super supreme in the same line item, then topping applies to both the items.
	/// </summary>
	public class PizzaOrderItemTopping
	{
		[Key]
		[Required]
		public int PizzaOrderItemToppingId { get; set; }

		/// <summary>
		/// Tells what toping is applied to the pizza
		/// </summary>
		[Required]
		public int PizzaToppingId { get; set; }

		/// <summary>
		/// Tells how many toppings to pizza
		/// </summary>
		[Required]
		public int Qty { get; set; } = 0;

		/// <summary>
		/// Line item to which topping is applied
		/// </summary>
		[Required]
		public int PizzaOrderItemId { get; set; }

		/// <summary>
		/// Toppings line item total
		/// </summary>
		[Required]
		public decimal ToppingLineItemTotal { get; set; } = 0m;
	}
}
