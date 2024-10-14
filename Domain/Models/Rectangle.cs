using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class Rectangle
	{
		[Range(2, int.MaxValue, ErrorMessage = "Width must be greater than or equal to 2")]
		public int Width { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Height must be greater than or equal to 1")]
		public int Height { get; set; }
	}
}
