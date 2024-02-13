using Microsoft.EntityFrameworkCore;

namespace PagueMenosDesafio.Models
{
    public class PagueMenosContext : DbContext
    {
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Preco> Precos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loja>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Produto>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Preco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Estoque>()
                .HasKey(e => e.Id);

            // Relacionamentos
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Loja)
                .WithMany(l => l.Produtos)
                .HasForeignKey(p => p.LojaId);

            modelBuilder.Entity<Preco>()
                .HasOne(p => p.Produto)
                .WithMany(p => p.Precos)
                .HasForeignKey(p => p.ProdutoId);

            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Produto)
                .WithMany(p => p.Estoques)
                .HasForeignKey(e => e.ProdutoId);
        }
    }
}
