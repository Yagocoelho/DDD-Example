using CreditCardValidator;
using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

                return "O tipo de Veiculo não é permitido";


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
        public async Task<IEnumerable<VeiculoCommand>> GetVeiculosDisponiveisAsync()
        {
            return await _repository.GetVeiculosDisponiveisAsync(); 
            
        }

        public async Task<SimularVeiculoAluguelViewModel> SimularVeiculoAluguel(int totalDiasSimulado, ETipoVeiculo tipoVeiculo)
        {
            var veiculoPreco = await _repository.GetPrecoDiaria(tipoVeiculo);

            double taxaEstadual = 10.50;
            double taxaFederal = 3.5;
            double taxaMunicipal = 13.5;

            var simulacao = new SimularVeiculoAluguelViewModel();
            var periodoMaximoAluguel = veiculoPreco.PeriodoMaximoAluguel;
            if (simulacao.TotalDiasSimulado > periodoMaximoAluguel) return null;

            simulacao.TotalDiasSimulado = totalDiasSimulado;
            simulacao.Taxas = (decimal)(taxaEstadual+taxaFederal+taxaMunicipal);
            simulacao.TipoVeiculo = tipoVeiculo;
            simulacao.ValorDiaria = veiculoPreco.Preco;
            simulacao.ValorTotal = (totalDiasSimulado * veiculoPreco.Preco) + simulacao.Taxas;
            return simulacao;
        }

        public async Task AlugarVeiculo(AlugarVeiculoViewModelInput input)
        {


            //todo
            
            CreditCardDetector detector = new CreditCardDetector(Convert.ToString( input.Cartao.Numero));
            var bandeira = detector.Brand; // => 4012888888881881

            if (!detector.IsValid()) { //"Cartao Invalido!";
            } // => True
            //chamar método para validar habilitação
            //"Veiculo alugado Pelo Cliente: "+ Cliente+ " Pelo periodo de: "+dataretirada - datadedevolução


        }
        private async Task<bool> ValidarDatas(DateTime inicio, DateTime fim)
        {
            if (fim < inicio)
                return false;
            else if (fim == inicio)
                return false;
            else if (fim < DateTime.Now)
                return false;
            else if (inicio < DateTime.Now)
                return false;
            else
                return true;

        }
        private Task<bool> VeiculoEstaAlugado(string placaVeiculo)
        { 
            return _repository.VeiculoEstaAlugado(placaVeiculo);
        }
    }
}
