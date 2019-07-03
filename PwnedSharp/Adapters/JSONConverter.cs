using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwnedSharp.Adapters
{
    /// <summary>
    /// Adapter of Json.Net from Newtonsoft.
    /// </summary>
    internal static class JSONConverter
    {
        public static Model Deserialize<Model>(string json)
        {
            return JsonConvert.DeserializeObject<Model>(json);
        }

        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
