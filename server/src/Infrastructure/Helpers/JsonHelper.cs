using Newtonsoft.Json;

namespace Infrastructure.Helpers
{
    public class JsonHelper
    {
        public static bool TryParseJsonToObject<T>(string json, out T result)
        {
            try
            {
                result = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch (JsonException)
            {
                result = default(T);
                return false;
            }
        }
    }
}
