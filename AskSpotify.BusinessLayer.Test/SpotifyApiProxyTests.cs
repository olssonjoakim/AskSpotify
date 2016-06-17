using Microsoft.VisualStudio.TestTools.UnitTesting;
using AskSpotify.BusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Helpers.Tests
{
    [TestClass()]
    public class SpotifyApiProxyTests
    {
        [TestMethod()]
        public async Task RequestOAuthTokenTest()
        {
            var response = await BusinessLayer.Global.GlobalContext.Instance.SpotifyApiProxy.RequestOAuthToken();
        }

    }
}