using Dapper;
using Domain.Entidades;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string strigconnection = "Server=(localdb)\\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";
        public async Task<string> PostAsync(Veiculo command)
        {
            string queryInsert = @"INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)VALUES(@Placa, @AnoFabricacao, @TipoVeiculoId, @Estado, @MontadoraId)";
            using (var conn = new SqlConnection())
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId =   command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId =   command.Montadora
                });
            }
            return "Veiculo cadastrado com sucesso";
        }

        public void PostAsync()
        {

        }

        public void GetAsync()
        {

        }
    }
}
