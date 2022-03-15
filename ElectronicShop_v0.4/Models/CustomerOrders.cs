using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectronicShop_v0._4.Models
{
    public class CustomerOrders
    {
        [Key]
        public int orderID { get; set; }

        public int productID { get; set; }

        [ForeignKey(nameof(productID))]
        public virtual Products vistrualProduct { get; set; }

        public int customerID { get; set; }
        [ForeignKey(nameof(customerID))]
        public virtual Customers customerIDVirtual { get; set; }

        [Required]
        [Display(Name = "Product name")]
        [StringLength(100, ErrorMessage = "Max lenght is {0} characters")]
        public string productName { get; set; }

        [Required]
        [Display(Name = "Price $")]
        public decimal price { get; set; }

        [Required]
        [Display(Name = "Amount of the product available")]
        public int amount { get; set; }
    }
}