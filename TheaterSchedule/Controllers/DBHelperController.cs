using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using TheaterSchedule.Util;
using TheaterSchedule.DAL.Contexts;
using TheaterSchedule.DAL.Repositories;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Entities;

namespace TheaterSchedule.Controllers
{
    [Route("api/[controller]")]
    public class DBHelperController : Controller
    {
        private readonly ITheaterScheduleUnitOfWork uow;
        private readonly IHostingEnvironment appEnvironment;

        public DBHelperController(ITheaterScheduleUnitOfWork _uow, IHostingEnvironment _appEnvironment)
        {
            uow = _uow;
            appEnvironment = _appEnvironment;
        }

        [HttpGet]
        public string Get()
        {
            return "To fill DB with default data make request \"/api/DBHelper/UseDefaultData\" with POST method or visit page \"/FillDB.html\"";
        }


        [HttpPost("UseDefaultData")]
        public string Post()
        {
            string path = Path.Combine(appEnvironment.ContentRootPath, "static/media/");

            uow.Performances.Create(new Performance { MainImage = ImageHelper.ImageToByteArray(path + "dva-levy.png"), Duration = 100, MinPrice = 40, MaxPrice = 120, MinimumAge = 2, Description = "Two Lions" });
            uow.Performances.Create(new Performance { MainImage = ImageHelper.ImageToByteArray(path + "kit-u-chobotjah.png"), Duration = 70, MinPrice = 35, MaxPrice = 80, MinimumAge = 3, Description = "Puss in Boots" });

            //...filling_other_tables...
            uow.Save();

            //ImageHelper.ByteArrayToImage(((Performance)uow.Performances.GetAll().First()).MainImage).Save("D:\\test.png");
            return "Data is added";
        }

        [HttpPost("Performances")]
        public string Post(Performance pvm, IFormFile mainImage)
        {
            if (ModelState.IsValid)
            {
                if (mainImage != null)
                {

                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(mainImage.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)mainImage.Length);
                    }

                    pvm.MainImage = imageData;

                    uow.Performances.Create(pvm); 
                    uow.Save();

                    return $"Data is added. Now DB Performance contain {uow.Performances.GetAll().Count()} records";
                }                
            }

            return "Data adding failed";
        }       
    }
}
