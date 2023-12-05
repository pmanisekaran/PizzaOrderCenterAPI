using System.ComponentModel.DataAnnotations;

namespace PizzaOrderCenterAPI.Models
{
	/// <summary>
	/// Pizza order. Order can contain multipple pizzs from same location and also pizza from different location in the same order
	/// </summary>
	public class PizzaOrder
	{
		[Key]
		[Required]
		public int PizzaOrderId { get; set; }

		/// <summary>
		/// if customer proides any name
		/// </summary>
		
		[Required]
		[MaxLength(255)]
		public string CustomerName { get; set; } = "Not Provided";


		/// <summary>
		/// Order total
		/// </summary>
		public decimal OrderTotal { get; set; } = 0m;

		/// <summary>
		/// Order details
		/// </summary>
		public List<PizzaOrderItem> PizzaOrderItems { get; set; } 

		

	}
}
