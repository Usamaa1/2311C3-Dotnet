using addToCart.Data;
using addToCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addToCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CartDbContext _context;

        public UserController(CartDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    var users = _context.Users
        //   .Include(u => u.Carts) // This loads related cart items
        //   .ToList();

        //    return Ok(users);
        //}


        // GET: api/User/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(user);
        }


        // POST: api/User
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user == null)
                return BadRequest("Invalid user data.");

            // Optional: Add validation logic here (e.g., check if email exists)

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
    }
}
