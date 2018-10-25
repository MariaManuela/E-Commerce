using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    [Table("Product")]
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public Decimal Price { get; set; }
        public string Stock { get; set; }
        public string Provider { get; set; }
        public string DeliveryType { get; set; }
        public string Category { get; set; }
        public string AgeCategory { get; set; }

        
    }
}