using AskSpotify.BusinessLayer.Interfaces;
using AskSpotify.BusinessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Response
{
    public class SpotifyResponse : IBaseResponse
    {
        #region Properties

        [JsonProperty("artists")]
        public SearchResult<Artist> Artists { get; set; }

        [JsonProperty("albums")]
        public SearchResult<Album> Albums { get; set; }

        [JsonProperty("tracks")]
        public SearchResult<Track> Tracks{ get; set; }

        
        #endregion
    }
}
