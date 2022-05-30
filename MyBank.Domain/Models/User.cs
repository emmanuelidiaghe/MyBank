using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBank.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public Title Title { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string BVN { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string NIN { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string State { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public bool Agree { get; set; }

        public DateTime DateCreated {get; set;}

        [Required(ErrorMessage = "Field cannot be empty")]
        public Base64FormattingOptions ID_Doc { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public Gender GenderSelected { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public MaritalStatus MaritalStatusSelected { get; set; }

        [NotMapped]
        public string LoginError {get; set;}

        [NotMapped]
        public bool loginErrorCheck => !string.IsNullOrEmpty(LoginError);
    }

    public enum Title
    {
        Mr,
        Mrs,
        Ms,
        Dr,
        Prof,
        Barr
    }

    public enum Gender
    {
        Male,
        Female,
        Others
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Divorced,
        Others
    }
}