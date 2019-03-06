using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.DAL.Models
{
    public class PerformanceDataModel
    {
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
        public int PerformanceId { get; set; }       
    }
}
