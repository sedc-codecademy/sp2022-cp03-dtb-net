using ProductivityApp.Domain.Enums;

namespace ProductivityApp.Dtos.ReminderDtos
{
    public class ReminderDto
    {
        public string ReminderTitle { get; set; } 
        public string ReminderNote { get; set; } = string.Empty;
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public PriorityEnum Priority { get; set; }
    }
}
