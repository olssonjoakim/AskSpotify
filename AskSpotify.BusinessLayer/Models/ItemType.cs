using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskSpotify.BusinessLayer.Models
{
    public enum ItemType : int
    {
        Unknown = 0,
        Track = 1,
        Album = 2,
        Artist = 3,
        Playlist = 4
    }
}