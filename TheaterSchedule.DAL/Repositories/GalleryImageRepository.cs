using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.DAL.Repositories
{
    class GalleryImageRepository : IGalleryImageRepository
    {
        private TheaterScheduleContext db;

        public GalleryImageRepository(TheaterScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return db.GalleryImage;
        }

        public GalleryImage Get(int id)
        {
            return db.GalleryImage.Find(id);
        }

        public void Create(GalleryImage galleryImage)
        {
            db.GalleryImage.Add(galleryImage);
        }

        public void Update(GalleryImage galleryImage)
        {
            db.Entry(galleryImage).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            GalleryImage galleryImage = db.GalleryImage.Find(id);
            if (galleryImage != null)
                db.GalleryImage.Remove(galleryImage);
        }
    }
}
