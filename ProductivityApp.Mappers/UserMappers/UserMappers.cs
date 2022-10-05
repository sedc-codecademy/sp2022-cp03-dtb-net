﻿using ProductivityApp.Domain.Entities;
using ProductivityApp.Dtos.UserDtos;
using ProductivityApp.Mappers.SessionMappers;

namespace ProductivityApp.Mappers.UserMappers
{
    public static class UserMappers
    {


        public static UserDto ToUserDto(this User userDb)
        {
            return new UserDto
            {
                FullName = userDb.FullName,
                UserName = userDb.UserName,
                Role = userDb.Role,
                Sessions = userDb.Sessions.Select(s => s.ToSessionDto()).ToList()
            };
        }
    }
}
