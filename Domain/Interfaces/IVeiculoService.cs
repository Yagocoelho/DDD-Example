using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVeiculoService
    {
        // a Interface é um contrato, apenas usamos para adicionar 
        //metodos,
        //não é feita para implementação de nada

        Task<string> PostAsync(VeiculoCommand command);

        void PostAsync();

        Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync();
        void GetAllAsync();

    }
}
