using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.DTOs
{
    public class PollDTO
    {
        public Dictionary<string, string[]> CheckBoxes { get; set; }
        public Dictionary<string, string> Fields { get; set; }
    }
}
