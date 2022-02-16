using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGlass.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Codigo)
                .IsRequired(true);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsRequired(true);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(100);

            modelBuilder.Entity<Produto>()
                .Property(p => p.CnpjDoFornecedor)
                .HasMaxLength(18);


            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto {   Codigo = 1, 
                                    Descricao = "Produto 01", 
                                    Situacao = "A", 
                                    DataFabricacao = new DateTime(2021,1,1), 
                                    DataValidade = new DateTime(2021, 2, 1), 
                                    CodigoDoFornecedor = 1, 
                                    DescricaoDoFornecedor = "Fornecedor 01", 
                                    CnpjDoFornecedor = "01.234.789/0001-20" }); 
        }
    }
}
