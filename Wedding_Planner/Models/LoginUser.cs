using System;
using Wedding_Planner.Models;
using System.ComponentModel.DataAnnotations;
public class LoginUser
{
    [Required]
    public string Email {get; set;}
    [Required]
    public string Password { get; set; }
}

