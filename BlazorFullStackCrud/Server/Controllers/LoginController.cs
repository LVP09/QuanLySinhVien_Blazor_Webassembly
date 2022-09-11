using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _dbcontext;

        public LoginController(IConfiguration configuration,
                               UserManager<User> userManager,
                               SignInManager<User> signInManager
,
                               DataContext dbcontext

            )
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var result = await _dbcontext.Users.FirstOrDefaultAsync(c => c.PasswordHash == login.Password);
            if (result == null) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim("UserId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResponse { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
       

    }
}
