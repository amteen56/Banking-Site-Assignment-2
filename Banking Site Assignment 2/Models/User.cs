﻿using System.ComponentModel.DataAnnotations;

namespace Banking_Site_Assignment_2.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter User ID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string UserPw { get; set; }

        [Compare("UserPw", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string UserPw2 { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter DOB")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please enter Age")]
        public string age { get; set; }

        [Required(ErrorMessage = "Please enter Contact No")]
        public string ContactNo { get; set; }
    }
}