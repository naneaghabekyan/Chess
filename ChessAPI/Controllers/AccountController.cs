using Microsoft.AspNetCore.Mvc;
using Chess;
using Models;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class accountController : ControllerBase
    {

        private AccountService account = new AccountService();

        [HttpPost("register")]
        public IActionResult RegisterPlayer([FromBody] RegisterRequest request)
        {
            try
            {
                //if (request == null)
                //    throw EmptyRequestException("Empty request");

                account.RegisterPlayer(request.Nickname, request.Password);

                return Ok("Account has been created");
            }
            catch (EmptyRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidNickOrPasException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotUniqueNickException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
