using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskSpotify.BusinessLayer.Models
{
    public class Artist
    {
        #region Properties

        public object[] genres { get; set; }

        public string href { get; set; }

        public string id { get; set; }

        public Image[] images { get; set; }

        public string name { get; set; }

        public int popularity { get; set; }

        public string type { get; set; }

        public string uri { get; set; }

        #endregion
    }
}