using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskSpotify.BusinessLayer.Models
{
    public class Track
    {
        #region Properties

        public Album album { get; set; }

        public Artist[] artists { get; set; }

        public int disc_number { get; set; }

        public int duration_ms { get; set; }

        public bool _explicit { get; set; }

        public string href { get; set; }

        public string id { get; set; }

        public bool is_playable { get; set; }

        public string name { get; set; }

        public int popularity { get; set; }

        public string preview_url { get; set; }

        public int track_number { get; set; }

        public string type { get; set; }

        public string uri { get; set; }

        #endregion
    }
}