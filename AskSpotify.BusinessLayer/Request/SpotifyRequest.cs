using AskSpotify.BusinessLayer.Base;
using AskSpotify.BusinessLayer.Interfaces;
using AskSpotify.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Request
{
    public class SpotifyRequest : IBaseRequest
    {
        public string Query { get; set; }

        public ItemType ItemType { get; set; }

        public string Market { get; set; }

        public int? Limit { get; set; }

        public int? Offset { get; set; }

        public string Token { get; set; }
    }
}
