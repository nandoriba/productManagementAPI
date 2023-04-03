using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entites;

namespace ProductManagement.Infrastructure.Context
{
    public class AssociateProductWithCategoryConfiguration : IEntityTypeConfiguration<AssociateProductWithCategory>
    {
        public void Configure(EntityTypeBuilder<AssociateProductWithCategory> builder)
        {
            builder.ToTable("AssociacaoProdutoCategoria");

            builder.HasKey(apc => apc.Id);

            builder.Property(apc => apc.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(apc => apc.CategoryId)
                .HasColumnName("CategoriaId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(apc => apc.ProductId)
                .HasColumnName("ProdutoId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(apc => apc.Category)
                .WithMany()
                .HasForeignKey(apc => apc.CategoryId);

            builder.HasOne(apc => apc.Product)
                .WithMany()
                .HasForeignKey(apc => apc.ProductId);
        }
    }
}
