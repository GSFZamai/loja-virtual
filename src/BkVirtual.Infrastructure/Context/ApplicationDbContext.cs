using BkVirtual.Core.Data;
using BkVirtual.Core.Domain;
using BkVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BkVirtual.Infrastructure.Context;

public class ApplicationDbContext : DbContext, IUnityOfWork
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItem { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(x => Console.WriteLine(x)).EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(false).HaveColumnType("varchar(400)");
        base.ConfigureConventions(configurationBuilder);
    }

    public async Task SalvarAlteracoesAsync()
    {
        foreach (var entity in ChangeTracker.Entries().Where(e => e.GetType().GetProperty(nameof(Entity.Cadastro)) != null))
        {
            if (entity.State == EntityState.Modified)
            {
                entity.Property(nameof(Entity.Cadastro)).IsModified = false;
            }
        }
        await SaveChangesAsync();
    }
}