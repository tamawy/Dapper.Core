using System.Data.SqlClient;
using Dapper.Core.Entities;
using Dapper.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Dapper.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddAsync(Product entity)
        {
            entity.AddedOn=DateTime.Now;
            const string sql = "Insert into Products (Name, Description, Barcode, Rate, AddedOn) " +
                               "VALUES (@Name, @Description, @Barcode, @Rate, @AddedOn)";
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
            return await connection.ExecuteAsync(sql, entity);
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * from Products Where Id=@Id";
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
            var result = await connection.QueryFirstOrDefaultAsync<Product>(sql, new {Id = id});
            return result;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            const string sql = "SELECT * from Products";
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
            var result = await connection.QueryAsync<Product>(sql);
            return result.ToList();
        }


        public async Task<int> UpdateAsync(Product entity)
        {
            entity.ModifiedOn=DateTime.Now;
            const string sql = "Update Products SET Name= @Name, Description= @Description, Barcode= @Barcode, Rate= @Rate, ModifiedOn=@ModifiedOn" +
                               "Where Id= @Id";
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
            return await connection.ExecuteAsync(sql, entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE from Products Where Id=@Id";
            await using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
            return await connection.ExecuteAsync(sql, new {Id = id});
        }
    }
}
