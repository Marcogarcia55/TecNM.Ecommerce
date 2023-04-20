using TecNM.Ecommerce.Core.Dto;

namespace TecNM.Ecommrce.Api.Services.Interfaces;

public interface IBrandService
{
    //Metodo para guardar categorias
    Task<BrandDto> SaveAsync(BrandDto category);
    
    //Metodo para Actualizar categorias
    Task<BrandDto> UpdateAsync(BrandDto category);

    //Metodo para retornar categorias
    Task<List<BrandDto>> GetAllAsync();

    //Metodo para retornar una lista de categorias
    Task<bool> BrandExists(int id);
    
    Task<bool> DeleteAsync(int id);
    //Metodo para obtener una categoria por id
    Task<BrandDto> GetById(int id);
    
}