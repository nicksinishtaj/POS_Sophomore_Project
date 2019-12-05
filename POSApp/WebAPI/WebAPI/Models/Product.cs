using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Product
    {
        [Key]
        public int prod_ID { get; set; }

        [Column(TypeName = "varchar(35)")]
        public string prod_NAME { get; set; }

        [Column(TypeName = "numeric(19,2)")]
        public double prod_COST { get; set; }

        public int prod_COUNT { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }




    }
}
