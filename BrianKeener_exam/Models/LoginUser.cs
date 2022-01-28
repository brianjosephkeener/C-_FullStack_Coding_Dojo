using System;
using BrianKeener_exam.Models;
using System.ComponentModel.DataAnnotations;
public class LoginUser
{
    [Required]
    public string Email {get; set;}
    [Required]
    public string Password { get; set; }
}

