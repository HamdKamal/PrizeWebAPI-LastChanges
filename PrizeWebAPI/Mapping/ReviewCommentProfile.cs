using AutoMapper;
using PrizeWebAPI.Models;
using Core.Entities;

namespace PrizeWebAPI.Mapping
{
    public class ReviewCommentProfile : Profile
    {
        public ReviewCommentProfile()
        {
            // Add the main object mapping
            CreateMap<ReviewComment, ReviewCommentDTO>().ReverseMap();
        }
    }
}
