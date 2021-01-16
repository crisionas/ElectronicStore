﻿// <auto-generated />
using System;
using ES.BusinessLayer.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ES.BusinessLayer.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ES.Domain.Entities.ApplianceBrands", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandId");

                    b.ToTable("ApplianceBrands");
                });

            modelBuilder.Entity("ES.Domain.Entities.ApplianceCategories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("CategoryId");

                    b.ToTable("ApplianceCategories");
                });

            modelBuilder.Entity("ES.Domain.Entities.ApplianceProducts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("ProductImage1")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ProductImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ProductImage3")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ApplianceProducts");
                });

            modelBuilder.Entity("ES.Domain.Entities.ElectroBrands", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandID");

                    b.ToTable("ElectroBrands");
                });

            modelBuilder.Entity("ES.Domain.Entities.ElectroCategories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("ElectroCategories");
                });

            modelBuilder.Entity("ES.Domain.Entities.ElectroProducts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("ProductImage1")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ProductImage2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ProductImage3")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryId");

                    b.ToTable("ElectroProducts");
                });

            modelBuilder.Entity("ES.Domain.Entities.ApplianceProducts", b =>
                {
                    b.HasOne("ES.Domain.Entities.ApplianceBrands", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("ES.Domain.Entities.ApplianceCategories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ES.Domain.Entities.ElectroProducts", b =>
                {
                    b.HasOne("ES.Domain.Entities.ElectroBrands", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID");

                    b.HasOne("ES.Domain.Entities.ElectroCategories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
