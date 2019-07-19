using TheaterSchedule.BLL.DTOs;
namespace TheaterSchedule.BLL.Interfaces

{
    public interface IPushNotificationsService
    {
        void SendPushNotification();

        void SendPostPushNotification(AdminsPostDTO post);
    }
}
