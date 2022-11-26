using BkVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.EntityConfiguration
{
    internal class PedidoItemEntityConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Quantidade)
                .IsRequired();

            builder.Property(i => i.PedidoId)
                .IsRequired();

            builder.Property(i => i.NomeProduto)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(i => i.ProdutoId)
                .IsRequired();

            builder.Property(i => i.ValorUnitario)
                .IsRequired();

            builder.Property(i => i.Cadastro)
                .IsRequired();

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.PedidoItens);
        }
    }
}
