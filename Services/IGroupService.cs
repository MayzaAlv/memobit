using FluentResults;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Services
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetGroup();
        Group GetGroupId(int id);
        Group CreateGroup(GroupDto groupDto);
        Result UpdateGroup(int id, GroupDto groupDto);
        Result DeleteGroup(int id);
    }
}
