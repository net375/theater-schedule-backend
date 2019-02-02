using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class PerformanceTr
    {
        public int PerformanceTrid { get; set; }
        public string Title { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; }
        public int PerformanceId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Performance Performance { get; set; }
    }
}
