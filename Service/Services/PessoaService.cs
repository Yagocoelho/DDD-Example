using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PessoaService : IPessoaService
    { 
      private readonly IPessoaRepository _repository;

      public PessoaService(IPessoaRepository repository)
      {
                _repository = repository;
      }

        public async Task<IEnumerable<ByEstadoCommand>> GetClientesbyEstadoAsync(ByEstadoCommand command)
        {
            
            return await _repository.GetClientesbyEstadoAsync(command);
        }

        public async Task<string> PostAsync(PessoaCommand command)
        {
            if (command == null)
                return "Todos os campos são obrigatorios";

            var erro = await ValidaCliente(command);
            if (erro != null)
                return erro.ToString();

            return await _repository.PostAsync(command);
        }

        private async Task<string> ValidaCliente(PessoaCommand command)
        {
            int anoBase = DateTime.Now.Year;
            double calculo = anoBase % command.DataNascimento.Year;
            if (calculo <=18)
            {
                return "Cliente não Pode ser cadastrado,possui menos que o permitido";

            }

            return null;
        }
    }
}
