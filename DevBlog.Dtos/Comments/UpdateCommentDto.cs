﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Dtos.Comments
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool Anonymous { get; set; }
    }
}
