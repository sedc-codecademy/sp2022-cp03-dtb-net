using ProductivityApp.Domain.Enums;

namespace ProductivityApp.Dtos.ReminderDtos
{
    public class ReminderDto
    {
        public string ReminderInfo { get; set; }
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public PriorityEnum Priority { get; set; }
    }
}
