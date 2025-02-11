using CatalogAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


	}
}
