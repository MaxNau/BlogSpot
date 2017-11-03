using AutoMapper;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DTOs;

namespace BlogSpot.Api.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForMember(
                postDto => postDto.PostedOnDay,
                opts => opts.MapFrom(
                    post => post.PostedOn.Day
                ))
                .ForMember(
                postDto => postDto.PostedOnMonth,
                opts => opts.MapFrom(
                    post => post.PostedOn.Month
                ))
                .ForMember(
                postDto => postDto.PostedOnYear,
                opts => opts.MapFrom(
                    post => post.PostedOn.Year
                ))
                .ForMember(
                postDto => postDto.PostedOnTime,
                opts => opts.MapFrom(
                    post => post.PostedOn.ToShortTimeString()
                ))
                .MaxDepth(1);
        }
    }
}