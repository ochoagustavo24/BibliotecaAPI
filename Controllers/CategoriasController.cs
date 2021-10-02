using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;
using BibliotecaAPI.DAO;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        // Agregar objeto categoriaDAO
        private CategoriaDAO categoriaDAO;

        public CategoriasController(BibliotecaContext context)
        {
            // Inicializa categoriaDAO con el contexto como parametro.
            categoriaDAO = new CategoriaDAO(context);
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await categoriaDAO.GetCategoriasAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await categoriaDAO.GetCategoriaIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categoria);
            }

        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            if (!await categoriaDAO.ModifyCategoryAsync(categoria))
            {
                return StatusCode(categoriaDAO.customError.StatusCode, categoriaDAO.customError.Message);
            }

            return NoContent();
        }

        // POST: api/Categorias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await categoriaDAO.AddCategoryAsync(categoria))
            {
                return StatusCode(categoriaDAO.customError.StatusCode,
                                  categoriaDAO.customError.Message);
            }

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            if (!await categoriaDAO.DeleteCategoryAsync(id))
            {
                return StatusCode(categoriaDAO.customError.StatusCode, categoriaDAO.customError.Message);
            }

            return Ok();
        }
    }
}
