using BkVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BkVirtual.Infrastructure.EntityConfiguration;

public class CategoriaEntityConfig : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> b)
    {
        b.HasKey(c => c.Id);

        b.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        b.Property(c => c.Descricao)
            .IsRequired()
            .HasColumnType("varchar(700)");

        b.Property(c => c.Ativo)
            .IsRequired();

        b.Property(c => c.Cadastro)
            .IsRequired();

        b.HasMany(c => c.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId)
            .HasConstraintName("PK_Produto_CategoriaId");
    }
}