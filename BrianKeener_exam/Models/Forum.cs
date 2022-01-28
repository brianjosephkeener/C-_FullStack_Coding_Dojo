using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrianKeener_exam.Models
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
    public class Forum
    {
    [Key]
    public int ForumId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public string Description {get; set;}
    [DateGreater]
    public DateTime ForumDate {get; set;}
    public string Time {get; set;}
    public int Duration {get; set;}
    public string DurationHMD {get; set;}
    public List<Association> Association {get; set;}
    public int UserId {get; set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }    
}
