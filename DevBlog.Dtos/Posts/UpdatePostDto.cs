﻿namespace DevBlog.Dtos.Posts
{
    public class UpdatePostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }

    }
}
