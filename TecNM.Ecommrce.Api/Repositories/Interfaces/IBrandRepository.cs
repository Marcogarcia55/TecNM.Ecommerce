using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommrce.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    //Metodo para guardar categorias
    Task<Brand> SaveAsync(Brand brand);
    
    //Metodo para Actualizar categorias
    Task<Brand> UpdateAsync(Brand brand);

    //Metodo para retornar categorias
    Task<List<Brand>> GetAllAsync();

    //Metodo para retornar una lista de categorias
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Brand> GetById(int id);
    
    
}