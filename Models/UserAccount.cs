using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YourSay.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter your surname")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your Username")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}