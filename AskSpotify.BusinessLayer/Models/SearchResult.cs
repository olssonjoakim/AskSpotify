using AskSpotify.BusinessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Models
{
    public class SearchResult<T>
    {
        [JsonProperty("items")]
        public T[] Items { get; set; }

        public string href { get; set; }

        public int limit { get; set; }

        public string next { get; set; }

        public int offset { get; set; }

        public string previous { get; set; }

        public int total { get; set; }
    }
}
