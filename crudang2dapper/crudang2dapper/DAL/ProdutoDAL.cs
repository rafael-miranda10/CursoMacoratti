using Dapper;
using Crudang2dapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Crudang2dapper.DAL
{
    public class ProdutoDAL : IProdutoDAL
    {
        private readonly string connectionString = @"Data Source=.\;Initial Catalog=Vendas;Integrated Security=True";

        public async Task AdicionaProduto(Produto produto)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Nome", produto.Nome);
                    dynamicParameters.Add("@Preco", produto.Preco);
                    dynamicParameters.Add("@Quantidade", produto.Quantidade);
                    dynamicParameters.Add("@FornecedorId", produto.FornecedorId);
                    dynamicParameters.Add("@CategoriaId", produto.CategoriaId);
                    await sqlConnection.ExecuteAsync(
                        "AdicionarProduto",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task AtualizaProduto(Produto produto)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@produtoId", produto.ProdutoId);
                dynamicParameters.Add("@Nome", produto.Nome);
                dynamicParameters.Add("@Preco", produto.Preco);
                dynamicParameters.Add("@Quantidade", produto.Quantidade);
                dynamicParameters.Add("@FornecedorId", produto.FornecedorId);
                dynamicParameters.Add("@CategoriaId", produto.CategoriaId);
                await sqlConnection.ExecuteAsync(
                    "AtualizaProduto",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletaProduto(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@produtoId", id);
                await sqlConnection.ExecuteAsync(
                    "DeletaProduto",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Produto> GetProduto(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Produto>(
                    "GetProduto",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    return await sqlConnection.QueryAsync<Produto>(
                        "GetProdutos",
                        null,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
