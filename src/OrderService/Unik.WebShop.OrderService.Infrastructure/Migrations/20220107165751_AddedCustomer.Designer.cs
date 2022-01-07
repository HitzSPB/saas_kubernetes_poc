﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unik.WebShop.OrderService.Infrastructure.Context;

#nullable disable

namespace Unik.WebShop.OrderService.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220107165751_AddedCustomer")]
    partial class AddedCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Unik.WebShop.OrderService.Infrastructure.Models.OrderEf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OrderEf", (string)null);
                });

            modelBuilder.Entity("Unik.WebShop.OrderService.Infrastructure.Models.ProductItemEf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderEfId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderEfId");

                    b.ToTable("ProductItemEf", (string)null);
                });

            modelBuilder.Entity("Unik.WebShop.OrderService.Infrastructure.Models.ProductItemEf", b =>
                {
                    b.HasOne("Unik.WebShop.OrderService.Infrastructure.Models.OrderEf", null)
                        .WithMany("ProductItems")
                        .HasForeignKey("OrderEfId");
                });

            modelBuilder.Entity("Unik.WebShop.OrderService.Infrastructure.Models.OrderEf", b =>
                {
                    b.Navigation("ProductItems");
                });
#pragma warning restore 612, 618
        }
    }
}
