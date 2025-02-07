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

namespace SiteKtkPlagiatAnother.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorisation.xaml
    /// </summary>
    public partial class Authorisation : Page
    {
        private static Database.CollegeEntities _database;
        public Authorisation(Database.CollegeEntities database)
        {
            InitializeComponent();
            _database = database;
        }

        private void OnSignUp(object sender, RoutedEventArgs e) 
        {
            LoginBox.Clear();
            PasswordBox.Clear();
            NavigationService.Navigate(PageController.RegistrationPage);
        }

        private void OpenMainMenu(object sender, RoutedEventArgs e)
        {
            var user = _database.Accounts.FirstOrDefault(u => u.Login == LoginBox.Text && u.Password == PasswordBox.Text);
            if (user == null)
            {
                MessageBox.Show("User don't exists!");
                LoginBox.Clear();
                PasswordBox.Clear();
            }
            else
            {
                PageController.CurrentUser = user;
                if(user.Role == 1)
                {
                    NavigationService.Navigate(PageController.MainMenuForStudentPage);
                }
                else if (user.Role == 2)
                {
                    NavigationService.Navigate(PageController.MainMenuForTeacherPage);
                }
                LoginBox.Clear();
                PasswordBox.Clear();

            }

        }
    }
}
