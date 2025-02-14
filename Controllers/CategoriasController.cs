using CatalogAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace CatalogAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CategoriasController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Categoria>> Get()
		{
			var categorias = _context.Categorias.ToList();
			if (categorias is null) return NotFound("Nenhuma categoria encontrada!");
			return categorias;
		}

		[HttpGet("{id:int}", Name = "obterCategoria")]
		public ActionResult<Categoria> Get(int id)
		{
			Categoria? categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
			if (categoria is null) return NotFound($"Categoria de Id {id} não encontrada!");
			return categoria;
		}

		[HttpPost]
		public ActionResult Post(Categoria categoria)
		{
			if (categoria is null) return BadRequest();
			_context.Categorias.Add(categoria);
			_context.SaveChanges();

			return new CreatedAtRouteResult("obterCategoria", new { id = categoria.Id}, categoria);
		}

		[HttpPut("{id:int}")]
		public ActionResult Put(int id, Categoria categoria)
		{
			if (id != categoria.Id) return BadRequest();

			_context.Entry(categoria).State = EntityState.Modified;
			_context.SaveChanges();

			return Ok(categoria);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			Categoria? categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
			if (categoria is null) return NotFound($"Categoria de Id {id} não encontrada!");
			_context.Categorias.Remove(categoria); 
			_context.SaveChanges();

			return Ok(categoria);
		}

	}
}
