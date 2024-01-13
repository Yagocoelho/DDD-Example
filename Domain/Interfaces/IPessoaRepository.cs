using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<string> PostAsync(PessoaCommand command);
    }
}
