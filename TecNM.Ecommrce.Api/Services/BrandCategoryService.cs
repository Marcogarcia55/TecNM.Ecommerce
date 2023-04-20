using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.Services.Interfaces;

namespace TecNM.Ecommerce.Api.Services.Interfaces
{
    public class BrandCategoryService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        
        public BrandCategoryService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        
        public async Task<BrandDto> SaveAsync(BrandDto brandDto)
        {
            var brand = new Brand()
            {
                Brands = brandDto.Brands,
                CreatedBy = "",
                CreatedDate = DateTime.Now,
                UpdatedBy = "",
                UpdatedDate = DateTime.Now
            };
            
            await _brandRepository.SaveAsync(brand);
            brandDto.Id = brand.Id;
            return brandDto;
        }
    
        public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
        {
            var brand = await _brandRepository.GetById(brandDto.Id);
            if (brand == null)
                throw new Exception("Brand Not Found");
    
            brand.Brands = brandDto.Brands;
            brand.UpdatedBy = "";
            brand.UpdatedDate = DateTime.Now;
    
            await _brandRepository.UpdateAsync(brand);
            return brandDto;
        }
    
        public async Task<List<BrandDto>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            var brandDtos = brands.Select(b => new BrandDto(b)).ToList();
            return brandDtos;
        }
    
        public async Task<bool> BrandExists(int id)
        {
            var brand = await _brandRepository.GetById(id);
            return (brand != null);
        }
    
        public async Task<BrandDto> GetById(int id)
        {
            var brand = await _brandRepository.GetById(id);
            if (brand == null)
                throw new Exception("Brand Not Found");
            var brandDto = new BrandDto(brand);
            return brandDto;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            return await _brandRepository.DeleteAsync(id);
        }
    }
}
