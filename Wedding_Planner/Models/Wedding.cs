using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
public class DateGreater : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "Date value should be in the future";
    }

    protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
    {
        DateTime dateValue = objValue as DateTime? ?? new DateTime();

        if (dateValue.Date < DateTime.Now.Date)
        {
           return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}
    public class Wedding
    {
    [Key]
    public int WeddingId {get; set;}
    [Required]
    public string Wedder_1 {get; set;}
    [Required]
    public string Wedder_2 {get; set;}
    [Required]
    [DateGreater]
    public DateTime WeddingDate {get; set;}
    [Required]
    public string Wedding_Address {get; set;}
    public List<Association> Association {get; set;}
    public int UserId {get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }    
}
