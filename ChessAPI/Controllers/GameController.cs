using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private readonly GameService room;

        public GameController(GameService room)
        {
            this.room = room;
        }

        [HttpPost("match")]
        public IActionResult FindMatch(string type)
        {
            Match match = room.JoinMatch(type);

            return Ok(match);
        }

        [HttpPost("match/{matchid}/start")]
        public IActionResult StartMatch(int matchid)
        {
            Match match = room.StartMatch(matchid);

            return Ok(match);
        }

        [HttpPost("match/{matchid}/move")]
        public IActionResult MakeMove(int matchid, [FromBody] string position)
        {
            bool result = room.MakeMove(matchid, position);

            if (!result)
            {
                return BadRequest("Invalid move!");
            }

            return Ok("Move accepted!");
        }

        [HttpGet("match/{matchid}/end")]
        public IActionResult CheckGameIsOver(int matchid) 
        {
            bool result = room.GameIsOver(matchid);

            if (result)
            {
                return Ok("The game is over. This is checkmate!");
            }

            return Ok("Continue");
        }

    }
}
