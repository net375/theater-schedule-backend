using System;
using System.Net;

namespace TheaterSchedule.Infrastructure
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) 
            : base(message)
        {
            this.StatusCode = statusCode;
        }       
    }
}
