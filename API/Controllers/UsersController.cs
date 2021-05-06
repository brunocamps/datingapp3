using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// what we want to do in this controller is get data from our db
// to do that we're going to use dependency injection

namespace API.Controllers
{
    // Controller attributes
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        // Dependency injection
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync(); // Now we are returning the list of users asynchronously
        }

        // api/users/3 test this
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {   
            return await _context.Users.FindAsync(id);
        }
    }
}