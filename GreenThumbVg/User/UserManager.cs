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
    public static class UserManager // En statisk klass för att hantera användare
    {

        // Referens till inloggad användare som är nullbar
        public static User? SignedInUser { get; private set; } // Referens till den inloggade användaren



        // Metod för att registrera en ny användare
        public static User? RegisterUser(string username, string password) // Skapar en kontext av databasen
        {

            using (var context = new GreenThumbVgDbContext())
            {
                if (ValidateUsername(username)) // Validerar användarnamnet
                {
                    User newUser = new User(username, password);  // Skapar en ny användare med användarnamn och lösenord
                   
                    
                    context.Users.Add(newUser); // Lägger till den nya användaren i databasen
                    context.SaveChanges(); // Spara ändringar för att generera UserId


                    GardenModel newGarden = new GardenModel
                    {
                        UserId = newUser.Id  // Kopplar trädgården till den nyss skapade användaren
                    };

                    context.Gardens.Add(newGarden); // Lägger till trädgården i databasen
                    context.SaveChanges(); // Spara ändringar

                    return newUser;  // Returnerar den nya användaren
                }

                return null;  // Returnerar null om användarnamnet redan finns

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


        // Metod för att validera användarnamn (kollar om det inte redan existerar)
        public static bool ValidateUsername(string username)
        {

            using (var context = new GreenThumbVgDbContext())
            {
                // Kollar om någon användare i databasen har det angivna användarnamnet
                bool usernameExists = context.Users.Any(u => u.Username == username);

                // Om användarnamnet redan existerar returneras false, annars returneras true
                return !usernameExists;

             

            }

     
        }


        // Metod för att logga in en användare
        public static bool SignInUser(string username, string password)
        {

            using (var context = new GreenThumbVgDbContext()) // Replace with your actual DbContext class
            {
                // Kollar om det finns en användare med det angivna användarnamnet och lösenordet i databasen
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null) // Om användaren hittas i databasen
                {
                    SignedInUser = user; // Sätter den inloggade användaren till den hittade användaren

                    return true; // Returnerar true för att indikera att inloggningen var framgångsrik
                }

                return false;
            }

   
        }

        // Metod för att logga ut användaren (nollställer den inloggade användaren)
        public static void SignOutUser() //kallas på sign out knappen
        {
            SignedInUser = null; // Sätter den inloggade användaren till null för att logga ut
        }

    }

    }






