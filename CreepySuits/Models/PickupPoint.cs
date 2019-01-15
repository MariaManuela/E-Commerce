using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    [Table("PickupPoint")]
    public class PickupPoint
    {
        public int PickupPointId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string PickupName { get; set; }
        public string Address { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}