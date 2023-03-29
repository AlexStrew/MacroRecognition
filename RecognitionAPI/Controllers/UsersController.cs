using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecognitionAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace RecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly RecognitionDbContext _dbContext;

        public UsersController(RecognitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsersClass model)
        {
            var user = _dbContext.UsersClasses.FirstOrDefault(u => u.username == model.username && u.password == model.password);

            if (user != null)
            {
                return Ok(); // вернуть успешный ответ без токена
            }
            else
            {
                return NotFound(); // вернуть ошибку 404, если пользователь не найден
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersClass>>> GetInventories()
        {
            return await _dbContext.UsersClasses.ToListAsync();
        }
    }
}
