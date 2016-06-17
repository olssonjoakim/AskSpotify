using AskSpotify.BusinessLayer.Global;
using AskSpotify.BusinessLayer.Interfaces;
using AskSpotify.BusinessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Helpers
{
    public class SpotifyApiProxy : ApiProxy
    {
        #region Properties

        public string OAuthToken { get; set; }

        public Token Token { get; set; }

        public string TokenType { get; set; }

        #endregion

        #region Constructors

        public SpotifyApiProxy(string baseAddress) : base(baseAddress)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Send an async 'GET' to Spotify api.
        /// </summary>
        /// <typeparam name="Res"></typeparam>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<Res> SendAsync<Res>(HttpRequestMessage requestMessage = null)
        {
            if (this.Token == null)
                await this.RequestOAuthToken();

            if (this.Token == null)
                throw new NullReferenceException("You are not logged in against Spotify API.");

            Res returnValue = null;
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token.access_token);

                // send the  to the apiurl plus method name
                var response = await client.SendAsync(requestMessage);

                var contentAsString = await response.Content.ReadAsStringAsync();

                returnValue = JsonConvert.DeserializeObject<Res>(contentAsString);
            }

            return returnValue;
        }

        /// <summary>
        /// Send an async 'POST' to Spotify api.
        /// </summary>
        /// <typeparam name="Res"></typeparam>
        /// <typeparam name="Req"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <param name="callback"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public async Task<Res> PostAsync<Res, Req>(Req request, string method, Action<Res> callback = null, [CallerMemberName] string caller = null)
        where Res : class, IBaseResponse
        where Req : class, IBaseRequest
        {
            if (this.Token == null)
                await this.RequestOAuthToken();

            if (this.Token == null)
                throw new NullReferenceException("You are not logged in against Spotify API.");

            return await base.PostAsync<Res, Req>(request, method, callback, caller);
        }

        public async Task<Token> RequestOAuthToken()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                wc.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(GlobalContext.Instance.SpotifyClientId + ":" + GlobalContext.Instance.SpotifyClientSecret)));

                NameValueCollection col = new NameValueCollection
                {
                    {"grant_type", "client_credentials"},
                    {"scope", ""}
                };


                byte[] data;

                try
                {
                    data = wc.UploadValues("https://accounts.spotify.com/api/token", "POST", col);
                }
                catch (WebException e)
                {
                    using (StreamReader reader = new StreamReader(e.Response.GetResponseStream()))
                    {
                        data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                    }
                }

                this.Token = JsonConvert.DeserializeObject<Token>(Encoding.UTF8.GetString(data));

                return this.Token;
            }
        }

        #endregion
    }
}
