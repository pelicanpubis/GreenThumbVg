using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenThumbVg.Models;

namespace GreenThumbVg.User
{
    public static class UserManager
    {

        // Lista som lagrar användare
        public static List<IUser> Users { get; private set; } = new List<IUser>
{
        // Startanvändare med fördefinierade växter
        new User("user", "password")
        {
        Plants = new List<PlantModel> // Assuming Plants is a property in User class
        {
            new PlantModel("Rose") // Creating PlantModel with a name
        }
    },
};



        // Referens till inloggad användare
        public static IUser? SignedInUser { get; private set; }





        //denna metoden registrerar en ny user
        public static User? RegisterUser(string username, string password)
        {

            // Kontrollera om användarnamnet är unikt
            if (ValidateUsername(username))
            {
                //om det är valid så skapas en ny user objekt och initialiserar dens properties
                User newUser = new User(username, password)
                {
                    Plants = new List<PlantModel>()
                };
                //lägger till den nya user i users listan
                Users.Add(newUser);

                return newUser;
            }

            return null;

        }




        //lägger till user i user listan,
        public static bool AddUser(IUser user)
        {
            //lägg till logik

            return false;
        }

        //metod som ska ta bort från user from listan.
        public static void RemoveUser(IUser user)
        {
            //{
            //    Users.Remove(user);
            //}
        }




        //uppdatera användernamn om det nya användarnamnet är true?
        public static bool UpdateUsername(IUser user, string newUsername)
        {
            //logik
            return true;
        }


        //Metod: Kollar om användar namn inte är taget
        public static bool ValidateUsername(string username)
        {

            //loopar genom users listan för att se om användarnamnet är taget
            foreach (var user in Users)
            {
                if (user.Username == username)
                {

                    //om namnet är redan taget så kommer valid namn är retunera false
                    return false;
                }
            }
            //annars sant
            return true;
        }


        //metod som loggar in användaren
        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // User found!

                    SignedInUser = user;

                    return true;
                }
            }

            return false;
        }

        public static void SignOutUser() //kallas på sign out knappen
        {
            SignedInUser = null;
        }

        public static List<PlantModel> GetAllUsersPlants()
        {
            // Skapar en lista för att samla alla users resor
            List<PlantModel> allTravels = new List<PlantModel>();


            // Loopa igenom varje användare i Users listan
            foreach (var user in Users)
            {

                if (user is User userAsUser)
                {
                    {
                        // Lägg till alla resor från användaren i listan allTravels
                        allTravels.AddRange(userAsUser.Plants);
                    }
                }
            }

            return allTravels;
        }


    }



}


