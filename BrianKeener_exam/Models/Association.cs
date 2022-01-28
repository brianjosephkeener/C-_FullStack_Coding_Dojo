using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrianKeener_exam.Models
{
    public class Association
    {
    [Key]
    public int AssociationId {get; set;}
    public int UserId {get; set;}
    public int ForumId {get; set;}
    public Forum Forum {get; set;}
    public User User {get; set;}
    }    
}
