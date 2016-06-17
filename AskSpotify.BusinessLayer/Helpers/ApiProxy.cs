using AskSpotify.BusinessLayer.Base;
using AskSpotify.BusinessLayer.Extensions;
using AskSpotify.BusinessLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Helpers
{
    public class ApiProxy : IDisposable
    {
        #region Objects

        private string baseAddress;

        private object lockObject = new object();
        
        private bool isDisposed;

        private bool isLoading;

        private bool isLoaded;

        private const string applicationJson = "application/json";

        private bool isPosting;

        private bool isGetting;

        #endregion

        #region Properties
        
        public string BaseAddress
        {
            get
            {
                return this.baseAddress;
            }
            set
            {
                lock (lockObject)
                    this.baseAddress = value;
            }
        }

        public bool IsDisposed
        {
            get
            {
                return this.isDisposed;
            }
            set
            {
                lock (lockObject)
                    this.isDisposed = value;
            }
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                lock (this.lockObject)
                    this.isLoading = value;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return this.isLoaded;
            }
            set
            {
                lock (this.lockObject)
                    this.isLoaded = value;
            }
        }

        /// <summary>
        /// Value indicates if a post is currently in progress
        /// </summary>
        public bool IsPosting
        {
            get
            {
                return this.isPosting;
            }
            set
            {
                lock (this.lockObject)
                    this.isPosting = value;
            }
        }

        /// <summary>
        /// Value indicates if a get is currently in progress
        /// </summary>
        public bool IsGetting
        {
            get
            {
                return this.isGetting;
            }
            set
            {
                lock (this.lockObject)
                    this.isGetting = value;
            }
        }

        #endregion

        #region Constructors

        public ApiProxy(string baseAddress)
        {
            // A BaseAddress to the Api must always be supplied in the constructor.
            if (baseAddress.IsNullOrEmpty())
                throw new ArgumentException("BaseAddress cannot be null or empty.");

            this.BaseAddress = baseAddress;
        }
        
        ~ApiProxy()
        {
            if (!this.IsDisposed)
                this.Dispose();
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.IsDisposed = true;
        }

        /// <summary>
        /// Invoke a method at the api using GET verb.
        /// </summary>
        /// <typeparam name="Res"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public virtual async Task<Res> SendAsync<Res>(HttpRequestMessage requestMessage = null)
            where Res : class, IBaseResponse
        {
            Res returnValue = null;

            using (var client = new HttpClient() { BaseAddress = new Uri(this.BaseAddress) })
            {
                // send the  to the apiurl plus method name
                var response = await client.SendAsync(requestMessage);

                returnValue = JsonConvert.DeserializeObject<Res>(await response.Content.ReadAsStringAsync());
            }

            return returnValue;
        }

        /// <summary>
        /// Invoke a method at the api using POST verb. The request object will be sent as the content.
        /// </summary>
        /// <typeparam name="Res"></typeparam>
        /// <typeparam name="Req"></typeparam>
        /// <param name="request"></param>
        /// <param name="method">Method name to trigger on the API</param>
        /// <param name="callback">Action that should be triggered as callback method upon completion.</param>
        /// <returns></returns>
        public virtual async Task<Res> PostAsync<Res, Req>(Req request, string method, Action<Res> callback = null, [CallerMemberName] string caller = null)
          where Res : class, IBaseResponse
          where Req : class, IBaseRequest
        {
            #region Check constraints

            if (request == null)
                throw new NullReferenceException("Request object cannot be null.");

            #endregion

            Res returnValue = null;

            using (var client = new HttpClient() { BaseAddress = new Uri(this.BaseAddress) })
            {
                // Do the actual post against the api
                var response = await client.PostAsync(method, request.ToJson().ToStringContent());

                // deserialize the response using json converter
                returnValue = JsonConvert.DeserializeObject<Res>(await response.Content.ReadAsStringAsync());

                // if a callback is defined as parameter, invoke it with response object as parameter.
                callback?.Invoke(returnValue);
            }

            return returnValue;
        }

        #endregion
    }
}
