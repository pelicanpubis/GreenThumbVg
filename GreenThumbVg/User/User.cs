using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace GreenThumbVg.User
{
    public class User 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string Username { get; set; } = null!;


        [EncryptColumn]
        public string Password { get; set; } = null!;


        public GardenModel Garden { get; set; } // Navigation property till trädgården för användaren



        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Garden = new GardenModel();

        }

       
    }
}
