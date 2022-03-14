using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicShop_v0._4.Models
{
    public class Employees
    {
        [Key]
        public int employeeID { get; set; }

        [Display(Name = "Position")]
        public string position { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string lastName { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string city { get; set; }

        [Display(Name = "Phone number")]
        [StringLength(100, ErrorMessage = "Phone number leght must be between {2} - {0} characters", MinimumLength = 2)]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(100, ErrorMessage = "Username leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string userName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password leght must be between {2} - {0} characters", MinimumLength = 2)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("password",ErrorMessage = "Password and Confirm Password must be the same")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}