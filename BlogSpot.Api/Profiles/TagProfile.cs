using AutoMapper;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DTOs;

namespace BlogSpot.Api.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>().PreserveReferences().MaxDepth(1);
        }
    }
}