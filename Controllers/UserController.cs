using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWebServer.Models;

namespace CoreWebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>()
        {
            new User { Id = 1, Name = "abc", Email = "abc@a.com", Average = 1000.00m },
            new User { Id = 2, Name = "def", Email = "def@a.com", Average = 200.00m },
            new User { Id = 3, Name = "ghi", Email = "ghi@a.com", Average = 100.01m },
        };

        // GET : api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        // GET : api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found" });
            }
            return Ok(user);
        }

        // POST : api/user
        [HttpPost]
        public ActionResult<User> PostUser([FromBody] User user)
        {
            user.Id = _users.Max(p => p.Id) + 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

        // PUT : api/user/{id}
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest(new { Message = "ID mismatch" });
            }
            var existUser = _users.FirstOrDefault(p => p.Id == id);
            if (existUser == null)
            {
                return NotFound(new { Message = $"user with ID {id} not found" });
            }
            // update
            existUser.Name = updatedUser.Name;
            existUser.Email = updatedUser.Email;
            existUser.Average = updatedUser.Average;

            // TODO Database save.
            
            return NoContent();
        }

        // DELETE : api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"user with ID {id} not found" });
            }

            _users.Remove(user);
            return NoContent();
        }
    }
}
