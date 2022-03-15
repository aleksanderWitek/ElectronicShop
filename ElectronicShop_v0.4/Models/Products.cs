using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ElectronicShop_v0._4.Models
{
    public class Products
    {
        [Key]
        public int productID { get; set; }

        [Required]
        [Display(Name = "Category")]        
        public string category { get; set; }


        [Required]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Name leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string name { get; set; }

        [Display(Name = "Short discription")]
        public string shortDescription { get; set; }

        [Required]
        [Display(Name = "Price $")]
        public decimal price { get; set; }

        [Required]
        [Display(Name = "Amount of the product available")]
        [RegularExpression("^[0-9]+$",ErrorMessage = "Amount must be a whole number")]
        public int amount { get; set; }
        
        [RegularExpression("^[0-9]+$", ErrorMessage = "Amount must be a whole number")]
        public int? additionalAmount { get; set; }
    }
}