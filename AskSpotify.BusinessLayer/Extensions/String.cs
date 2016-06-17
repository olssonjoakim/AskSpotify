using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AskSpotify.BusinessLayer.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a value indicating if a string if null or empty.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty( this string c )
        {
            return String.IsNullOrEmpty(c);
        }

        /// <summary>
        /// Returns a value indicating if a string if NOT null or empty.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty( this string c )
        {
            return !String.IsNullOrEmpty(c);
        }

        /// <summary>
        /// Returns a string as a StringContent object that has the contenttype of the supplied contenttype.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="contentType">Default to application/json</param>
        /// <returns></returns>
        public static StringContent ToStringContent(this string c, string contentType = "application/json")
        {
            if (c != null)
            {
                return new StringContent(c, Encoding.UTF8, contentType);
            }

            return null;
        }

    }
}
