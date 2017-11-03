using BlogSpot.Api.DAL;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogSpot.Test
{
    [TestFixture]
    public class DbContextTests
    {
        PostsRepository mockRepository;

        [SetUp]
        public void Setup()
        {
            var posts = new List<Post>
            {
                new Post()
                {
                    Id = 1,
                    Description = "post1",
                    Meta = "meta1",
                    PostedOn = new System.DateTime(2014, 11, 11, 11, 11, 11),
                    Published = true,
                    ShortDescription ="post1",
                    Slug = "slug1",
                    Tiltle = "post1",
                    Category = new Category()
                    {
                        Id = 1,
                        Description = "category1",
                        Name = "Category1",
                        Slug = "cat1"
                    },
                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            Id = 1,
                            Description = "tag1",
                            Name = "tag1",
                            Slug = "tag1"
                        },
                        new Tag()
                        {
                            Id = 2,
                            Description = "tag2",
                            Name = "tag2",
                            Slug = "tag2"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Description = "post2",
                    Meta = "meta2",
                    PostedOn = new System.DateTime(2015, 12, 12, 11, 11, 11),
                    Published = true,
                    ShortDescription ="post2",
                    Slug = "slug2",
                    Tiltle = "post2",
                    Category = new Category()
                    {
                        Id = 1,
                        Description = "category1",
                        Name = "Category1",
                        Slug = "cat1"
                    },
                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            Id = 1,
                            Description = "tag1",
                            Name = "tag1",
                            Slug = "tag1"
                        }
                    }
                }
            };

            var categories = new List<Category>();
            var tags = new List<Tag>();

            var mockSet = new Mock<DbSet<Post>>().SetupData(posts);


            var mockContext = new Mock<IBlogSpotContext>();
            mockContext.Setup(c => c.Posts).Returns(mockSet.Object);

            mockRepository = new PostsRepository(mockContext.Object);  
        }

        [Test]
        public void GetPostByDateAndTitleTest()
        {
            var _post = new Post()
            {
                PostedOn = new System.DateTime(2015, 12, 12, 11, 11, 11),
                Tiltle = "post2"
            };
            
            var post = mockRepository.GetPostByDateAndTitle(_post);

            Assert.IsNotNull(post);
        }
    }
}
