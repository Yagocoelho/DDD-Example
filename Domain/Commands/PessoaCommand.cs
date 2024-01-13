using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class PessoaCommand
    {

        public int PessoaId { get; set; }
        public string NomeCompleto { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Habilitacao {get; set;}
        public string Estado { get; set; }
    }
}
