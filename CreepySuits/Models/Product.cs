using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{

    //public enum Categ
    //{
    //    Dresses,
    //    Top,
    //    Bottom,
    //    Shoes,
    //    Accessories,
    //    Jackets,
    //    Hats ,
    //    Costumes
    //}


    //public enum AgeCateg
    //{
    //    Female,
    //    Male,
    //    Kids
    //}

    [Table("Product")]
    public class Product
    {
       [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specifications { get; set; }
        public decimal Price { get; set; }
        public string Stock { get; set; }
        public string Provider { get; set; }
        public string DeliveryType { get; set; }
      //  public string Category { get; set; }
        public string AgeCategoryName { get; set; }
        public string PicUrl { get; set; }
        
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }




    }


}