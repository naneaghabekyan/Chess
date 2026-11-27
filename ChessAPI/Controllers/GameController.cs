using Microsoft.AspNetCore.Mvc;
using Chess;
using Models;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class gameController : ControllerBase
    {

        private readonly GameService game;

        [HttpPost("queue")]
        public IActionResult AddToQueue([FromBody] Player player)
        {
            game.AddQueue(player);

            return Ok("Player added to queue!");
        }
        public gameController(GameService room)
        {
            this.game = room;
        }

        [HttpPost("match")]
        public IActionResult FindMatch(string type)
        {
            Match match = game.JoinMatch(type);

            return Ok(match);
        }

        [HttpPost("match/{matchid}/start")]
        public IActionResult StartMatch(int matchid)
        {
            Match match = game.StartMatch(matchid);

            return Ok(match);
        }

        [HttpPost("match/{matchid}/move")]
        public IActionResult MakeMove(int matchid, [FromBody] string position)
        {
            bool result = game.MakeMove(matchid, position);

            if (!result)
            {
                return BadRequest("Invalid move!");
            }

            return Ok("Move accepted!");
        }

        [HttpGet("match/{matchid}/end")]
        public IActionResult CheckGameIsOver(int matchid) 
        {
            bool result = game.GameIsOver(matchid);

            if (result)
            {
                return Ok("The game is over. This is checkmate!");
            }

            return Ok("Continue");
        }

    }
}
