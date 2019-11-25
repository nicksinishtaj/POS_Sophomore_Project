using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RealServer
    {
        [Key]
        public int server_ID { get; set; }

        [Column(TypeName = "char(30)")]
        public string server_LNAME { get; set; }

        [Column(TypeName = "char(30)")]
        public string server_FNAME { get; set; }

        [Column(TypeName = "char(1)")]
        public string server_MI { get; set; }

        [Column(TypeName = "numeric(19,2)")]
        public double total_TIPS { get; set; }

        public virtual ICollection<Table> Tables { get; set; }

    }
}
