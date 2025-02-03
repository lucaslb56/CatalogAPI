using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models
{
	public class Produto
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Required]
		public string? Nome { get; set; }
		[StringLength(300)]
		public string? Descricao { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public double? Preco { get; set; }
		[StringLength(300)]

		public string? ImagemUrl { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public float? Estoque { get; set; }
		public int? CategoriaId { get; set; }
		public Categoria? categoria { get; set; }
		public DateTime DataCadastro { get; set; }
	}
}
