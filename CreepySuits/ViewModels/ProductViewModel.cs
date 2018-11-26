using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreepySuits.Models;

namespace CreepySuits.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public decimal SearchResults { get; set; }
    }
}