using System;

namespace TheaterSchedule.DAL.Models
{
    public class ResetCodeModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int AccountId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
