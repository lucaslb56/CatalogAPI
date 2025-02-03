using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
	public class Categoria
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Required]
		public string? Name { get; set; }
		[StringLength(300)]
		public string? ImageUrl { get; set; }
		public ICollection<Produto>? Produtos { get; set; }
	}
}
