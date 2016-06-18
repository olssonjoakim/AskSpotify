using AskSpotify.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskSpotify.Models
{
    public class ResultsViewModel
    {
        public string SearchString { get; set; }

        public ItemType ItemType { get; set; }

        public SearchResult<Track> Tracks { get; set; }
    }
}