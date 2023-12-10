using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BlazorServer.Utils
{
    public static class JsonSerializerGeneric<T>
    {
        public static List<T> ReturnList(string responseContent)
        {
            return JsonSerializer.Deserialize
                 <List<T>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
