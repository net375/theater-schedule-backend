﻿using System;

namespace TheaterSchedule.BLL.DTO
{
    public class WishlistDTO
    {
        public int PerformanceId { get; set; }
        public string Title { get; set; }
        public byte[] MainImage { get; set; }
    }
}