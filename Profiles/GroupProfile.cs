using AutoMapper;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
        }
    }
}
