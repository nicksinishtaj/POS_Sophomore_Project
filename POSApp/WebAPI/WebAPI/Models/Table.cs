using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Table
    {
        [Key]
        public int table_ID { get; set; }

        [Column(TypeName = "bit")]
        public bool table_res { get; set; }

        public int server_ID { get; set; }

        [ForeignKey("server_ID")]
        public virtual RealServer Server { get; set; }
    }
}
