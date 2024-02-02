﻿// <auto-generated />
using System;
using HepsiApiProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HepsiApiProject.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240202111354_Update1")]
    partial class Update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(6541),
                            Name = "Computers & Health",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(6558),
                            Name = "Kids",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(6562),
                            Name = "Tools",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(8087),
                            Name = "Elektronik",
                            ParentId = 0,
                            Priorty = 1,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(8092),
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 2,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(8093),
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priorty = 1,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 615, DateTimeKind.Local).AddTicks(8094),
                            Name = "Kadın",
                            ParentId = 2,
                            Priorty = 1,
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 617, DateTimeKind.Local).AddTicks(1531),
                            Description = "Işık ama ea ona suscipit.",
                            Title = "Teldeki.",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 617, DateTimeKind.Local).AddTicks(1562),
                            Description = "Voluptatem velit sokaklarda okuma için.",
                            Title = "Deleniti.",
                            isDeleted = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 617, DateTimeKind.Local).AddTicks(1588),
                            Description = "Salladı kapının camisi esse bilgiyasayarı.",
                            Title = "Ea.",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 620, DateTimeKind.Local).AddTicks(1934),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Discount = 2.258478942245720m,
                            Price = 32.49m,
                            Title = "Fantastic Soft Chips",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 620, DateTimeKind.Local).AddTicks(2059),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Discount = 9.134587511351820m,
                            Price = 223.70m,
                            Title = "Incredible Rubber Pizza",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 2, 2, 14, 13, 54, 620, DateTimeKind.Local).AddTicks(2130),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Discount = 3.262644626706980m,
                            Price = 208.06m,
                            Title = "Awesome Cotton Computer",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Detail", b =>
                {
                    b.HasOne("HepsiApiProject.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Product", b =>
                {
                    b.HasOne("HepsiApiProject.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("HepsiApiProject.Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HepsiApiProject.Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("HepsiApiProject.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}