using ProductivityApp.Domain.Entities;
using ProductivityApp.Dtos.ReminderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityApp.Mappers.ReminderMappers
{
    public static class ReminderMapper
    {
        public static ReminderDto ToReminderDto(this Reminder userDb)
        {
            return new ReminderDto
            {
                ReminderInfo = userDb.ReminderInfo,
                ReminderDate = userDb.ReminderDate,
                ReminderTime = userDb.ReminderTime,
                Priority = userDb.Priority
            };
        }

        public static Reminder ToReminder(this AddReminderDto addReminderDto)
        {
            return new Reminder
            {
                ReminderInfo = addReminderDto.ReminderInfo,
                ReminderTime = addReminderDto.ReminderTime,
                ReminderDate = addReminderDto.ReminderDate,
                Priority = addReminderDto.Priority,
                UserId = addReminderDto.UserId,
            };
        }

        public static Reminder UpdateDbReminder(this UpdateReminderDto updateReminderDto, Reminder reminderDb)
        {
            reminderDb.ReminderInfo = updateReminderDto.ReminderInfo;
            reminderDb.ReminderDate = updateReminderDto.ReminderDate;
            reminderDb.ReminderTime = updateReminderDto.ReminderTime;
            reminderDb.Priority = updateReminderDto.Priority;
            reminderDb.UserId = updateReminderDto.UserId;

            return reminderDb;
        }
    }
}
