using Dapper;
using Microsoft.Data.SqlClient;
using ProductManagement.Domain.Entites;
using ProductManagement.Domain.Queries;
using ProductManagement.Domain.ValueObjects;

namespace ProductManagement.Services.Queries
{
    public class AssociateProductWithCategoryQueries : IAssociateProductWithCategoryQueries
    {
        private readonly string _connectionString;

        public AssociateProductWithCategoryQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString)
                ? connectionString
                : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<IEnumerable<Product>> GetProductIdByCategoryId(Guid categoryId)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"
            SELECT p.*
            FROM AssociacaoProdutoCategoria ac
            INNER JOIN Produto p ON ac.ProdutoId = p.Id
            WHERE ac.CategoriaId = @CategoryId AND p.Status = @ActiveStatus
        ";

            var result = await connection.QueryAsync<Product>(query, new { CategoryId = categoryId, ActiveStatus = State.Active.Id });

            return result;
        }
    }
}
