using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommrce.Api.DataAcces.Interfaces;
using TecNM.Ecommrce.Api.Repositories.Interfaces;

namespace TecNM.Ecommrce.Api.Repositories
{
    public class BrandCategoryRepository : IBrandRepository
    {
        private readonly IDbContext _dbContext;

        public BrandCategoryRepository(IDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Brand> SaveAsync(Brand brand)
        {
            brand.Id = await _dbContext.Connection.InsertAsync(brand);
            return brand;
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            await _dbContext.Connection.UpdateAsync(brand);
            return brand;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            const string sql = "SELECT * FROM brand WHERE IsDeleted = 0";
            var brand = await _dbContext.Connection.QueryAsync<Brand>(sql);
            return brand.ToList();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await GetById(id);
            if (brand == null)
            {
                return false;
            }

            brand.IsDeleted = true;
            await _dbContext.Connection.UpdateAsync(brand);
            return true;
        }

        public async Task<Brand> GetById(int id)
        {
            var brand = await _dbContext.Connection.GetAsync<Brand>(id);
            return brand?.IsDeleted == false ? brand : null;
        }
        
        
    }
}