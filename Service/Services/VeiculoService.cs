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
        public void GetAsync()
        {
            throw new NotImplementedException();
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

           return await ValidaTipoCarro(command.TipoVeiculo, command.AnoFabricacao);
        }

        private async Task<string> ValidaTipoCarro(ETipoVeiculo tipoVeiculo, int AnoFabricacao)
        {
            int anoBase = DateTime.Now.Year;

            if (tipoVeiculo != ETipoVeiculo.SUV
                && tipoVeiculo != ETipoVeiculo.Hatch
                && tipoVeiculo != ETipoVeiculo.Sedan
                )
            
                return "O tipo de Veiculo não é permitidio";

            
            if ((anoBase - AnoFabricacao) > 5 && (AnoFabricacao > anoBase) )
            {
                return "Veiculo não pode ser cadastrado,possui menos que o permitido";

            }

            return _veiculoRepository.PostAsync(command);
        }
        #endregion

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
