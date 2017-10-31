using BlogSpot.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BlogSpot.Models
{
    public class ListViewModel
    {
        public ListViewModel()
        {

        }

        public ICollection<Post> Posts { get; set; }
        public int TotalPosts { get; set; }
    }
}