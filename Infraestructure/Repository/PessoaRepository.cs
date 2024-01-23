using Dapper;
using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructure.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";
        public async Task<string> PostAsync(PessoaCommand command)
        {
            string queryInsert = @"INSERT INTO Cliente(NomeCompleto, DataNascimento, Habilitacao, Estado)
                                  VALUES(@NomeCompleto, @DataNascimento, @Habilitacao, @Estado)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryInsert, new
                {
                    NomeCompleto = command.NomeCompleto,
                    DataNascimento = command.DataNascimento.Date,
                    Habilitacao = command.Habilitacao,
                    Estado = command.Estado
                });
            }
            return "Cliente cadastrado com sucesso";
        }

        

        public async Task<IEnumerable<ByEstadoCommand>> GetClientesbyEstadoAsync(ByEstadoCommand command)
        {
            string queryGetby = @"SELECT * FROM Cliente WHERE Estado = @Estado";
            using (SqlConnection conn = new SqlConnection(conexao))
            {

                return await conn.QueryAsync<ByEstadoCommand>(queryGetby,new { Estado = command.Estado });

            }
        }

    }      
}
