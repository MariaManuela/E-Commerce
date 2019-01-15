using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreepySuits.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public Product Product { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public List<OrderHistory> OrderHistory { get; set; }
        [ScaffoldColumn(false)]
        public PaymentTypeEnum PaymentType { get; set; }
        [ScaffoldColumn(false)]
        public DeliveryTypeEnum DeliveryType { get; set; }
        [ScaffoldColumn(false)]
       
        [DisplayName("Card Number")]
        [StringLength(16)]
        public string NrCard { get; set; }

        [ScaffoldColumn(false)]
        
        [DisplayName("Expiration Date")]
        public string ExpDate { get; set; }
   
        [DisplayName("Security Code")]
        [StringLength(3)]
        [ScaffoldColumn(false)]
        public string SecurityCode { get; set; }

        [DisplayName("Card type")]
        [ScaffoldColumn(false)]
        public CardType Type { get; set; }
        
        [DisplayName("City:")]
        [ScaffoldColumn(false)]
        public PickUpPointCity PCity { get; set; }
        
        [DisplayName("Street:")]
        [ScaffoldColumn(false)]
        public PickUpPointStreet PStreet { get; set; }



        public enum PickUpPointCity
        {
            [Display(Name = "Craiova")]
            Craiova,
            [Display(Name = "Cluj")]
            Cluj ,
            [Display(Name = "Timisoara")]
            Timisoara,
            [Display(Name = "Slatina")]
            Slatina,
            [Display(Name = "Caracal")]
            Caracal,
            [Display(Name = "Bucuresti")]
            Bucuresti,
            [Display(Name = "Rm.Valcea")]
            RmValcea,
            [Display(Name = "Constanta")]
            Constanta
        }

        public enum PickUpPointStreet
        {
            [Display(Name = "Str. Tei, nr. 22")]
            Tei_nr_22,
            [Display(Name = "Str. Bujor, nr. 44")]
            Bujor_nr_44,
            [Display(Name = "Str. Caracal, nr. 25")]
            Caracal_nr_25,
            [Display(Name = "Str. Garofitei, nr. 116")]
            Garofitei_nr_116,
            [Display(Name = "Str. Nicolae Titulescu, nr. 14")]
            NicolaeTitulescu_nr_14,
            [Display(Name = "Str. Victoria, nr. 20")]
            Victoria_nr_20,
            [Display(Name = "Str. 1 Decembrie, nr. 19")]
            _1_Decembrie_19

        }

     
        
        public enum PaymentTypeEnum
        {
            Card,
            COD
        }
        public enum DeliveryTypeEnum
        {
            CustomerAddress,
            PickupPoint
        }

        public enum CardType
        {
            [Display(Name = "Master Card")]
            MasterCard,
            [Display(Name = "Visa")]
            Visa,
            [Display(Name = "American Express")]
            AmericanExpress,
            [Display(Name = "Discover Network")]
            DiscoverNetwork,
            [Display(Name = "JCB")]
            JCB
        }
    }
}