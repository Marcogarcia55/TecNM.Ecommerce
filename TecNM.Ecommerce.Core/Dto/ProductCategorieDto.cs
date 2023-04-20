using System.Security.Cryptography;
using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.Core.Dto;

public class ProductCategorieDto: DtoBase
{
    public String Name { get; set; }
    public String Description { get; set; }

    public ProductCategorieDto()
    {
        
    }

    public ProductCategorieDto(ProductCategory category)
    {
        Id = category.Id;
        Name = category.Name;
        Description = category.Description;
    }
}