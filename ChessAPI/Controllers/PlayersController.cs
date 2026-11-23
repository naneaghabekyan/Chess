using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {

        private GameRoom room = new GameRoom();

        [HttpGet("leaderboard")]
        public IActionResult ShowLeaderBoard()
        {
            var leaderboard = room.ShowLeaderBoard();

            return Ok(leaderboard);
        }
    }
}
