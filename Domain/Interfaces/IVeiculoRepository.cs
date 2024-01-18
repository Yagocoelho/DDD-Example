using Domain.Commands;
using Domain.Entidades;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommand command);

        void PostAsync();
        Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync();
        Task<IEnumerable<VeiculoCommand>> GetVeiculosDisponiveisAsync();
        Task<VeiculoPrecoCommand> GetPrecoDiaria(ETipoVeiculo tipoVeiculo);
        void GetAsync();
    }
}
