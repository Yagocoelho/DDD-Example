using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

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
        [HttpPost]
        [Route("Alugar")]
        public async Task<IActionResult> PostAsync([FromBody]AlugarVeiculoViewModelInput input)
        {
            await _veiculoservice.AlugarVeiculo(input);
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
        [HttpGet]
        [Route("SimularAluguel")]
        public async Task<IActionResult> GetAsync(int DiasSimulacaoAluguel, ETipoVeiculo tipoVeiculo)
        {
            return Ok(await _veiculoservice.SimularVeiculoAluguel(DiasSimulacaoAluguel, tipoVeiculo));
        }

    }
}
