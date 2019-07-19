using System.ComponentModel.DataAnnotations;

namespace TheaterSchedule.BLL.DTOs
{
    public class UserMessageDTO
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
