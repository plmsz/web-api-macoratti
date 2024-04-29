﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalago.Domain;

// Classes com apenas propriedades - sem compartamentos - classes anêmicas

[Table("Produtos")] //opcional pois já foi definido no dbContext
public class Produto
{
    [Key]  //opcional, pois já tem a palavra id
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; } // propriedade de navegação
}