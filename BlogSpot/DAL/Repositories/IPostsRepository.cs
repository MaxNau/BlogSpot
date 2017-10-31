using BlogSpot.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BlogSpot.DAL.Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        ICollection<Post> GetPostsRange(int start, int end);
        int TotalPosts();
    }
}
