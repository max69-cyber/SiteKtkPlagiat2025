using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для StudentSchedule.xaml
    /// </summary>
    public partial class StudentSchedule : Page
    {
        private Database.CollegeEntities _database;
        public ObservableCollection<Schedule> Schedule { get; set; }
        private Dictionary<string, List<Schedule>> GroupLessonsByDay(IEnumerable<Schedule> lessons)
        {
            // Группируем занятия по дням недели
            return lessons
                .GroupBy(lesson => lesson.StartTime.DayOfWeek.ToString()) // Группируем по дню недели
                .ToDictionary(
                    g => g.Key,          // Ключ — день недели
                    g => g.OrderBy(lesson => lesson.StartTime).ToList() // Сортировка занятий по времени
                );
        }
        public StudentSchedule(Database.CollegeEntities database)
        {
            InitializeComponent();
            DataContext = this;
            _database = database;
            WeekSelector.SelectedIndex = 0;
            LoadScheduleForWeek(1);

        }

        private void OpenMainMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.MainMenuForStudentPage);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WeekSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                int selectedWeek = int.Parse(selectedItem.Tag.ToString());
                LoadScheduleForWeek(selectedWeek);
            }
        }

        private int GetLessonNumber(DateTime startTime)
        {
            bool isLesson = true;

            TimeSpan lessonStart = new TimeSpan(8, 0, 0); // Начало первого занятия
            TimeSpan timeSinceStart = startTime.TimeOfDay - lessonStart;

            TimeSpan lessonDuration = new TimeSpan(1, 20, 0); // 80 минут
            TimeSpan shortBreak = new TimeSpan(0, 10, 0);
            TimeSpan longBreak = new TimeSpan(0, 20, 0);

            TimeSpan[] lessonIntervals = new[]
            {
        lessonDuration, shortBreak,
        lessonDuration, shortBreak,
        lessonDuration, longBreak,
        lessonDuration
    };

            int lessonNumber = 1;
            foreach (var interval in lessonIntervals)
            {
                if (timeSinceStart < interval)
                    return lessonNumber;
                timeSinceStart -= interval;
                if(isLesson)
                {
                    lessonNumber++;
                    isLesson = false;
                }
                else
                {
                    isLesson = true;
                }
                
            }
            return -1; // Если время не попадает в расписание
        }

        private void LoadScheduleForWeek(int weekNumber)
        {
            // Очищаем все ListView
            MondayListView.Items.Clear();
            TuesdayListView.Items.Clear();
            WednesdayListView.Items.Clear();
            ThursdayListView.Items.Clear();
            FridayListView.Items.Clear();
            SaturdayListView.Items.Clear();

            DateTime semesterStart = new DateTime(2024, 12, 1);

            // Загружаем занятия для указанной недели
            var lessonsForWeek = _database.Schedules
                .ToList()
                .Where(lesson => GetWeekNumber(lesson.StartTime, semesterStart) == weekNumber)
                .ToList();

            // Группируем занятия по дням недели
            var groupedLessons = GroupLessonsByDay(lessonsForWeek);

            // Добавляем занятия в ListView
            foreach (var day in groupedLessons.Keys)
            {
                var lessonsForDay = groupedLessons[day];
                foreach (var lesson in lessonsForDay)
                {
                    AddLessonToDayView(day, lesson);
                }
            }
        }

        private int GetWeekNumber(DateTime date, DateTime semesterStart)
        {
            TimeSpan difference = date.Date - semesterStart.Date;
            return (difference.Days / 7) + 1;
        }

        private void AddLessonToDayView(string dayOfWeek, Schedule lesson)
        {
            // Определяем номер занятия
            int lessonNumber = GetLessonNumber(lesson.StartTime);

            // Выбираем нужный ListView по дню недели
            ListView listView = GetListViewByDay(dayOfWeek);

            // Добавляем данные в ListView
            listView.Items.Add(new
            {
                LessonNumber = lessonNumber,
                Subject = lesson.Subject?.Name ?? "Без названия", // Используем название предмета
                Group = lesson.Group,
                Room = lesson.Room,
                StartTime = lesson.StartTime.ToString("HH:mm"),
                EndTime = lesson.EndTime.ToString("HH:mm")
            });
        }

        private ListView GetListViewByDay(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Monday":
                    return MondayListView;
                case "Tuesday":
                    return TuesdayListView;
                case "Wednesday":
                    return WednesdayListView;
                case "Thursday":
                    return ThursdayListView;
                case "Friday":
                    return FridayListView;
                case "Saturday":
                    return SaturdayListView;
                default:
                    return null;
            }
        }



    }
}
