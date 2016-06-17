using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Extensions
{
    public static class ObjectExtensions
    {
        public static Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings;

        /// <summary>
        /// Serializes an object into a JSON string.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToJson(this object c)
        {
            var returnValue = string.Empty;

            if (c != null)
            {
                returnValue = JsonConvert.SerializeObject(c, JsonSerializerSettings);
            }

            return returnValue;
        }

        static ObjectExtensions()
        {
            JsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
        }
    }
}
