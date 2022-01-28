using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank_Account.Models
{
    public class Transaction
    {
    [Key]
    public int TransactionId {get; set;}
    public double Decimal {get; set;}
    public int UserId {get; set;}
    public User Creator {get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }    
}
