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
		public async Task<ActionResult> SaveRectangle(Rectangle rectangle)
		{
			await _rectangleService.SaveRectangleAsync(rectangle);

			return Ok();
		}

		[HttpPost("validate")]
		public async Task<ActionResult<bool>> ValidateRectangle(Rectangle rectangle)
		{
			var isValid = await _rectangleService.ValidateRectangleAsync(rectangle);

			return Ok(isValid);
		}

	}
}
