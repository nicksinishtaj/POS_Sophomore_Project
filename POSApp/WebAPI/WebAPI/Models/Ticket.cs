using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Models
{
    public class Ticket
    {
        [Key]
        public int order_ID { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime order_DATETIME { get; set; }

        public int order_QTY { get; set; }

        public double order_Total { get; set; }

        public int prod_ID { get; set; }

        public string order_Name { get; set; }

        public double tip { get; set; }

        public double deposit { get; set; }

        public bool isOpen { get; set; }

        public int server_ID { get; set; }

        [ForeignKey("prod_ID")]
        public virtual Product Product { get; set; }


    }
}