using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Customer
    {
        [Key]
        public int cust_ID { get; set; }

        [Column(TypeName = "char(30)")]
        public string cust_LName { get; set; }

        [Column(TypeName = "char(30)")]
        public string cust_FName { get; set; }

        [Column(TypeName = "char(1)")]
        public string cust_MI { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string cust_Address { get; set; }

        [Column(TypeName = "char(30)")]
        public string cust_City { get; set; }

        [Column(TypeName = "char(30)")]
        public string cust_State { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string cust_ZIP { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string cust_Card { get; set; }
    }
}
