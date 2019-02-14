using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using System.Linq;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.DAL.Repositories
{
    public class GalleryImageRepository: IGalleryImageRepository
    {
        private TheaterDatabaseContext db;

        public GalleryImageRepository(TheaterDatabaseContext context)
        {
            this.db = context;
        }

        public byte[] GetGalleryImagebyPerformanceId(int id)
        {
            byte[] galleryImage = db.GalleryImage.Where(g => g.PerformanceId == id).Select(g=>g.Image).First();
            return galleryImage;
        }
    }
}
