using Domain.Models;

namespace Infrastructure.Interfaces
{
	public interface IRectangleService
	{
		Task<Rectangle> GetRectangleAsync();
		Task UpdateRectangleAsync(Rectangle rectangle);
	}
}
