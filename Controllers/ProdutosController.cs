using CatalogAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace CatalogAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProdutosController(AppDbContext context)
		{
			_context = context;
		}
		
		[HttpGet]
		public ActionResult<IEnumerable<Produto>> Get()
		{
			var produtos = _context.Produtos.ToList();
			if (produtos is null) return NotFound("Nenhum produto encontrado!");
			return produtos;
		}

		[HttpGet("{id:int}", Name = "obterProduto")]
		public ActionResult<Produto> Get(int id)
		{
			Produto? produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
			if (produto is null) return NotFound($"Produto de Id {id} não foi encontrado!");
			return produto;
		}

		[HttpPost]
		public ActionResult Post(Produto produto)
		{
			if (produto is null) return BadRequest();

			_context.Produtos.Add(produto);
			_context.SaveChanges();

			return new CreatedAtRouteResult("obterProduto", new { id = produto.Id }, produto);
		}

		[HttpPut("{id:int}")]
		public ActionResult Put(int id, Produto produto)
		{
			if (id != produto.Id) return BadRequest();

			_context.Entry(produto).State = EntityState.Modified;
			_context.SaveChanges();

			return Ok(produto);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			Produto? produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
			if (produto is null) return NotFound("Produto não encontrado!");
			_context.Produtos.Remove(produto);
			_context.SaveChanges();
			return Ok(produto);
		}
	}
}
