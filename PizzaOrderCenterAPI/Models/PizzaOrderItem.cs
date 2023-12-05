using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	/// <summary>
	/// Order item details
	/// </summary>
	public class PizzaOrderItem
	{
		[Key]
		[Required]
		public int PizzaOrderItemId { get; set; }

		/// <summary>
		/// Tells you which pizza is being ordered, it is also the link to from which pizzeria this pizza was to come from
		/// </summary>
		[Required]
		public int PizzaId { get; set; }

		/// <summary>
		/// Number of pizzas
		/// </summary>
		[Required]
		public int Qty { get; set; } = 0;


		/// <summary>
		/// Line item total
		/// </summary>
		[Required]
		public decimal LineTotal { get; set; } = 0m;

		/// <summary>
		/// Tells you which order this line item belongs to
		/// </summary>
		[Required]
		public int PizzaOrderId { get; set; }



		/// <summary>
		/// If there any topping to a pizza, it would be here. Each pizza can have its own topping
		/// </summary>
		public List<PizzaOrderItemTopping> PizzaOrderItemToppings { get; set; }
	}
}
