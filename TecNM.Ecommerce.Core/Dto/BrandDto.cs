using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.Dto;

public class BrandDto: DtoBase
{
    
    public string Brands { get; set; }

    public BrandDto()
    {
        
    }
    
    public BrandDto(Brand brand)
    {
        Id = brand.Id;
        Brands = brand.Brands;
    }
}