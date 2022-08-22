using AutoMapper;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>();
            CreateMap<CardDto, Card>();
            CreateMap<CardCreateDto, Card>();
            CreateMap<Card, CardCreateDto>();
        }
    }
}
