using Dapper;
using Microsoft.Data.SqlClient;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Services.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly string _connectionString;

        public ProductQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<Product> GetById(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"
            SELECT Id,Nome as Name,Descricao as Description,Preco as Price,Situacao as Status
            FROM [Produto]
            WHERE Id = @Id
        ";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = await connection.QueryFirstOrDefaultAsync<Product>(query, parameters);

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllStatus(State status)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"
            SELECT Id,Nome as Name,Descricao as Description,Preco as Price,Situacao as Status
            FROM [Produto]
            WHERE Situacao = @Status
        ";

            var parameters = new DynamicParameters();
            parameters.Add("@Status", status.Id);

            var result = await connection.QueryAsync<Product>(query, parameters);

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllByDescription(string description)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"
            SELECT Id,Nome as Name,Descricao as Description,Preco as Price,Situacao as Status
            FROM [Produto]
            WHERE Descricao LIKE @Description;";

            var parameters = new DynamicParameters();
            parameters.Add("@Description", $"%{description}%");

            var result = await connection.QueryAsync<Product>(query, parameters);

            return result;
        }
    }
}
