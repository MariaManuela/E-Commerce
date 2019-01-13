using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    [Table("OrderHistory")]
    public class OrderHistory
    {
        [Key]
        public string OrderHistoryId { get; set; }

        public int RecordId { get; set; }

        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}