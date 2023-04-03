using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Infrastructure.Context
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Id)
                  .HasColumnName("Id")
                  .HasColumnType("uniqueidentifier");

            builder.Property(p => p.Name)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("Situacao")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
