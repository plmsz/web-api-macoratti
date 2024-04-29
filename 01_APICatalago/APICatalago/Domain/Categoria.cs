using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalago.Domain;

public class Categoria
{
    public Categoria()
    {
        //Produtos = new Collection<Produto>()
        Produtos = [];
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }
}

// relacionamento 1:n Categorias => Produtos