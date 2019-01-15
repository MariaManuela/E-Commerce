using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    [Table("Card")]
    public class Card
    {
        [ScaffoldColumn(false)]
        public int CardId { get; set; }
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Card number is required")]
        [DisplayName("Card Number")]
        [StringLength(16)]
        public string NrCard { get; set; }
        [Required(ErrorMessage = "This field should contain a date")]
        [DisplayName("Epiration Date")]
        public System.DateTime ExpDate { get; set; }
        [Required(ErrorMessage = "Security code is required")]
        [DisplayName("Security Code")]
        [StringLength(3)]
        public string SecurityCode { get; set; }
        [Required(ErrorMessage = "Card type is required")]
        [DisplayName("Card type")]
        public string Type { get; set; }
        [ScaffoldColumn(false)]
        public Product Product { get; set; }
        [ScaffoldColumn(false)]
        public Order Order { get; set; }
    }
}