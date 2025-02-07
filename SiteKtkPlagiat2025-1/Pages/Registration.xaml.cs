using Database;
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
    /// Логика взаимодействия для Regisration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private static Database.CollegeEntities _database;
        public Registration(Database.CollegeEntities database)
        {
            InitializeComponent();
            _database = database;
        }

        private void OnSignIn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.AuthorisationPage);
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            int roleConverter = 0;
            if (RoleComboBox.Text == "Студент")
            {
                roleConverter = 1;
            }
            else if (RoleComboBox.Text == "Преподаватель")
            {
                roleConverter = 2;
            }
            else
            {
                MessageBox.Show("Значение в комбобокс сломалось!");
            }

            var newUser = new Account
            {
                FullName = NameBox.Text,
                Login = LoginBox.Text,
                Password = PasswordBox.Text,
                Role = roleConverter,
                CreatedAt = DateTime.Now
            };

            _database.Accounts.Add(newUser);
            _database.SaveChanges();

            NavigationService.Navigate(PageController.AuthorisationPage);
        }

    }
}
