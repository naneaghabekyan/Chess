using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class playersController : ControllerBase
    {

        private GameService room = new GameService();

        [HttpGet("leaderboard")]
        public IActionResult ShowLeaderBoard()
        {
            var leaderboard = room.ShowLeaderBoard();

            return Ok(leaderboard);
        }
    }
}
