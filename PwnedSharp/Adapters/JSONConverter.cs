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
        /// <summary>
        /// Deserializes a JSON string into the desired model.
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Model Deserialize<Model>(string json)
        {
            return JsonConvert.DeserializeObject<Model>(json);
        }

        /// <summary>
        /// Serializes the given object into a JSON string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}
