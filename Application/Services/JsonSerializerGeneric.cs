using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public static class JsonSerializerGeneric<T>
    {
        public static List<T> ReturnList(string responseContent)
        {
            return JsonSerializer.Deserialize
                 <List<T>>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public static T ReturnSigle<T>(string responseContent)
        {
            return JsonSerializer.Deserialize
                 <T>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
