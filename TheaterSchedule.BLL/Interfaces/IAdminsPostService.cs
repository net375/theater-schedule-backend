using System.Collections.Generic;
using TheaterSchedule.BLL.DTOs;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IAdminsPostService
    {
        IEnumerable<AdminsPostDTO> GetAllPublicPosts();
        IEnumerable<AdminsPostDTO> GetAllPersonalPosts(int id);
        void AddNewPost(AdminsPostDTO post);
    }
}
