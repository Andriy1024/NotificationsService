﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationService.Persistence;

namespace NotificationService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200525162320_Added_OrderStatus")]
    partial class Added_OrderStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotificationService.Domain.OrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("BuyerName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<long>("Payment")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Order","NotificationService");
                });

            modelBuilder.Entity("NotificationService.Domain.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Product","NotificationService");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Cost = 800L,
                            Description = "Apple on September 10, 2019, unveiled the iPhone 11, its new flagship $699 smartphone that offers a range of powerful features at an affordable price tag. Sold alongside the more expensive iPhone 11 Pro and the iPhone 11 Pro Max, the iPhone 11 is going to be the iPhone perfect for most people.",
                            Name = "IPhone 11",
                            Unit = "$"
                        },
                        new
                        {
                            Id = 2L,
                            Cost = 1300L,
                            Description = "Xiaomi notebooks are still considered a rarity in Europe and have to be imported from Asia. Not having the opportunity of looking at the device beforehand at your trusted local store, plus the additional effort of making warranty claims etc., makes it all the more important to read reviews of imported products before making your final decision. Notebookcheck has therefore decided that after reviewing the Intel Core i5-8250U version, we will now also take a look at the model with the stronger Intel Core i7-8550U. In this review, we have focused mainly on the device's performance and its differences to the other model that we have already tested.",
                            Name = "Xiaomi Mi Notebook Pro",
                            Unit = "$"
                        },
                        new
                        {
                            Id = 3L,
                            Cost = 400L,
                            Description = "The PlayStation 4 (officially abbreviated as PS4) is an eighth-generation home video game console developed by Sony Computer Entertainment. Announced as the successor to the PlayStation 3 in February 2013, it was launched on November 15 in North America, November 29 in Europe, South America and Australia, and on February 22, 2014 in Japan. It's the 4th best-selling console of all time. It competes with Microsoft's Xbox One and Nintendo's Wii U and Switch.",
                            Name = "PlayStation 4",
                            Unit = "$"
                        });
                });

            modelBuilder.Entity("NotificationService.Domain.OrderEntity", b =>
                {
                    b.HasOne("NotificationService.Domain.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
