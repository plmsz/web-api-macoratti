### Configurando projeto para usar o EF Core
Pomelo.EntityFrameworkCore.MySql
Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef

dotnet tool update --global dotnet-ef


### Aplicar migrations
- Dentro da pasta do projeto

dotnet ef migrations add nomeDaMigracao
dotnet ef database update
dotnet ef database update 0 (voltar para migration inicial)

dotnet ef migrations remove

![alt text](image.png)


# Populando tabelas

1. Cria uma migration
2. Adiciona valores no up e down. Ex:
```C#
public partial class PopulaTabelas : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas','bebidas.jpg')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("Delete from Categorias");
    }
}
```
3. Aplica database