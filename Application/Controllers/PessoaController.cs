using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaservice;
        public PessoaController(IPessoaService pessoaservice)
        {
            _pessoaservice = pessoaservice;
        }
        [HttpPost]
        [Route("CadastrarCliente")]
        public async Task<IActionResult> PostAsync([FromBody] PessoaCommand command)
        {

            return Ok(await _pessoaservice.PostAsync(command));
        }
    }
}
