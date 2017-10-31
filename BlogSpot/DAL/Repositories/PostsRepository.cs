using BlogSpot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BlogSpot.DAL.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private IBlogSpotContext context;
        public PostsRepository(IBlogSpotContext context)
        {
            this.context = context;
        }
        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Post> GetPostsRange(int start, int postsPerPage)
        {
            var posts = context.Posts
                                .Include(post => post.Category)
                                .Where(post => post.Published)
                                .OrderByDescending(post => post.PostedOn)
                                .Skip(start * postsPerPage)
                                .Take(postsPerPage)
                                .ToList();

            var postIds = context.Posts.Select(post => post.Id).ToList();

            return context.Posts
                            .Include(post => post.Tags)
                            .Where(post => postIds.Contains(post.Id))
                            .OrderByDescending(post => post.PostedOn)
                            .ToList();
        }

        public int TotalPosts()
        {
            return context.Posts.Where(post => post.Published).Count();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}