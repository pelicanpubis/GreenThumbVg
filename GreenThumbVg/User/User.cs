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

namespace GreenThumbVg.User
{
    public class User 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string Username { get; set; } = null!;
        // [EncryptColumn]
        public string Password { get; set; } = null!;


        public GardenModel Garden { get; set; } // Navigation property


        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Garden = new GardenModel(); // Create a new garden for each user

        }

        // Method to get garden plants for a specific user


        //första
        //public string Username { get; set; } // required?
        //public string Password { get; set; }
        //public List<PlantModel> Plants { get; set; }

        ////Konstruktor
        ////när en instans av USER skapas så skapas en tom travelslista

        //public User(string username, string password, List<PlantModel> plants) //behövs denna?
        //{

        //    Username = username;
        //    Password = password;
        //    Plants = plants; // Initialize Plants as a new list

        //}

        //public void AddPlant(PlantModel plant)
        //{
        //    Plants.Add(plant); // Method to add plants to the user
        //}
    }
}
