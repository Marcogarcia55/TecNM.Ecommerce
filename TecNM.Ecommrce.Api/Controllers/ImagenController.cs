using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecNM.Ecommerce.Api.Repositories.Interfaces;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;

namespace TecNM.Ecommrce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenRepository _imagenRepository;

        public ImagenController(IImagenRepository imagenRepository)
        {
            _imagenRepository = imagenRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Imagen>>>> GetAll()
        {
            var images = await _imagenRepository.GetAllAsync();
            var response = new Response<List<Imagen>> { Data = images };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Imagen>>> Post([FromBody] Imagen imagen)
        {
            imagen = await _imagenRepository.SaveAsync(imagen);
            var response = new Response<Imagen> { Data = imagen };

            return Created($"/api/[controller]/{imagen.Id}", response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<Imagen>>> GetById(int id)
        {
            var imagen = await _imagenRepository.GetById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            var response = new Response<Imagen> { Data = imagen };

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response<Imagen>>> Update([FromBody] Imagen imagen)
        {
            var result = await _imagenRepository.UpdateAsync(imagen);
            var response = new Response<Imagen> { Data = result };

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            var success = await _imagenRepository.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            var response = new Response<bool> { Data = true };

            return Ok(response);
        }
    }
}
