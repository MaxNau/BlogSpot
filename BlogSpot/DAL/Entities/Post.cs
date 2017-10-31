using System;
using System.Collections.Generic;

namespace BlogSpot.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Tiltle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string Slug { get; set; }
        public bool Published { get; set; }
        public virtual DateTime PostedOn { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }  
    }
}