using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommrce.Api.Repositories.Interfaces;

namespace TecNM.Ecommrce.Api.Services.Interfaces;

public class ProductCategoryService: IProductCategoryService
{

    private readonly IProductCategoryRepository _productCategoryRepository;
    
    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    
    public async Task<ProductCategorieDto> SaveAsync(ProductCategorieDto categoryDto)
    {
        var category = new ProductCategory()
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
            
        };
        
        await _productCategoryRepository.SaveAsync(category);
        categoryDto.Id = category.Id;
        return categoryDto;
    }

    public async Task<ProductCategorieDto> UpdateAsync(ProductCategorieDto categoryDto)
    {
        var category = await _productCategoryRepository.GetById(categoryDto.Id);
        if (category == null)
            throw new Exception("Product category Not Found");

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdatedDate = DateTime.Now;

        await _productCategoryRepository.UpdateAsync(category);
        return categoryDto;
    }

    public async Task<List<ProductCategorieDto>> GetAllAsync()
    {
        var category = await _productCategoryRepository.GetAllAsync();
        var categoryDto = category.Select(c => new ProductCategorieDto(c)).ToList();
        return categoryDto;
    }

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<ProductCategorieDto> GetById(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        if (category == null)
            throw new Exception("Product category Not Found");
        var categoryDto = new ProductCategorieDto(category);
        return categoryDto;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _productCategoryRepository.DeleteAsync(id);
    }
}