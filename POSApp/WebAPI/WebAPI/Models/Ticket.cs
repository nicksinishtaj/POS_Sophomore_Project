using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Models
{
    public class TicketDetail
    {
        [Key]
        public int order_ID { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime order_DATETIME { get; set; }

        [Required] public int order_QTY { get; set; }

        [Required] public int order_Total { get; set; }

        [Required] public int prod_ID { get; set; }


    }
}