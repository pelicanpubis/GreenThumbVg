using GreenThumbVg.Database;
using GreenThumbVg.Models;
using GreenThumbVg.User;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using User = GreenThumbVg.User;



namespace GreenThumbVg
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                try
                {
                    warnUsername.Visibility = Visibility.Hidden;
                    warnPassword.Visibility = Visibility.Hidden;

                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Password.Trim();

                    if (!UserManager.ValidateUsername(username))
                    {
                        MessageBox.Show("Username is already taken. Please choose a different username.");
                        return;
                    }

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        if (string.IsNullOrEmpty(username))
                            warnUsername.Visibility = Visibility.Visible;
                        if (string.IsNullOrEmpty(password))
                            warnPassword.Visibility = Visibility.Visible;
                        return;
                    }

                    GreenThumbVg.User.User newUser = UserManager.RegisterUser(username, password);

                    if (newUser != null)
                    {
                        MainWindow mainWindow = new();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register the user. Please try again.");
                    }
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show("Please select a country");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }


            ////orginal
            //using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            //{


            //    try
            //    {

            //        // TODO: Refactor these to clear UI method
            //        warnUsername.Visibility = Visibility.Hidden;
            //        warnPassword.Visibility = Visibility.Hidden;

            //        // Läsa våra inputs
            //        string username = txtUsername.Text.Trim();
            //        string password = txtPassword.Password.Trim();


            //        //kollar med validateuser metoden om username är taget
            //        if (!UserManager.ValidateUsername(username))
            //        {
            //            // Visar varningsrute om användar namn inte är taget
            //            MessageBox.Show("Username is already taken. Please choose a different username.");
            //            return;
            //        }

            //        // Checka alla inputs
            //        if (username == "")
            //        {
            //            warnUsername.Visibility = Visibility.Visible;
            //            return;
            //        }

            //        if (password == "")
            //        {
            //            warnPassword.Visibility = Visibility.Visible;
            //            return;
            //        }

            //        if (username != "" && password != "")


            //        {


            //            GreenThumbVg.User.User newUser = UserManager.RegisterUser(username, password);

            //            GardenModel newGarden = new GardenModel()
            //            {
            //                //UserId = newUser.Id,
            //                //GardenId = newUser.Id,
            //            };

            //            context.Gardens.Add(newGarden); // Add the newGarden object to the context
            //            context.SaveChanges();


            //            if (newUser != null)
            //            {
            //                MainWindow mainWindow = new();
            //                mainWindow.Show();
            //                Close();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Failed to register the user. Please try again.");
            //            }
            //        }
            //    }




            //    catch (InvalidCastException ex)
            //    {
            //        MessageBox.Show("Please select a country");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"An error occurred: {ex.Message}"); // Display the specific exception message
            //    }




        }
        }


    }




        

    



