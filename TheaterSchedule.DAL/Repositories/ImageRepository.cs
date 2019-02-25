﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterSchedule.DAL.Interfaces;
using Entities.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TheaterSchedule.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        TheaterDatabaseContext db;

        public ImageRepository(TheaterDatabaseContext db)
        {
            this.db = db;
        }

        public async Task<byte[]> GetPerformanceImageAsync(int id)
        {
            var performance = await db.Performance.FindAsync(id);

            if (performance == null)
            {
                return null;
            }

            return performance.MainImage;
        }

        public async Task<IEnumerable<byte[]>> GetGalleryImagesAsync(int id)
        {
            var galleryImages = await (from galleryImage in db.GalleryImage
                                       where galleryImage.PerformanceId == id
                                       select galleryImage.Image).ToListAsync();

            return galleryImages;
        }
     
    }
}
