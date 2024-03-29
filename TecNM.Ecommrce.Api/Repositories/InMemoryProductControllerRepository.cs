using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommrce.Api.Repositories.Interfaces;

namespace TecNM.Ecommrce.Api.Repositories;

public class InMemoryProductControllerRepository: IProductCategoryRepository
{
    
    private readonly List<ProductCategory> _categories;

    public InMemoryProductControllerRepository()
    {
        _categories = new List<ProductCategory>();
    }
    
    public async Task<ProductCategory> SaveAsync(ProductCategory category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);
        return category;
    }

    public async Task<ProductCategory> UpdateAsync(ProductCategory category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);
        
        if(index != -1)
        {
            _categories[index] = category;
            
        }

        return await Task.FromResult(category);
    }

    public async Task<List<ProductCategory>> GetAllAsync()
    {
        
        return _categories;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<ProductCategory> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
    
    
}