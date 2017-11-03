using BlogSpot.Api.DAL.Entities;
using System;
using System.Data.Entity;

namespace BlogSpot.Api.DAL
{
    public class BlogSpotContext : DbContext, IBlogSpotContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public BlogSpotContext()
            : base("name=BlogSpotDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}