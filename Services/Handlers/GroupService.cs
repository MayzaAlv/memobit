using AutoMapper;
using FluentResults;
using memobit.Data;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Services.Handlers
{
    public class GroupService : IGroupService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GroupService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<GroupDto> GetGroup()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(_context.Groups.ToList());
        }

        public Group GetGroupId(int id)
        {
            try
            {
                return _context.Groups.First(g => g.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public Group CreateGroup(GroupDto groupDto)
        {
            try
            {
                Group group = _mapper.Map<Group>(groupDto);

                _context.Groups.Add(group);
                _context.SaveChanges();
                return group;
            }
            catch
            {
                return null;
            }
        }

        public Result UpdateGroup(int id, GroupDto groupDto)
        {
            try
            {
                Group group = _context.Groups.First(g => g.Id == id);

                _mapper.Map(groupDto, group);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Search Error");
            }   
        }

        public Result DeleteGroup(int id)
        {
            try
            {
                Group group = _context.Groups.First(g => g.Id == id);

                _context.Groups.Remove(group);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Search Error");
            }
        }
    }
}
