
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Api.Repositories.Interfaces
{
    public interface IImagenRepository
    {
        // Metodo para guardar imágenes
        Task<Imagen> SaveAsync(Imagen imagen);

        // Metodo para actualizar imágenes
        Task<Imagen> UpdateAsync(Imagen imagen);

        // Metodo para retornar todas las imágenes
        Task<List<Imagen>> GetAllAsync();

        // Metodo para eliminar imágenes por id
        Task<bool> DeleteAsync(int id);

        // Metodo para obtener una imagen por id
        Task<Imagen> GetById(int id);
    }
}