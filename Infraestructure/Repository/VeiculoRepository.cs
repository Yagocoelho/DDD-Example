﻿using Dapper;
using Domain.Commands;
using Domain.Entidades;
using Domain.Interfaces;
using System.Data.SqlClient;


namespace Infraestructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";
        public async Task<string> PostAsync(VeiculoCommand command)
        {
            string queryInsert = @"INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)
                                  VALUES(@Placa, @AnoFabricacao, @TipoVeiculoId, @Estado, @MontadoraId)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId =  (int) command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = (int)command.Montadora
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
        public async Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync()
        {
            string queryGet = @"SELECT * FROM Veiculo WHERE Alugado=1";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(queryGet);
            }
        }
    }
}

