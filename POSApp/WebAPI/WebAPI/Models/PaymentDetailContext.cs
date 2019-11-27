using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Models
{
  public class PaymentDetailContext : DbContext
  {
    public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options)
    {

    }


    public DbSet<PaymentDetail> PaymentDetails { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<RealServer> Servers { get; set; }

    public DbSet<Table> Tables { get; set; }

    public DbSet<Ticket> Tickets { get; set; }



        

  }
}
