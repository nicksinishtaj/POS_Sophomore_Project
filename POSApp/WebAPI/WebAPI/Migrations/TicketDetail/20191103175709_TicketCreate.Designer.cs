﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations.TicketDetail
{
    [DbContext(typeof(TicketDetailContext))]
    [Migration("20191103175709_TicketCreate")]
    partial class TicketCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
