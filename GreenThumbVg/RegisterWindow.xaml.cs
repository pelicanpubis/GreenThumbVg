using GreenThumbVg.Database;
using GreenThumbVg.User;
using System.Windows;



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


                    // Hämta användarnamn och lösenord från textfälten
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Password.Trim();


                    // Kontrollera om användarnamnet redan existerar

                    if (!UserManager.ValidateUsername(username))
                    {
                        MessageBox.Show("Username is already taken. Please choose a different username.");
                        return;
                    }


                    // Kontrollera om fälten för användarnamn och lösenord är tomma

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        if (string.IsNullOrEmpty(username))
                            warnUsername.Visibility = Visibility.Visible;
                        if (string.IsNullOrEmpty(password))
                            warnPassword.Visibility = Visibility.Visible;
                        return;
                    }


                    // Registrera en ny användare och hämta den skapade användaren

                    GreenThumbVg.User.User newUser = UserManager.RegisterUser(username, password);

                    if (newUser != null)  // Om registreringen lyckades, öppna huvudfönstret och stäng registreringsfönstret

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


        }
    }


}










