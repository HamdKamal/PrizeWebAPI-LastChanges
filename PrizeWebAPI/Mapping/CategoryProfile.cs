using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
