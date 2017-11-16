using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectAPI.Context
{
    public class UserContext : DbContext 
    {
        public DbSet <User> users { get; set; }
    }
}