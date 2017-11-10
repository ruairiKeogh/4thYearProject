using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    [Table("users")]
    public class User : ApplicationUser
    {
        [Key]
        int UserID { get; set; }
        string FirstName { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        public User(string firstnameIn, string emailIn, string passwordIn)
        {
            FirstName = firstnameIn;
            Email = emailIn;
            Password = passwordIn;
        }
    }
}