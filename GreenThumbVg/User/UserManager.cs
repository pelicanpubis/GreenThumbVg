using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenThumbVg.Models;
using GreenThumbVg.Database;
using System.Numerics;
using UserNamespace;

namespace GreenThumbVg.User
{
    public static class UserManager
    {




        // Referens till inloggad användare
        public static User? SignedInUser { get; private set; }




        //denna metoden registrerar en ny user
        public static User? RegisterUser(string username, string password)
        {




            using (var context = new GreenThumbVgDbContext())
            {
                if (ValidateUsername(username))
                {
                    User newUser = new User(username, password); // Create a new user with username and password

                    // Add the new user to the Users list
                    context.Users.Add(newUser);
                    context.SaveChanges(); // Save changes to generate the UserId

                    // At this point, newUser.Id will contain the auto-generated Id

                    GardenModel newGarden = new GardenModel
                    {
                        UserId = newUser.Id // Associate the garden with the newly created user
                    };

                    context.Gardens.Add(newGarden);
                    context.SaveChanges();

                    return newUser;
                }

                return null;

                //orginal
                //using (var context = new GreenThumbVgDbContext())
                //{
                //    if (ValidateUsername(username))
                //    {
                //        User newUser = new User();

                //        // Add the new user to the Users list
                //        context.Users.Add(newUser);
                //        context.SaveChanges(); // Save changes to generate the UserId

                //        // At this point, newUser.Id will contain the auto-generated Id

                //        GardenModel newGarden = new GardenModel()
                //        {
                //            UserId = newUser.Id,
                //            //GardenId = newUser.

                //            //GardenId = newUser.Garden.GardenId

                //        };

                //        context.Gardens.Add(newGarden);
                //        context.SaveChanges();

                //        return newUser;
                //    }

                //    return null;
            }


    }




        //lägger till user i user listan,
        public static bool AddUser(User user)
        {
            //lägg till logik

            return false;
        }

        //metod som ska ta bort från user from listan.
        public static void RemoveUser(User user)
        {
            //{
            //    Users.Remove(user);
            //}
        }




        //uppdatera användernamn om det nya användarnamnet är true?
        public static bool UpdateUsername(User user, string newUsername)
        {
            //logik
            return true;
        }


        //Metod: Kollar om användar namn inte är taget
        public static bool ValidateUsername(string username)
        {

            using (var context = new GreenThumbVgDbContext())
            {
                // Check if any user in the database has the provided username
                bool usernameExists = context.Users.Any(u => u.Username == username);

                // If the username exists, return false; otherwise, return true
                return !usernameExists;

             

            }

     
        }


        //metod som loggar in användaren
        public static bool SignInUser(string username, string password)
        {

            using (var context = new GreenThumbVgDbContext()) // Replace with your actual DbContext class
            {
                // Check if there's a user with the provided username and password in the database
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // User found in the database
                    SignedInUser = user;
                    return true;
                }

                return false;
            }

   
        }

        public static void SignOutUser() //kallas på sign out knappen
        {
            SignedInUser = null;
        }



        



    }

    }






