using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Models
{
    public class Ticket
    {
        [Key] [Required] public int order_ID { get; set; }

        [Required] public DateTime order_DATETIME { get; set; }

        [Required] public int order_QTY { get; set; }

        [Required] public int order_Total { get; set; }

        [Required] public int prod_ID { get; set; }


    }
}