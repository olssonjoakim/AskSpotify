using AskSpotify.BusinessLayer.Extensions;
using AskSpotify.BusinessLayer.Global;
using AskSpotify.BusinessLayer.Models;
using AskSpotify.BusinessLayer.Request;
using AskSpotify.BusinessLayer.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer
{
    public class Spotify
    {
        /// <summary>
        /// Search for tracks using the Spotify API
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<SpotifyResponse> SearchAsync(SpotifyRequest request)
        {
            #region Check constrains

            if (request == null)
                throw new InvalidOperationException("Request object cannot be null.");
            if (request.Query.IsNullOrEmpty())
                throw new ArgumentNullException("Query cannot be null or empty.");
            if (request.ItemType == ItemType.Unknown)
                throw new InvalidOperationException("Item type to search for cannot be 'Unknown'.");

            #endregion

            var requestMessage = new HttpRequestMessage();

            requestMessage.Headers.Add("Accept", "application/json");
            //requestMessage.Headers.Add("Accept-Encoding", "gzip, deflate, compress");

            #region Build the request Uri based on the parameters in the request object

            var requestUri = new StringBuilder();

            requestUri.Append(GlobalContext.Instance.SpotifyApiProxy.BaseAddress);
            requestUri.Append("search?");
            requestUri.Append($"q={request.Query}");
            requestUri.Append($"&type={request.ItemType.ToString()}");

            if( request.Market.IsNotNullOrEmpty() )
                requestUri.Append($"&market={request.Market}");

            if (request.Limit.HasValue)
                requestUri.Append($"&limit={request.Limit.Value}");

            if (request.Offset.HasValue)
                requestUri.Append($"&offset={request.Offset.Value}");


            requestMessage.RequestUri = new Uri(requestUri.ToString());

            #endregion
            
            return await GlobalContext.Instance.SpotifyApiProxy.SendAsync<SpotifyResponse>(requestMessage);
        }
    }
}
