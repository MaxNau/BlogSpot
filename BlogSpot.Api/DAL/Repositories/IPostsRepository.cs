using BlogSpot.Api.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BlogSpot.Api.DAL.Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        ICollection<Post> GetPostsRange(int start, int end);
        Post GetPostByDateAndTitle(Post post);
        int TotalPosts();
    }
}
