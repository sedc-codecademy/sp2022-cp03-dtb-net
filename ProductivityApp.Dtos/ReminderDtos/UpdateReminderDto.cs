﻿using ProductivityApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Dtos.ReminderDtos
{
    public class UpdateReminderDto
    {
        public int Id { get; set; }
        public string ReminderTitle { get; set; }
        public string ReminderNote { get; set; } = string.Empty;
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public PriorityEnum Priority { get; set; }
        public int UserId { get; set; }
    }
}
