using APICatalago.Context;
using APICatalago.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
            var categorias = _context.Categorias.AsNoTracking().ToList(); // usa para otimização, não fazendo o tracking para consultas somente leitura
            if (categorias is null)
            {
                return NotFound("Categorias não encontradas");
            }
            return categorias;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro"
                    );
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound("Categorias não encontradas");
            }
            return Ok(categoria);
        }

        /// Problema de referencia cíclica  - categoria referencia uma lista de produto e produto referencia categoria, que por sua vez referencia uma lista de produto, por iso deve se configurar serialização, no program builder.Services.AddControllers()
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutoS()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList(); // inclui entidades relacionadas. post inclui comentarios
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult(
                "ObterCategoria",
                new { id = categoria.CategoriaId },
                categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria is null)
            {
                return NotFound("Categorias não encontradas");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpGet("erro")]
        public ActionResult<Categoria> GetErro()
        {
            try
            {
                //_context.Categorias.AsNoTracking().ToList();
                throw new DataMisalignedException();  //simulando um erro
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
    }
}