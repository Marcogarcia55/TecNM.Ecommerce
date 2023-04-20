using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommrce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.Services.Interfaces;

namespace TecNM.Ecommrce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    

    [HttpGet]
    public async Task <ActionResult<Response<List<ProductCategorieDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategorieDto>>
        {
            Data = await _productCategoryService.GetAllAsync()
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ProductCategorieDto>>> Post([FromBody] ProductCategorieDto categoryDto)
    {
        var response = new Response<ProductCategorieDto>()
        {
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        
      
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategorieDto>>> GetByID(int id)
    {
        var response = new Response<ProductCategorieDto>();
        
        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }

        
        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ProductCategorieDto>>> Update([FromBody] ProductCategorieDto categoryDto)
    {
        var response = new Response<ProductCategorieDto>();

        if (!await _productCategoryService.ProductCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("Product Category Not Found");
                return NotFound(response);
        }

        response.Data = await _productCategoryService.UpdateAsync(categoryDto);
        
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {

        var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }
    
}