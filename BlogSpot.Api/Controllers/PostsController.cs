using AutoMapper;
using BlogSpot.Api.DAL;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DAL.Repositories;
using BlogSpot.Api.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace BlogSpot.Api.Controllers
{
    [RoutePrefix("api/test")]
    public class PostsController : ApiController
    {

        [Route("get")]
        public ICollection<PostDTO> get()
        {
            using (var context = new BlogSpotContext())
            {
                var repository = new PostsRepository(context);
                var posts = repository.GetPostsRange(1 - 1, 10);

                var postsDto = Mapper.Map<ICollection<Post>, ICollection<PostDTO>>(posts);
                return postsDto;
            }
        }

        public PostDTO GetPost(string year, string month, string day, string title)
        {
            using (var context = new BlogSpotContext())
            {
                var repository = new PostsRepository(context);

            }

                return null;
        }
        [Route("add")]
        public PostDTO AddPost(PostDTO post)
        {
            return null;
        }
    }
}
