using Bingo.Models;
using Bingo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bingo.Controllers.api
{
    //https://localhost:7185/api/bingo/GuardarHistorialBolilla
    [Route("api/[controller]")]
    [ApiController]
    public class BingoController : ControllerBase
    {
        private readonly IBingoService _bingoService;

        public BingoController(IBingoService bingoService) 
        {
            _bingoService = bingoService;
        }

        [HttpPost]
        [Route("GuardarHistorialBolilla")]
        public async Task<ActionResult> GuardarHistorialBolilla(HistorialBolillero historialBolillero)
        {
            try
            {
                _bingoService.GuardarHistorialBolilla(historialBolillero);

                return Ok("Historial de bolilla actualizado con éxito");
            }
            catch(Exception)
            {
                return BadRequest("Error al guardar el historial de bolilla");
            }
        }
    }
}
