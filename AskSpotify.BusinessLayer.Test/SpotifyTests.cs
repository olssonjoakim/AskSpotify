using Microsoft.VisualStudio.TestTools.UnitTesting;
using AskSpotify.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Tests
{
    [TestClass()]
    public class SpotifyTests
    {
        [TestMethod()]
        public async Task SearchAsyncTest()
        {
            var request = new BusinessLayer.Request.SpotifyRequest();
            request.Query = "petter";
            request.ItemType = Models.ItemType.Artist;

            try
            {
                var response = await BusinessLayer.Spotify.SearchAsync(request);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}