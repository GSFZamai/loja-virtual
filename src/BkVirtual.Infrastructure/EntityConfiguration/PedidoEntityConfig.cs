using BkVirtual.Domain.Entities;
using BkVirtual.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BkVirtual.Infrastructure.EntityConfiguration
{
    public class PedidoEntityConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .IsRequired();

            builder.Property(p => p.Cadastro)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion(p => p.ToString(),
                    p => (StatusPedido)Enum.Parse(typeof(StatusPedido), p))
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.HasMany(p => p.PedidoItens)
                 .WithOne(i => i.Pedido)
                 .HasForeignKey(i => i.PedidoId)
                 .HasConstraintName("PedidoItem_Pedido_FK");
        }
    }
}
