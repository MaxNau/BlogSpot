using AutoMapper;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DTOs;

namespace BlogSpot.Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().PreserveReferences().MaxDepth(1);
        }
    }
}