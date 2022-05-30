using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBank.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone {get; set;}

        [Required(ErrorMessage = "Password must be entered")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public string LoginError {get; set;}

        [NotMapped]
        public bool loginErrorCheck => !string.IsNullOrEmpty(LoginError);
    }

    public class LoginResponse
    {
        public string UserId { get; set; }
        public string SessionID { get; set; }
        public string JWT { get; set; }
    }
}