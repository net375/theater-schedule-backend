using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        //public int AccountId { get; set; }
        public string PhoneId { get; set; }
    }
}
