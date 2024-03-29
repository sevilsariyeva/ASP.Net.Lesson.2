﻿// <auto-generated />
using Lesson._2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lesson._2.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Lesson._2.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Drink",
                            Discount = 10,
                            ImageLink = "images\\cola.png",
                            Name = "Cola",
                            Price = 3
                        },
                        new
                        {
                            Id = 2,
                            Description = "Drink",
                            Discount = 5,
                            ImageLink = "images\\fanta.png",
                            Name = "Fanta",
                            Price = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Chips",
                            Discount = 15,
                            ImageLink = "images\\ruffles.png",
                            Name = "Ruffles",
                            Price = 5
                        },
                        new
                        {
                            Id = 4,
                            Description = "Chips",
                            Discount = 15,
                            ImageLink = "images\\lays.png",
                            Name = "Lays",
                            Price = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
