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
    /// Логика взаимодействия для MainMenuForStudent.xaml
    /// </summary>
    public partial class MainMenuForStudent : Page
    {
        public MainMenuForStudent()
        {
            InitializeComponent();
            NameBox.Text = $"{PageController.CurrentUser.FullName} | (Студент)";
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            PageController.CurrentUser = null;
            NavigationService.Navigate(PageController.AuthorisationPage);
        }

        private void OpenSchedule(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.StudentSchedulePage);
        }

        private void OpenTeacherList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.TeacherListForStudentPage);

        }
    }
}
