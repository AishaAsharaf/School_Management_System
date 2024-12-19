using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using School_Management_System.Models;
using System.Windows;



namespace School_Management_System.ViewModels
{
    public class StudentVM : INotifyPropertyChanged
    {
        public Student Student { get; }

       

        private List<string> _courses;
        public List<string> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged();
            }
        }

        private List<string> _grades;
        public List<string> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
                OnPropertyChanged();
            }
        }

        public string StudentName => Student.Name; // Property to get the student's name

        public ICommand GoBack { get; }

        public StudentVM(Student student)
        {
            Student = student;
            LoadStudentDetails();
            GoBack = new Command.RelayCommand(Back);
        }

        private void LoadStudentDetails()
        {
            Courses = Student.Courses; // Assuming Courses is a List<string> in the Student model
            Grades = Student.Grades; // Assuming Grades is a List<string> in the Student model
        }

        private void Back(object parameter)
        {
            Views.Login login = new Views.Login();
            login.Show();
            Application.Current.MainWindow.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
