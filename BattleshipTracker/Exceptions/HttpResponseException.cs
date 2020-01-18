using System;
using System.Net;

namespace BattleshipTracker.Exceptions
{
    public class HttpResponseException : Exception
    {
        public string HttpResponseMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
