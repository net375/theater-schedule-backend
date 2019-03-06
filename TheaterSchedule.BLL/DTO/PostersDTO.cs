using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TheaterSchedule.BLL.DTO
{
    public class PostersDTO
    {
        public string Title { get; set; }
        public string MainImage { get; set; } 
        public int PerformanceId { get; set; }
    }
}