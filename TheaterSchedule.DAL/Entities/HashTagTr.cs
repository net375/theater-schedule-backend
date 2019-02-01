using System;
using System.Collections.Generic;

namespace TheaterSchedule.DAL.Entities
{
    public partial class HashTagTr
    {
        public int HashTagTrid { get; set; }
        public string Tag { get; set; }
        public int LanguageId { get; set; }
        public int HashTagId { get; set; }

        public virtual HashTag HashTag { get; set; }
        public virtual Language Language { get; set; }
    }
}
