using CrudAngularDapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CrudAngularDapper.DAL
{
    public class FornecedorDAL : IFornecedorDAL
    {
        //private readonly string connectionString = @"Data Source=.\;Initial Catalog=Vendas;Integrated Security=True";
        // private readonly string connectionString = @"Data Source=RAFAEL-NOTE\\SQLExpress02;Initial Catalog=Vendas;Integrated Security=True";
        // private readonly string connectionString = @"Data Source=localhost;Initial Catalog=Vendas;Integrated Security=True";

       // private readonly string connectionString = "Server=RAFAEL-NOTE\\SQLExpress02;Database=Vendas;Trusted_Connection=True;MultipleActiveResultSets=true";
          private readonly string connectionString =  "Server=localhost;Database=Vendas;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add("@FornecedorId", fornecedor.FornecedorId);
                dynamicParameters.Add("@Nome", fornecedor.Nome);
                dynamicParameters.Add("@Endereco", fornecedor.Endereco);
                dynamicParameters.Add("@ContatoNome", fornecedor.ContatoNome);
                dynamicParameters.Add("@Email", fornecedor.Email);
                await sqlConnection.ExecuteAsync(
                    "AdicionarFornecedor",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AtualizarrFornecedor(Fornecedor fornecedor)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@FornecedorId", fornecedor.FornecedorId);
                dynamicParameters.Add("@Nome", fornecedor.Nome);
                dynamicParameters.Add("@Endereco", fornecedor.Endereco);
                dynamicParameters.Add("@ContatoNome", fornecedor.ContatoNome);
                dynamicParameters.Add("@Email", fornecedor.Email);

                await sqlConnection.ExecuteAsync(
                    "AtualizaFornecedor",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletarFornecedor(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                await sqlConnection.ExecuteAsync(
                    "DeletaFornecedor",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Fornecedor> GetFornecedor(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QuerySingleOrDefaultAsync<Fornecedor>(
                    "GetFornecedor",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedores()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Fornecedor>(
                    "GetFornecedores",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
