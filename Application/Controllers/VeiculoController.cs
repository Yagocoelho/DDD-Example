using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoservice;
        public VeiculoController(IVeiculoService veiculoService) 
        {
            _veiculoservice = veiculoService;
        }
        [HttpPost]
        [Route("CadastrarVeiculos")]
        public async Task<IActionResult> PostAsync([FromBody] VeiculoCommand command)
        {
            
            return Ok(await _veiculoservice.PostAsync(command));
        }
        [HttpGet]
        [Route("SimularAluguel")]
        public IActionResult GetAsync() 
        {
            return Ok();
        }
        [HttpPost]
        [Route("Alugar")]
        public IActionResult PostAsync()
        {
            return Ok();
        }
        [HttpGet]
        [Route("VeiculosAlugados")]
        public async Task<IActionResult> GetVeiculosAlugadosAsync()
        {
            return Ok(await _veiculoservice.GetVeiculosAlugadosAsync());
        }        
        [HttpGet]
        [Route("VeiculosDisponiveis")]
        public async Task<IActionResult> GetVeiculosDisponiveisAsync()
        {
            return Ok(await _veiculoservice.GetVeiculosDisponiveisAsync());
        }

    }
}
