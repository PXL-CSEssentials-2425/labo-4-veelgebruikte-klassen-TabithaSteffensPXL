using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input velden: userNameTextBox en passwordTextBox
        /// Output veld: resultTextBlock
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            int passwordStrength = 0;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                resultTextBlock.Text = "Please enter a username or a password.";
                return;
            }
            if (!password.Contains(username))
            {
                passwordStrength++;
            }
            if (password.Length >= 10)
            {
                passwordStrength++;
            }
            bool hasDigit = false;
            bool hasUpper = false;
            bool hasLower = false;
            foreach (char c in password.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;

                }
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                if (char.IsLower(c))
                {
                    hasLower = true;
                }
            }
            if (hasDigit)
            {
                passwordStrength++;
            }
            if (hasUpper)
            {
                passwordStrength++;
            }
            if (hasLower)
            {
                passwordStrength++;
            }

            //if (passwordStrength == 5)
            //{
            //    resultTextBlock.Text = "Strong Password";
            //} else if (passwordStrength == 4)
            //{
            //    resultTextBlock.Text = "Ok Password";
            //} else
            //{
            //    resultTextBlock.Text = "Weak Password";
            //}

            switch (passwordStrength)
            {
                case 5:
                    resultTextBlock.Text = "Strong Password.";
                    resultTextBlock.Foreground = Brushes.Green;
                    break;
                case 4:
                    resultTextBlock.Text = "Ok Password.";
                    resultTextBlock.Foreground = Brushes.Orange;
                    break;
                default:
                    resultTextBlock.Text = "Weak Password.";
                    resultTextBlock.Foreground = Brushes.Red;
                    break;

            }
            if (passwordStrength <= 3)
            {
                StringBuilder suggestedPassword = new StringBuilder();
                Random rng = new Random();
                for (int i = 0; i < 5; i++)
                {

                    char randomLetter = (char)rng.Next('a', 'z' + 1);
                    suggestedPassword.Append(randomLetter);
                }
                for (int j = 0; j < 5; j++)
                {
                    int randomNumbers = rng.Next(0, 9);
                    suggestedPassword.Append(randomNumbers);
                }
                for (int k = 0; k < 2; k++)
                {
                    char randomCapitalLetter = (char)rng.Next('A', 'Z' + 1);
                    suggestedPassword.Append(randomCapitalLetter);
                }
                int amountExcitement = rng.Next(1, 6);
                do
                {
                    suggestedPassword.Append("!");
                    amountExcitement--;

                } while (amountExcitement > 1);

                string shownPassword = suggestedPassword.ToString();
                MessageBoxResult result = MessageBox.Show($"\t Use suggested password? \r\n \t {shownPassword}", "Weak Password", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    passwordTextBox.Text = shownPassword;
                }
                else
                {

                }
            }
        }
    }
}
