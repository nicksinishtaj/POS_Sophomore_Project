using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class ServerDetailContext : DbContext
    {
        public ServerDetailContext(DbContextOptions<ServerDetailContext> options) : base(options)
        {

        }

        public DbSet<Server> ServerDetails { get; set; }

    }
}
