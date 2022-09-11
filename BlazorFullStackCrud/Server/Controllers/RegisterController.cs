using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        
        private readonly DataContext _context;
        public RegisterController(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.NormalizedUserName = user.UserName.ToLower();
            user.NormalizedEmail = user.Email.ToLower();
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            user.TwoFactorEnabled = true;
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now;
            user.AccessFailedCount = 1;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
