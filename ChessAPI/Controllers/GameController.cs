using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private GameRoom room = new GameRoom();

        [HttpPost("match")]
        public IActionResult FindMatch(string type)
        {
            Match match = room.JoinMatch(type);

            return Ok(match);
        }

        [HttpPost("match/{matchid}/start/")]
        public IActionResult StartMatch(int matchid)
        {
            Match match = room.StartMatch(matchid);

            return Ok(match);
        }
    }
}
