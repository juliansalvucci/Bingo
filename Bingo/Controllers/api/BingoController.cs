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

        [HttpGet]
        [Route("GuardarHistorialBolilla")]
        public async Task<ActionResult> GuardarHistorialBolilla(int bolilla = 2)
        {
            try
            {
                var historialBolillero = new HistorialBolillero();

                historialBolillero.FechaYHora = DateTime.Now;
                historialBolillero.NumeroDeBolilla = bolilla;

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
