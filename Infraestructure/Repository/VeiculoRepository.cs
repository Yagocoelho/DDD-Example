using Dapper;
using Domain.Commands;
using Domain.Entidades;
using Domain.Enums;
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
                    TipoVeiculoId = (int)command.TipoVeiculo,
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
            string queryGet = @"SELECT * FROM Veiculo WHERE Alugado=0";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(queryGet);
            }
        }
        public async Task<IEnumerable<VeiculoCommand>> GetVeiculosDisponiveisAsync()
        {
            string queryGet = @"SELECT * FROM Veiculo WHERE Alugado=1";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return await conn.QueryAsync<VeiculoCommand>(queryGet);
            }
        }
        public async Task<VeiculoPrecoCommand> GetPrecoDiaria(ETipoVeiculo tipoVeiculo)
        {
            string queryGetPrecoDiaria = @"SELECT * FROM VeiculoPreco
                                           WHERE TIPOVEICULO = @TIPOVEICULO";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<VeiculoPrecoCommand>(queryGetPrecoDiaria, new
                {TipoVeiculo = tipoVeiculo }).Result.FirstOrDefault();

            }
        }

        public async Task<bool> VeiculoEstaAlugado(string placaVeiculo)
        {
            string queryDisponibilidadeVeiculo = @"SELECT Alugado FROM Veiculo WHERE Placa = @Placa";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<bool>(queryDisponibilidadeVeiculo, new { Placa = placaVeiculo }).Result.FirstOrDefault();
            }
        }
    }
}

