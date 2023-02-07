using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers.api
{
    //https://localhost:7185/api/bingo
    [Route("api/[controller]")]
    [ApiController]
    public class BingoController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public async Task<ActionResult> test()
        {
            return Ok("ESAAAAA");
        }
    }
}
