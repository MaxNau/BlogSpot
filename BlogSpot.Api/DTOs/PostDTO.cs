using System;
using System.Collections.Generic;

namespace BlogSpot.Api.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Tiltle { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string Slug { get; set; }
        public bool Published { get; set; }
        public string PostedOnDay { get; set; }
        public string PostedOnMonth { get; set; }
        public string PostedOnYear { get; set; }
        public string PostedOnTime { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual ICollection<TagDTO> Tags { get; set; }  
    }
}