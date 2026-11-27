using Microsoft.AspNetCore.Mvc;
using Chess;

namespace ChessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class matchhistoryController : ControllerBase
    {

        private GameService room = new GameService();

        [HttpGet("history")]
        public IActionResult ShowHistory()
        {
            var history = room.ShowHistory();

            return Ok(history);
        }
    }
}
