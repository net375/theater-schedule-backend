
using System;

namespace TheaterSchedule.BLL.Models
{
    public class TokensResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
