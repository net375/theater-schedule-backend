using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheaterSchedule.Infrastructure
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return string.Format($"StatusCode: {StatusCode}, Message: {Message}");
        }
    }
}


