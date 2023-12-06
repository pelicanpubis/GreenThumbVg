using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumbVg.User
{
    public class User: IUser
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public List<PlantModel> Plants { get; set; }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
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
