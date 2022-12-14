using AutoMapper;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerDto, Answer>();
            CreateMap<Answer, AnswerDto>();
        }
    }
}
