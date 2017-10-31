﻿using System.Collections.Generic;

namespace BlogSpot.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}