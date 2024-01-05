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

        public async Task PostAsync(VeiculoCommand command)
        {
            if (command == null)
                throw new NotImplementedException();
            //Todo
            //incluir validação, só podem cadastrar veículos com 
            //até 5 anos de uso 

            //to do
            //incluir somente de carros do tipo SUV, Sedan e Hatch
           await ValidaTipoCarro(command.TipoVeiculo);
        }

        private Task ValidaTipoCarro(ETipoVeiculo tipoVeiculo)
        {
            if (tipoVeiculo != ETipoVeiculo.SUV
                && tipoVeiculo != ETipoVeiculo.Hatch
                && tipoVeiculo != ETipoVeiculo.Sedan
                )
            {
                Console.WriteLine("Não Cadastrou o Veiculo");
               
            }
            else
            {
                Console.WriteLine("Cadastro de Veiculo Feito!");
            }
            
            
            throw new NotImplementedException();
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
