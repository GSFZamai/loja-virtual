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
    public class TransacaoEntityConfig : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status)
                .HasConversion(x => x.ToString(),
                    x => (StatusTransacao)Enum.Parse(typeof(StatusTransacao), x))
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Total)
                .IsRequired();

            builder.Property(x => x.PedidoId)
                .IsRequired();

            builder.Property(x => x.PagamentoGatewayId)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Cadastro)
                .IsRequired();

            builder.HasOne(x => x.Pedido)
                .WithOne(x => x.Transacao);
        }
    }
}
