using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.DataAcces.Interfaces;

namespace TecNM.Ecommerce.Api.Repositories
{
    public class ImagenRepository : IImagenRepository
    {
        private readonly IDbContext _dbContext;

        public ImagenRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Imagen> SaveAsync(Imagen imagen)
        {
            imagen.Id = await _dbContext.Connection.InsertAsync(imagen);
            return imagen;
        }

        public async Task<Imagen> UpdateAsync(Imagen imagen)
        {
            await _dbContext.Connection.UpdateAsync(imagen);
            return imagen;
        }

        public async Task<List<Imagen>> GetAllAsync()
        {
            const string sql = "SELECT * FROM imagen WHERE IsDeleted = 0";
            var imagenes = await _dbContext.Connection.QueryAsync<Imagen>(sql);
            return imagenes.AsList();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var imagen = await GetById(id);
            if (imagen == null)
                return false;

            imagen.IsDeleted = true;
            await _dbContext.Connection.UpdateAsync(imagen);

            return true;
        }

        public async Task<Imagen> GetById(int id)
        {
            var imagen = await _dbContext.Connection.GetAsync<Imagen>(id);
            if (imagen == null || imagen.IsDeleted)
                return null;

            return imagen;
        }
    }
}