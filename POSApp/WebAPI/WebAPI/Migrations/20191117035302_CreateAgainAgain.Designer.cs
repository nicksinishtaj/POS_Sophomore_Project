﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(PaymentDetailContext))]
    [Migration("20191117035302_CreateAgainAgain")]
    partial class CreateAgainAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Customer", b =>
                {
                    b.Property<int>("cust_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cust_Address")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("cust_Card")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("cust_City")
                        .HasColumnType("char(30)");

                    b.Property<string>("cust_FName")
                        .HasColumnType("char(30)");

                    b.Property<string>("cust_LName")
                        .HasColumnType("char(30)");

                    b.Property<string>("cust_MI")
                        .HasColumnType("char(1)");

                    b.Property<string>("cust_State")
                        .HasColumnType("char(30)");

                    b.Property<string>("cust_ZIP")
                        .HasColumnType("varchar(10)");

                    b.HasKey("cust_ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebAPI.Models.PaymentDetail", b =>
                {
                    b.Property<int>("PMId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("PMId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("WebAPI.Models.Product", b =>
                {
                    b.Property<int>("prod_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("prod_COST")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(19,2)");

                    b.Property<string>("prod_NAME")
                        .HasColumnType("varchar(35)");

                    b.HasKey("prod_ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebAPI.Models.RealServer", b =>
                {
                    b.Property<int>("server_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("server_FNAME")
                        .HasColumnType("char(30)");

                    b.Property<string>("server_LNAME")
                        .HasColumnType("char(30)");

                    b.Property<string>("server_MI")
                        .HasColumnType("char(1)");

                    b.Property<decimal>("total_TIPS")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("numeric(19,2)");

                    b.HasKey("server_ID");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("WebAPI.Models.Table", b =>
                {
                    b.Property<int>("table_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("server_ID");

                    b.Property<bool>("table_res")
                        .HasColumnType("bit");

                    b.HasKey("table_ID");

                    b.HasIndex("server_ID");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("WebAPI.Models.Ticket", b =>
                {
                    b.Property<int>("order_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("order_DATETIME")
                        .HasColumnType("DateTime2");

                    b.Property<int>("order_QTY");

                    b.Property<int>("order_Total");

                    b.Property<int>("prod_ID");

                    b.HasKey("order_ID");

                    b.HasIndex("prod_ID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("WebAPI.Models.Table", b =>
                {
                    b.HasOne("WebAPI.Models.RealServer", "Server")
                        .WithMany("Tables")
                        .HasForeignKey("server_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.Ticket", b =>
                {
                    b.HasOne("WebAPI.Models.Product", "Product")
                        .WithMany("Tickets")
                        .HasForeignKey("prod_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
