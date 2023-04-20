using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommrce.Api.Services.Interfaces;

public interface IProductCategoryService
{
    //Metodo para guardar categorias
    Task<ProductCategorieDto> SaveAsync(ProductCategorieDto category);
    
    //Metodo para Actualizar categorias
    Task<ProductCategorieDto> UpdateAsync(ProductCategorieDto category);

    //Metodo para retornar categorias
    Task<List<ProductCategorieDto>> GetAllAsync();

    Task<bool> DeleteAsync(int id);

    //Metodo para retornar una lista de categorias
    Task<bool> ProductCategoryExist(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategorieDto> GetById(int id);
}