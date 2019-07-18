using System;

namespace TheaterSchedule.BLL.DTOs
{
    public class RefreshTokenDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DaysToExpire { get; set; }
        public string RefreshToken { get; set; }
    }
}
