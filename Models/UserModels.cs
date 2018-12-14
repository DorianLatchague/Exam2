using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Exam2.Models
{    
    public class Users
    {
        [Key]
        public int UsersId { get;set; }
        public string Email { get;set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string Password { get;set; }
        public DateTime CreatedAt { get;set; } = DateTime.Now;
        public DateTime UpdatedAt { get;set; } = DateTime.Now;
        public List<Activities> Activities { get;set; }
        public List<Participants> Participating { get;set; }
    }
    public class PasswordValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                bool isTrue = true;
                if(!(value as string).Any(ch => !Char.IsLetterOrDigit(ch)))
                {
                    isTrue = false;
                }
                if(!(value as string).Any(ch => Char.IsLetter(ch)))
                {
                    isTrue = false;
                }
                if(!(value as string).Any(ch => Char.IsDigit(ch)))
                {
                    isTrue = false;
                }
                if(isTrue == false)
                {
                    return new ValidationResult("Your Password must contain at least one letter, one digit and one special character.");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class NameValidatorAttribute : ValidationAttribute
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool isTrue = true;
                if((value as string).Any(ch => Char.IsDigit(ch)))
                {
                    isTrue = false;
                }
                if(isTrue == false)
                {
                    return new ValidationResult("Names can only contain non-numeric characters");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class Register
    {
        [Required(ErrorMessage="Please enter an First Name")]
        [NameValidator]
        [MinLength(2, ErrorMessage="Your First Name must be at least 2 letters long")]
        public string FirstName { get;set; }
        [Required(ErrorMessage="Please enter an Last Name")]
        [NameValidator]
        [MinLength(2, ErrorMessage="Your Last Name must be at least 2 letters long")]
        public string LastName { get;set; }
        [Required(ErrorMessage="Please enter an Email Address")]
        [EmailAddress(ErrorMessage="Invalid Email Address")]
        public string Email { get;set; }
        [Required(ErrorMessage="Please enter a Password")]
        [PasswordValidator]
        [MinLength(8, ErrorMessage="Your Password must be at least 8 characters long")]
        public string Password { get;set; }
        [Required(ErrorMessage="Please enter a Password")]
        [Compare("Password", ErrorMessage="Your Password and Password Confirmation must match")]
        public string PassConf { get;set; }
    }
    public class Login
    {
        [Required(ErrorMessage="Please enter your Email")]
        public string LogEmail { get;set; }
        [Required(ErrorMessage="Please enter your Password")]
        public string LogPassword { get;set; }
    }
}