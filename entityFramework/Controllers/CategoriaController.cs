using Microsoft.AspNetCore.Mvc;
using entityFramework.Models;
using entityFramework.Services;

namespace entityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categorias = _categoriaService.Get();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("La categoría no puede ser nula.");
            }

            await _categoriaService.Save(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Categoria categoria)
        {
            if (categoria == null || id != categoria.CategoriaId)
            {
                return BadRequest("La categoría no puede ser nula y el ID debe coincidir.");
            }

            await _categoriaService.Update(id, categoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoriaService.Delete(id);
            return NoContent();
        }
    }
}