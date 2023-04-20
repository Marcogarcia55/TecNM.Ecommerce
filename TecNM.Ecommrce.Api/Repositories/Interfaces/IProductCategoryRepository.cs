using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommrce.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    //Metodo para guardar categorias
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //Metodo para Actualizar categorias
    Task<ProductCategory> UpdateAsync(ProductCategory category);

    //Metodo para retornar categorias
    Task<List<ProductCategory>> GetAllAsync();

    //Metodo para retornar una lista de categorias
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategory> GetById(int id);
    
    
}