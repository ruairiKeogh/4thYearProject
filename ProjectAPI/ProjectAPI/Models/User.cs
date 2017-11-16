using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectAPI.Helpers;

namespace ProjectAPI.Models
{
    [Table("users")]
    public class User : ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is a Required Field" )]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Email is a Required Field")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is a Required Field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please Confirm Your Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Are You a Manager? is a Required Field")]
        public bool IsManager { get; set; }

        List<Fixture> fixtures;

        public User(string firstnameIn, string emailIn, string passwordIn)
        {
            FirstName = firstnameIn;
            Email = emailIn;
            Password = passwordIn;
        }
    }
}