using AskSpotify.BusinessLayer.Extensions;
using AskSpotify.BusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Global
{
    public class GlobalContext
    {
        #region Objects

        private object lockObject = new object();

        private static readonly GlobalContext instance;

        private SpotifyApiProxy spotifyApiProxy;

        #endregion

        #region Properties

        public static GlobalContext Instance
        {
            get
            {
                return instance;
            }
        }
        
        public SpotifyApiProxy SpotifyApiProxy
        {
            get
            {
                return this.spotifyApiProxy;
            }
            set
            {
                this.spotifyApiProxy = value;
            }
        }

        public string SpotifyClientId { get; set; }

        public string SpotifyClientSecret { get; set; }

        #endregion
        
        #region Constructors

        public GlobalContext()
        {
            this.Initialize();
        }

        static GlobalContext()
        {
            instance = new GlobalContext();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            var spotifyApiBaseAddress = ConfigurationManager.AppSettings["SpotifyApiBaseAddress"];
            var spotifyClientId = ConfigurationManager.AppSettings["SpotifyClientId"];
            var spotifyClientSecret = ConfigurationManager.AppSettings["SpotifyClientSecret"];

            if (spotifyApiBaseAddress.IsNullOrEmpty())
                throw new NullReferenceException("Spotify API base address must be specified.");

            if (spotifyClientId.IsNullOrEmpty())
                throw new NullReferenceException("Spotify client id must be specified.");

            if (spotifyClientSecret.IsNullOrEmpty())
                throw new NullReferenceException("Spotify client secret must be specified.");

            this.SpotifyApiProxy = new SpotifyApiProxy(spotifyApiBaseAddress);
            this.SpotifyClientId = spotifyClientId;
            this.SpotifyClientSecret = spotifyClientSecret;
        }

        #endregion
    }
}
