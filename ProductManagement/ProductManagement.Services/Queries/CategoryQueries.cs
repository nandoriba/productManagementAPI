using Dapper;
using Microsoft.Data.SqlClient;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Services.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly string _connectionString;

        public CategoryQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<Category> GetById(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "SELECT Id, Nome as Name, Situacao as Status " +
                        "FROM Categoria " +
                        "WHERE Id = @Id AND Situacao = @Status";
            
            var result = await connection.QueryFirstOrDefaultAsync<Category>(query, new { Id = id, Status = State.Active.Id });
            
            return result;
        }

        public async Task<IEnumerable<Category>> GetAllStatus(State status)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT Id, Nome as Name, Situacao as Status " +
                        "FROM Categoria " +
                        "WHERE Situacao = @Status";
            var result = await connection.QueryAsync<Category>(query, new { Status = status.Id });
            return result;
        }

        public async Task<IEnumerable<Category>> GetAllByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "SELECT Id, Nome as Name, Situacao as Status " +
                        "FROM Categoria " +
                        "WHERE Nome LIKE @Name AND Situacao = @Status";
            
            var result = await connection.QueryAsync<Category>(query, new { Name = $"%{name}%", Status = State.Active.Id });
            return result;
        }
    }
}
