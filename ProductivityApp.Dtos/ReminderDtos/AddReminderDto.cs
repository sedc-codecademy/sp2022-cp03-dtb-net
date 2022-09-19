using ProductivityApp.Domain.Entities;
using ProductivityApp.Domain.Enums;

namespace ProductivityApp.Dtos.ReminderDtos
{
    public class AddReminderDto
    {
        public int UserId { get; set; }
        public string ReminderInfo { get; set; }
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public PriorityEnum Priority { get; set; }
    }
}
