using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Banking_Site_Assignment_2.Models
{
    public class Installment_Form
    {
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
        [Required(ErrorMessage = "Please enter Salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Please enter Dependencies")]
        public string Dependencies { get; set; }
        [Required(ErrorMessage = "Please enter PermonthInstallment")]
        public double PermonthInstallment { get; set; }
        [Required(ErrorMessage = "Please enter InerestRae")]
        public double InerestRae { get; set; }
        [Required(ErrorMessage = "Please enter NoOfYear")]
        public int NoOfYear { get; set; }
    }
}