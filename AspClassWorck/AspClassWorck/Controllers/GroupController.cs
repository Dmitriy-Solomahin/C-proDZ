using AspClassWorck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspClassWorck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        [HttpGet("getGroup")]
        public IActionResult GetGroup()
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var group = context.ProductGroups.Select(x => new Group()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Descript = x.Descript,
                    });
                    return Ok(group);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost("putGroup")]
        public IActionResult PutGroup([FromQuery] string name, string descript)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.ProductGroups.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Add(new Group()
                        {
                            Name = name,
                            Descript = descript
                        });
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpDelete("deleteGroup")]
        public IActionResult DeleteGroup([FromQuery] int groupId)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var group = context.ProductGroups.FirstOrDefault(x => x.Id == groupId);
                    if (group != null)
                    {
                        context.ProductGroups.Remove(group);
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
