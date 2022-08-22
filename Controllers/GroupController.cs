using FluentResults;
using memobit.Data.Dto;
using memobit.Models;
using memobit.Services;
using Microsoft.AspNetCore.Mvc;

namespace memobit.Controllers
{
    [ApiController]
    [Route("api/v1/memobit/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("group")]
        public IActionResult GetGroup()
        {
            IEnumerable<GroupDto> groupDto = _groupService.GetGroup();

            if (groupDto == null) return NoContent();
            return Ok(groupDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupId(int id)
        {
            Group readGroup = _groupService.GetGroupId(id);

            return Ok(readGroup);
        }

        [HttpPost("group")]
        public IActionResult CreateGroup([FromBody] GroupDto groupDto)
        {
            Group readGroup = _groupService.CreateGroup(groupDto);

            return CreatedAtAction(nameof(GetGroupId), new { Id = readGroup.Id }, readGroup);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, [FromBody] GroupDto groupDto)
        {
            Result result = _groupService.UpdateGroup(id, groupDto);

            if (result.IsFailed) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            Result result = _groupService.DeleteGroup(id);

            if (result.IsFailed) return BadRequest();
            return Ok(result);
        }
    }
}
