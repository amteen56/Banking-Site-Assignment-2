using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Banking_Site_Assignment_2.Models
{
    public class UserSignIn
    {
    
        [Required(ErrorMessage = "Please enter User ID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
