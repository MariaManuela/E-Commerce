using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreepySuits.Models;

namespace CreepySuits.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public decimal NumberOfProd { get; set; }
    }
}