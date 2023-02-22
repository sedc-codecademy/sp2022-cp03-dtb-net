﻿using DevBlog.Domain.Models;

namespace DevBlog.DataAccess.Interfaces
{
    public interface IStarRepository : IRepository<Star>
    {
        Star GetStarByPostAndUserId(int postId, int userId);
    }
}
