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
    /// Логика взаимодействия для MainMenuForTeacher.xaml
    /// </summary>
    public partial class MainMenuForTeacher : Page
    {
        public MainMenuForTeacher()
        {
            InitializeComponent();
            NameBox.Text = $"{PageController.CurrentUser.FullName} | (Учитель)";
        } 

        private void OpenSchedule(object a, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.TeacherSchedulePage);
        }

        private void SignOut(object a, RoutedEventArgs e)
        {
            PageController.CurrentUser = null;
            NavigationService.Navigate(PageController.AuthorisationPage);
        }
        private void OpenTeacherList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.TeacherListForTeacherPage);
        }

        //https://avatars.mds.yandex.net/i?id=aa87ec06e9c3c85d0a0af780c1382ffb708cc852-3593759-images-thumbs&n=13
    }
}
