using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTO
{
    class ExcursionDTO
    {
        public string ExcursionName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
    }
}
