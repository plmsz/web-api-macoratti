using APICatalago.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Context;

// DbContext - representa uma sessao com banco de dados sendo a ponte entres as entidades de dominio e o banco, mapeamento das entidade, realizar consultas e operações
//DbSet<T> - representa uma coleção de entidades no contexto eque podem ser consultadas no banco de dados
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}