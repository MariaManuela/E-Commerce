using CreepySuits.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.ViewModels
{
    [Table("ShoppingCartViewModel")]
    public class ShoppingCartViewModel
    {
        [Key]
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}