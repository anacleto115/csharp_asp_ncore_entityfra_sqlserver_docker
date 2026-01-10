using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace lib_domain.Core
{
    public class JsonHelper
    {
        public static Dictionary<string, object> ConvertToObject(string data)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> item in values!)
            {
                if (item.Value is JObject)
                    values2.Add(item.Key, ConvertToObject(item.Value.ToString()!));
                else
                    values2.Add(item.Key, item.Value);
            }
            return values2;
        }

        public static string ConvertToString(object data, bool ignore = false)
        {
            if (!ignore)
                return JsonConvert.SerializeObject(data);

            return JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
             );
        }

        public static T ConvertToObject<T>(string data, bool check = false)
        {
            if (check && data.Contains("\""))
                data = data.Replace("\"", "");
            return JsonConvert.DeserializeObject<T>(data)!;
        }
    }
}