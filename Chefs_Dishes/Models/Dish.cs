using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_Dishes.Models
{
    public class Dish
    {
    [Key]
    public int DishId {get; set;}
    public string Name {get; set;}
    public string Calories {get; set;}
    public string Tastiness {get; set;}
    public string Description {get; set;}
    public int ChefId {get; set;}
    public Chef Creator {get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }    
}
