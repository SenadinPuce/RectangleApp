using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RectangleController(IRectangleService rectangleService)
		: ControllerBase
	{
		private readonly IRectangleService _rectangleService = rectangleService;

		[HttpGet]
		public async Task<ActionResult<Rectangle>> GetRectangle()
		{
			var rectangle = await _rectangleService.GetRectangleAsync();

			return Ok(rectangle);
		}

		[HttpPost]
		public async Task<ActionResult> UpdateRectangle(Rectangle rectangle)
		{
			try
			{
				await _rectangleService.UpdateRectangleAsync(rectangle);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

	}
}
