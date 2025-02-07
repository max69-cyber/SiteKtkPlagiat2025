using SiteKtkPlagiat2025_1.Pages;
using SiteKtkPlagiatAnother.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SiteKtkPlagiatAnother
{
    internal class PageController
    {

        private static Database.CollegeEntities _database;
        private static Database.CollegeEntities Database
        {
            get
            {
                if (_database == null)
                {
                    try
                    {
                        _database = new Database.CollegeEntities();
                        System.Windows.MessageBox.Show("Соединение с базой данных установлено успешно.", "Статус подключения", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Статус подключения", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Используется существующее подключение к базе данных.", "Статус подключения", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }

                return _database;
            }
        }
        public static Database.Account CurrentUser { get; set; }

        private static Authorisation _authorisationPage;
        public static Authorisation AuthorisationPage 
        {
            get 
            {
                if (_authorisationPage == null) 
                {
                    _authorisationPage = new Authorisation(Database);
                }
                return _authorisationPage;

            }
            
        }

        private static Registration _registrationPage;
        public static Registration RegistrationPage
        {
            get
            {
                if (_registrationPage == null)
                {
                    _registrationPage = new Registration(Database);
                }
                return _registrationPage;

            }

        }


        private static MainMenuForStudent _mainMenuForStudentPage;
        public static MainMenuForStudent MainMenuForStudentPage
        {
            get
            {
                if (_mainMenuForStudentPage == null)
                {
                    _mainMenuForStudentPage = new MainMenuForStudent();
                }
                return _mainMenuForStudentPage;

            }

        }

        private static MainMenuForTeacher _mainMenuForTeacherPage;
        public static MainMenuForTeacher MainMenuForTeacherPage
        {
            get
            {
                if (_mainMenuForTeacherPage == null)
                {
                    _mainMenuForTeacherPage = new MainMenuForTeacher();
                }
                return _mainMenuForTeacherPage;

            }

        }


        private static StudentSchedule _studentSchedulePage;
        public static StudentSchedule StudentSchedulePage
        {
            get
            {
                if (_studentSchedulePage == null)
                {
                    _studentSchedulePage = new StudentSchedule(Database);
                }
                return _studentSchedulePage;

            }

        }



        private static TeacherSchedule _teacherSchedulePage;
        public static TeacherSchedule TeacherSchedulePage
        {
            get
            {
                if (_teacherSchedulePage == null)
                {
                    _teacherSchedulePage = new TeacherSchedule();
                }
                return _teacherSchedulePage;

            }

        }

        private static Studentochki _studentochkiPage;
        public static Studentochki StudentochkiPage
        {
            get
            {
                if (_studentochkiPage == null)
                {
                    _studentochkiPage = new Studentochki();
                }
                return _studentochkiPage;

            }

        }



        private static TeacherListForStudent _teacherListForStudentPage;
        public static TeacherListForStudent TeacherListForStudentPage
        {
            get
            {
                if (_teacherListForStudentPage == null)
                {
                        _teacherListForStudentPage = new TeacherListForStudent(Database);
                    }
                return _teacherListForStudentPage;

            }

        }


        private static TeacherListForTeacher _teacherListForTeacherPage;
        public static TeacherListForTeacher TeacherListForTeacherPage
        {
            get
            {
                if (_teacherListForTeacherPage == null)
                {
                    _teacherListForTeacherPage = new TeacherListForTeacher(Database);
                }
                return _teacherListForTeacherPage;

            }

        }

    }
}
