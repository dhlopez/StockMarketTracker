﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockMarketTracker;

#nullable disable

namespace StockMarketTracker.Migrations
{
    [DbContext(typeof(StockMarketContext))]
    [Migration("20231112034618_Holding_TickerForeignKey")]
    partial class Holding_TickerForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockMarketTracker.Holding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Average")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Shares")
                        .HasColumnType("int");

                    b.Property<int>("TickerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TickerId");

                    b.ToTable("Holdings");
                });

            modelBuilder.Entity("StockMarketTracker.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("BoughtPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DividendAmt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Shares")
                        .HasColumnType("int");

                    b.Property<DateTime>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SoldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("StockMarketTracker.Ticker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tickers");
                });

            modelBuilder.Entity("StockMarketTracker.Holding", b =>
                {
                    b.HasOne("StockMarketTracker.Ticker", "Ticker")
                        .WithMany()
                        .HasForeignKey("TickerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticker");
                });
#pragma warning restore 612, 618
        }
    }
}