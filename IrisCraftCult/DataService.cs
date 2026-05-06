using System.Text.Json;
 // Убедись, что твои модели (GameItem и др.) лежат здесь

namespace IrisCraftCalc.Services
{
    public class DataService
    {
        // Настройки, чтобы чтение JSON было гибким
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true, // Игнорировать регистр (Id vs id)
            AllowTrailingCommas = true          // Разрешить лишние запятые в конце списков
        };

        public async Task<List<GameItem>> LoadRecipesAsync(string fileName)
        {
            try
            {
                // Обращаемся к папке Resources/Raw
                using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();

                var result = JsonSerializer.Deserialize<List<GameItem>>(json, _options);

                return result ?? new List<GameItem>();
            }
            catch (Exception ex)
            {
                // Если файла нет или он кривой — выводим ошибку в консоль отладки
                System.Diagnostics.Debug.WriteLine($"[DataService] Ошибка: {ex.Message}");
                return new List<GameItem>();
            }
        }
    }
}