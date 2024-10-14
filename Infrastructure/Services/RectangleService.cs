using Domain.Models;
using Infrastructure.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace Infrastructure.Services
{
	public class RectangleService : IRectangleService
	{
		private readonly string? _jsonFilePath;

		public RectangleService()
		{
			var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (assemblyPath == null)
			{
				throw new Exception("Unable to determine the assembly path.");
			}

			_jsonFilePath = Path.Combine(assemblyPath, "Data", "rectangle.json");
		}

		public async Task<Rectangle> GetRectangleAsync()
		{
			if(_jsonFilePath == null)
			{
				throw new Exception("Path is null");
			}

			var dimensionsJson = await File.ReadAllTextAsync(_jsonFilePath);

			var rectangle = JsonSerializer.Deserialize<Rectangle>(dimensionsJson)
				?? throw new Exception("Rectangle is null");

			return rectangle;
		}

		public async Task SaveRectangleAsync(Rectangle rectangle)
		{
			if (_jsonFilePath == null)
			{
				throw new Exception("Path is null");
			}

			var dimensionsJson = JsonSerializer.Serialize(rectangle);

			await File.WriteAllTextAsync(_jsonFilePath, dimensionsJson);

			return;
		}

		public async Task<bool> ValidateRectangleAsync(Rectangle rectangle)
		{
			await Task.Delay(10000);

			return rectangle.Width > rectangle.Height;
		}
	}
}
