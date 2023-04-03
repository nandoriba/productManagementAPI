﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagement.Infrastructure.Context;

#nullable disable

namespace ProductManagement.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductManagement.Domain.Entites.AssociateProductWithCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoriaId");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProdutoId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("AssociacaoProdutoCategoria", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entites.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Situacao");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entites.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar")
                        .HasColumnName("Descricao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Situacao");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entites.AssociateProductWithCategory", b =>
                {
                    b.HasOne("ProductManagement.Domain.Entites.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Domain.Entites.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}