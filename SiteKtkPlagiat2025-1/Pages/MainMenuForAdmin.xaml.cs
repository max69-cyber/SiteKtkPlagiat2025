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
    /// Логика взаимодействия для MainMenuForAdmin.xaml
    /// </summary>
    public partial class MainMenuForAdmin : Page
    {
        public MainMenuForAdmin()
        {
            InitializeComponent();
        }

        private void OpenStudentochki(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.StudentochkiPage);
        }
    }
}
