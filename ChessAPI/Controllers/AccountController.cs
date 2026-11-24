using Microsoft.AspNetCore.Mvc;
using Chess;
using Models;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private AccountService account = new AccountService();

        [HttpPost("register")]
        public IActionResult RegisterPlayer([FromBody] RegisterRequest request)
        {
            account.RegisterPlayer(request.Nickname,request.Password);

            return Ok("Account has been created");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] RegisterRequest request)
        {
            try
            {
                string token = account.Login(request.Nickname, request.Password);
                return Ok(token);
            }
            catch (PlayerDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
            catch (IncorrectPasswordException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
