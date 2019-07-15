using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.DAL.Interfaces;
using System.Linq;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.DAL.Repositories
{
    public class GoogleFormUrlRepository: IGoogleFormUrlRepository
    {
        private TheaterDatabaseContext db;
        public GoogleFormUrlRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public void Add(UrlModel url)
        {
            db.FormUrl.Add(new FormUrl
            {
                Url = url.Url
            });
        }

        public UrlModel GetUrl()
        {
            var url = db.FormUrl.FirstOrDefault();
            return new UrlModel
            {
                Url = url.Url,
                UrlId = url.UrlId
            };
        }
    }
}
