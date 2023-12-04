using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaOrderCenterAPI.Models
{
	public class Pizza
	{
		[Key]
		[Required]
		public int PizzaId { get; set; }

		[Required]
		public string PizzaName { get; set; }

		
		[Required]
		public int PizzeriaId { get; set; }

	}
}
