using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskSpotify.BusinessLayer.Models
{
    /// <summary>
    /// Represents a Spotify album
    /// </summary>
    public class Album
    {
        #region Properties

        public string album_type { get; set; }

        public Artist[] artists { get; set; }

        public object[] genres { get; set; }

        public string href { get; set; }

        public string id { get; set; }

        public Image[] images { get; set; }

        public string name { get; set; }

        public int popularity { get; set; }

        public string release_date { get; set; }

        public string release_date_precision { get; set; }

        public Track[] tracks { get; set; }

        public string type { get; set; }

        public string uri { get; set; }

        #endregion
    }
}