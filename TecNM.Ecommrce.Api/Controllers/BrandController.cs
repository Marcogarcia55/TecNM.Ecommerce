using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Dto;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommrce.Api.Repositories.Interfaces;
using TecNM.Ecommrce.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TecNM.Ecommrce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<BrandDto>>>> GetAll()
        {
            var response = new Response<List<BrandDto>>
            {
                Data = await _brandService.GetAllAsync()
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<BrandDto>>> Post([FromBody] BrandDto brandDto)
        {
            var response = new Response<BrandDto>()
            {
                Data = await _brandService.SaveAsync(brandDto)
            };

            return Created($"/api/[controller]/{response.Data.Id}", response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<BrandDto>>> GetById(int id)
        {
            var response = new Response<BrandDto>();

            if (!await _brandService.BrandExists(id))
            {
                response.Errors.Add("Brand not found");
                return NotFound(response);
            }

            response.Data = await _brandService.GetById(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response<BrandDto>>> Update([FromBody] BrandDto brandDto)
        {
            var response = new Response<BrandDto>();

            if (!await _brandService.BrandExists(brandDto.Id))
            {
                response.Errors.Add("Brand not found");
                return NotFound(response);
            }

            response.Data = await _brandService.UpdateAsync(brandDto);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {

            var response = new Response<bool>();
            var result = await _brandService.DeleteAsync(id);
            response.Data = result;
        
            return Ok(response);
        }
    }
}
