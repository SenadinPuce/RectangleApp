using Domain.Models;

namespace Infrastructure.Interfaces
{
	public interface IRectangleService
	{
		Task<Rectangle> GetRectangleAsync();
		Task SaveRectangleAsync(Rectangle rectangle);
		Task<bool> ValidateRectangleAsync(Rectangle rectangle);
	}
}
