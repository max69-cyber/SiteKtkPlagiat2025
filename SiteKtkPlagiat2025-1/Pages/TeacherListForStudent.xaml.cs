using Database;
using SiteKtkPlagiatAnother;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace SiteKtkPlagiat2025_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherListForStuden.xaml
    /// </summary>
    public partial class TeacherListForStudent : Page, INotifyPropertyChanged
    {
        private Database.CollegeEntities _database;
        private ObservableCollection<Account> _teachers;
        public ObservableCollection<Account> Teachers
        {
            get => _teachers;
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        public TeacherListForStudent(Database.CollegeEntities database)
        {
            InitializeComponent();
            DataContext = this;
            Teachers = new ObservableCollection<Account>();
            _database = database;
            List<Account> teacherNames = _database.Accounts
            .Where(user => user.Role == 2)
            .ToList();
            foreach (var teacher in teacherNames)
            {
                Teachers.Add(teacher);
            }
        }

        private void OpenStudentMainPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.MainMenuForStudentPage);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
