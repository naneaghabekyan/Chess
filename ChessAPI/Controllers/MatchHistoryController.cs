using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchHistoryController : ControllerBase
    {

        private GameRoom room = new GameRoom();

        [HttpGet("history")]
        public IActionResult ShowHistory()
        {
            var history = room.ShowHistory();

            return Ok(history);
        }
    }
}
