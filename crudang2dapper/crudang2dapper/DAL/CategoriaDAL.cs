using Crudang2dapper.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Crudang2dapper.DAL
{
    public class CategoriaDAL : ICategoriaDAL
    {

        private readonly string connectionString = @"Data Source=.\;Initial Catalog=Vendas;Integrated Security=True";

        public async Task AdicionaCategoria(Categoria categoria)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CategoriaNome", categoria.CategoriaNome);
                await sqlConnection.ExecuteAsync(
                    "AdicionarCategoria",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AtualizaCategoria(Categoria categoria)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CategoriaId", categoria.CategoriaId);
                dynamicParameters.Add("@CategoriaNome", categoria.CategoriaNome);
                await sqlConnection.ExecuteAsync(
                    "AtualizaCategoria",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletaCategoria(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                await sqlConnection.ExecuteAsync(
                    "DeletaCategoria",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Categoria>(
                    "GetCategoria",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Categoria>(
                    "GetCategorias",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
