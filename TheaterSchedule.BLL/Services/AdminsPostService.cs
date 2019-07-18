using AutoMapper;
using System.Collections.Generic;
using Entities.Models;
using TheaterSchedule.BLL.DTOs;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.DAL.Interfaces;

namespace TheaterSchedule.BLL.Services
{
    public class AdminsPostService : IAdminsPostService
    {
        private ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork;
        private IAdminsPostRepository adminsPostRepository;

        private IMapper mapper;

        public AdminsPostService(ITheaterScheduleUnitOfWork theaterScheduleUnitOfWork, IAdminsPostRepository adminsPostRepository)
        {
            this.adminsPostRepository = adminsPostRepository;
            this.theaterScheduleUnitOfWork = theaterScheduleUnitOfWork;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminsPost, AdminsPostDTO>()
                   .ReverseMap();
            });

            mapper = config.CreateMapper();
        }

        public void AddNewPost(AdminsPostDTO post)
        {
            adminsPostRepository.Add(mapper.Map<AdminsPostDTO, AdminsPost>(post));
            theaterScheduleUnitOfWork.Save();
        }

        public IEnumerable<AdminsPostDTO> GetAllPersonalPosts(int id)
        {
            var posts = adminsPostRepository.GetAllPersonalById(id);
            
            return mapper.Map<IEnumerable<AdminsPost>, IEnumerable<AdminsPostDTO>>(posts);
        }

        public IEnumerable<AdminsPostDTO> GetAllPublicPosts()
        {
            var posts = adminsPostRepository.GetAllPublic();

            return mapper.Map<IEnumerable<AdminsPost>, IEnumerable<AdminsPostDTO>>(posts);
        }
    }
}
