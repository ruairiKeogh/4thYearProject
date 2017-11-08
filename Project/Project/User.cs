using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        int id { get; set; }
        string firstName { get; set; } // Name of User
        string email { get; set; } // Email of User
        string password { get; set; } // Password of User - Will be encrypteqd
        bool manager { get; set; } // If manager or non manager user

        public User(string nameIn, string emailIn, string pwIn, bool managerIn)
        {
            firstName = nameIn;
            email = emailIn;
            password = pwIn;
            manager = managerIn;
        }
    }
}