using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Models;

namespace TheaterSchedule.BLL.Services
{
    public class FormService:IFormService
    {
        private ITheaterScheduleUnitOfWork _theaterScheduleUnitOfWork;
        private IGoogleFormUrlRepository _formUrlRepository;

        public FormService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IGoogleFormUrlRepository formUrlRepository)
        {
            _theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;
            _formUrlRepository = formUrlRepository;
        }

        public UrlDTO Add(UrlDTO link)
        {
            _formUrlRepository.Add(new UrlModel
            {
                UrlId = link.UrlId,
                Url = link.Url
            });

            _theaterScheduleUnitOfWork.Save();

            return link;
        }

        public UrlDTO GetUrl()
        {
            var url = _formUrlRepository.GetUrl();
            return new UrlDTO
            {
                Url = url.Url,
                UrlId = url.UrlId
            };
        }
    }
}
