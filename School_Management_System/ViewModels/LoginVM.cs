using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using School_Management_System.Models;
using System.Windows.Input;
using System.Windows.Navigation;
using School_Management_System.Command;
using School_Management_System.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace School_Management_System.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public ObservableCollection<Models.Student> Students { get; set; }
        public ObservableCollection<Models.Teacher> Teachers { get; set; }
        public ObservableCollection<Models.Admin> Admins { get; set; }

        public ObservableCollection<string> Items { get; set; }

        private string _email;
        private string _password;
        private string _role;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand Login {  get; }
        public LoginVM()
        {
            Items = new ObservableCollection<string>
            {
            "Student",
            "Teacher",
            "Admin"
            };

            Students = new ObservableCollection<Models.Student>
            {  new Models.Student{Name="Aisha",Email="aisha@quest.com",Role="Student",Password="1234",StudentId=1,Courses=new List<string>{"English","Science"},Grades=new List<string>{"A","S" }},
               new Models.Student { Name = "John", Email = "john@quest.com", Role = "Student", Password = "1234", StudentId = 2, Courses = new List<string> { "Math", "History" }, Grades = new List<string> { "B", "A" } },
               new Models.Student { Name = "Sara", Email = "sara@quest.com", Role = "Student", Password = "1234", StudentId = 3, Courses = new List<string> { "Biology", "Chemistry" }, Grades = new List<string> { "A", "A" } }
            };

            Teachers = new ObservableCollection<Models.Teacher>
            {
                new Models.Teacher { Name = "Mr. Smith", Email = "smith@quest.com", Role = "Teacher", Password = "abcd", TeacherId = 1, AssignedCourses = new List<string> { "Math", "Physics" } },
                new Models.Teacher { Name = "Ms. Johnson", Email = "johnson@quest.com", Role = "Teacher", Password = "abcd", TeacherId = 2, AssignedCourses = new List<string> { "English", "History" } }
            };

            // Dummy data for Admins
            Admins = new ObservableCollection<Models.Admin>
            {
                new Models.Admin { Name = "Admin One", Email = "admin1@quest.com", Role = "Admin", Password = "admin123" }
               
            };

            Login = new RelayCommand(CheckedData);

        }

        private void CheckedData(object parameter)
        {
            var user = ValidateUser(Email, Password, Role);
            var student = Students.FirstOrDefault(x => x.Email == Email && x.Password == Password);

            if (user == "student" && student != null)
            {
                // Pass the student to the Student view
                Views.Student studentView = new Views.Student(student); // Pass the student object to the constructor
                studentView.Show();
                Application.Current.MainWindow.Close();
            }
            else if (user == "error")
            {
                ErrorMessage = "Invalid email, password, or role.";
                MessageBox.Show(ErrorMessage);
            }
            else if (user == "teacher")
            {
                Views.Teacher teacher = new Views.Teacher(Students); // Pass the ObservableCollection<Student>
                teacher.Show();
                Application.Current.MainWindow.Close();
            }
            else if (user == "admin")
            {
                var admin = Admins.FirstOrDefault(x => x.Email == Email && x.Password == Password);
                if (admin != null)
                {
                    Views.Admin adminView = new Views.Admin(admin, Students, Teachers); // Pass the collections
                    adminView.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    ErrorMessage = "Invalid email or password for admin.";
                    MessageBox.Show(ErrorMessage);
                }
            }

        }

        private string ValidateUser(string email, string password,string role)
        {
            switch (role)
            {
                case "Student":
                    var student = Students.FirstOrDefault(x => x.Email == email && x.Password == password);
                    return "student";

                case "Teacher":
                    var teacher = Teachers.FirstOrDefault(x => x.Email == email && x.Password == password);
                    return "teacher";

                case "Admin":
                    var admin = Admins.FirstOrDefault(x => x.Email == email && x.Password == password);
                    return "admin";

                default:
                    return "error";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
