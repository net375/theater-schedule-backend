﻿namespace TheaterSchedule.Infrastructure
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


