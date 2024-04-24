using System.Collections.ObjectModel;

namespace APICatalago.Domain;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>()
    }
    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}

// relacionamento 1:n Categorias => Produtos