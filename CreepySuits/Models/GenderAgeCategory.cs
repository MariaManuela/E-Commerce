using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    public class GenderAgeCategory
    {
        public int GenderAgeCategoryId { get; set; }
        public string GenderAgeCategoryName { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}