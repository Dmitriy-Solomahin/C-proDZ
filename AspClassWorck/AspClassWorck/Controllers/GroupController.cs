using AspClassWorck.Abstraction;
using AspClassWorck.Models;
using AspClassWorck.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AspClassWorck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet("get_group")]
        public IActionResult GetGroup()
        {
            var groups = _groupRepository.GetGroups();
            return Ok(groups);
        }
        [HttpPost("add_group")]
        public IActionResult AddGroup([FromBody] GroupDTO groupDTO)
        {
            var result = _groupRepository.AddGroup(groupDTO);
            return Ok(result);
        }
        [HttpDelete("delete_group")]
        public IActionResult DeleteGroup([FromBody] GroupDTO groupDTO)
        {
            var result = _groupRepository.DeleteGroup(groupDTO);
            return Ok(result);
        }

    }
}
