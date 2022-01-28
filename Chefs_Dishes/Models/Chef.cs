using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    public string DateOfBirth {get; set;}
    public List<Dish> CreatedDishes {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}    
}
