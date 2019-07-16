using System.Collections.Generic;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IAdminsPostService
    {
        List<AdminsPostDTO> GetAllPublicPosts();
        List<AdminsPostDTO> GetAllPersonalPosts(int id);
        void AddNewPost(AdminsPostDTO post);
    }
}
