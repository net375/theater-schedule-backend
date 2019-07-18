
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Interfaces
{
    public interface IGoogleFormUrlRepository
    {
        void Add(UrlModel url);
        UrlModel GetUrl();
    }
}
