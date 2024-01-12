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
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }
        #region regras
        //Todo
        //incluir validação, só podem cadastrar veículos com 
        //até 5 anos de uso  
        //to do
        //incluir somente de carros do tipo SUV, Sedan e Hatch
        #endregion

        #region Post
        public async Task<string> PostAsync(VeiculoCommand command)
        {
            if (command == null)
                return "Todos os campos são obrigatorios";

            var erro = await ValidaTipoCarro(command.TipoVeiculo, command.AnoFabricacao);
            if (erro != null)
                return erro.ToString();

            return await _repository.PostAsync(command);
        }

        private async Task<string> ValidaTipoCarro(ETipoVeiculo tipoVeiculo, int AnoFabricacao)
        {
            int anoBase = DateTime.Now.Year;

            if (tipoVeiculo != ETipoVeiculo.SUV
                && tipoVeiculo != ETipoVeiculo.Hatch
                && tipoVeiculo != ETipoVeiculo.Sedan
                )

                return "O tipo de Veiculo não é permitidio";


            if ((anoBase - AnoFabricacao) > 5 && (AnoFabricacao > anoBase))
            {
                return "Veiculo não pode ser cadastrado,possui menos que o permitido";

            }

            return null;
        }
        #endregion

        public void PostAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync()
        {
            return await _repository.GetVeiculosAlugadosAsync(); 
            
        }

        public void GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
