using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TicketDetailContext : DbContext
    {
        public TicketDetailContext(DbContextOptions<TicketDetailContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

    }
}