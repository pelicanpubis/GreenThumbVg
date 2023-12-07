using GreenThumbVg.User;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenThumbVg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

            // Läs innehållet i username och password-textrutorna

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Använd UserManager för att testa logga in

            bool isSuccessfulSignIn = UserManager.SignInUser(username, password);

            if (isSuccessfulSignIn) // Lyckas inloggningen... Öppna AccountWindow!
            {
                PlantWindow plantWindow = new();
                plantWindow.Show();
                Close();
            }
            else // Misslyckas inloggningen... Visa varningsmeddelande!
            {
                MessageBox.Show("Invalid username or password!", "Warning");
            }

            //PlantWindow plantWindow = new();
            //plantWindow.Show();
            //Close();

        }
    }
}