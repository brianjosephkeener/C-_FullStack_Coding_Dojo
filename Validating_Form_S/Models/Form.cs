using System;
using System.ComponentModel.DataAnnotations;

namespace Validating_Form_S.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage="Age must be a positive number")]
        public int Age { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Field must be 8 characters or more")]
        public string Password { get; set; }
    }
}