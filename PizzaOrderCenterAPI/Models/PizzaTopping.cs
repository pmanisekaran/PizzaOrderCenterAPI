namespace PizzaOrderCenterAPI.Models
{
	public class PizzaTopping
	{
		public int PizzaToppingId { get; set; }

		public int PizzaToppingName { get; set; }

		/// <summary>
		/// Pizza topping price. Read only set $1
		/// </summary>
		public decimal PizzaToppingPrice { get; } = 1.0m;

	}
}
