﻿using System.Collections.Generic;

namespace BlogSpot.Api.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PostDTO> Posts { get; set; }
    }
}