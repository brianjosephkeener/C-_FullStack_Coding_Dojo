using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrianKeener_exam.Models
{
public class User
{
    [Key]
    public int UserId {get;set;}
    [Required(ErrorMessage ="Name is required!")]
    [MinLength(2, ErrorMessage="Name must be 2 characters or longer!")]
    public string Name {get;set;}
    [EmailAddress]
    [Required(ErrorMessage = "Email is required!")]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required!")]
    [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
    public string Password {get;set;}
    public List<Association> Association {get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    // Will not be mapped to your users table!
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm {get;set;}
}    
}
