using Domain.Models;
using Infrastructure.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace Infrastructure.Services
{
	public class RectangleService : IRectangleService
	{
		private readonly string? _jsonFilePath;
		private readonly SemaphoreSlim _semaphore = new(1, 1);

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
			if (_jsonFilePath == null)
			{
				throw new Exception("Path is null");
			}

			await _semaphore.WaitAsync();

			try
			{
				var dimensionsJson = await File.ReadAllTextAsync(_jsonFilePath);
				var rectangle = JsonSerializer.Deserialize<Rectangle>(dimensionsJson)
					?? throw new Exception("Rectangle is null");
				return rectangle;
			}
			finally
			{
				_semaphore.Release();
			}
		}

		public async Task UpdateRectangleAsync(Rectangle rectangle)
		{
			await Task.Delay(1000);

			if (rectangle.Width > rectangle.Height)
			{
				throw new Exception("Width cannot be greater than height");
			}

			if (_jsonFilePath == null)
			{
				throw new Exception("Path is null");
			}

			 await _semaphore.WaitAsync();
            try
            {
                var dimensionsJson = JsonSerializer.Serialize(rectangle);
                await File.WriteAllTextAsync(_jsonFilePath, dimensionsJson);
            }
            finally
            {
                _semaphore.Release();
            }
		}
	}
}
