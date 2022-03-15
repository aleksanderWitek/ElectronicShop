using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicShop_v0._4.Models
{
    public class Customers
    {
        [Key]
        public int customerID { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        [StringLength(30, ErrorMessage = "Nickname leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string nickName { get; set; }

        [Required]
        [Display(Name = "Email adress")]
        [DataType(DataType.EmailAddress)]
        public string emailAdress { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "Password and Confirm Password must be the same")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}