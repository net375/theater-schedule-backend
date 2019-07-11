using System;

namespace TheaterSchedule.BLL.DTOs
{
    public class AdminsPostDTO
    {
        public int AdminsPostId { get; set; }
        public string Subject { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsPersonal { get; set; }
        public int? ToUserId { get; set; }
    }
}
