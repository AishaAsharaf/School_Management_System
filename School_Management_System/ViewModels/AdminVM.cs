using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using School_Management_System.Command;
using System.Windows.Input;
using System.Windows;

namespace School_Management_System.ViewModels
{
   
        public class AdminVM : INotifyPropertyChanged
        {
            public Models.Admin Admin { get; }
            public ObservableCollection<Models.Student> Students { get; set; }
            public ObservableCollection<Models.Teacher> Teachers { get; set; }

            public ICommand AddTeacherCommand { get;}
            public ICommand DeleteTeacherCommand { get; }
            public ICommand AddStudentCommand { get; }
            public ICommand DeleteStudentCommand { get;}

            public ICommand GoBack { get; }

            private Models.Teacher _selectedTeacher;
            public Models.Teacher SelectedTeacher
            {
                get { return _selectedTeacher; }
                set
                {
                    _selectedTeacher = value;
                    OnPropertyChanged();
                }
            }

            private Models.Student _selectedStudent;
            public Models.Student SelectedStudent
            {
                get { return _selectedStudent; }
                set
                {
                    _selectedStudent = value;
                    OnPropertyChanged();
                }
            }

            public AdminVM(Models.Admin admin, ObservableCollection<Models.Student> students, ObservableCollection<Models.Teacher> teachers)
            {
                Admin = admin;
                Students = students;
                Teachers = teachers;

                AddTeacherCommand = new Command.RelayCommand(AddTeacher);
                DeleteTeacherCommand = new Command.RelayCommand(DeleteTeacher, CanDeleteTeacher);
                AddStudentCommand = new Command.RelayCommand(AddStudent);
                DeleteStudentCommand = new Command.RelayCommand(DeleteStudent, CanDeleteStudent);
                GoBack = new Command.RelayCommand(Back);
            }
            private void Back(object parameter)
            {
                Views.Login login = new Views.Login();
                login.Show();
                Application.Current.MainWindow.Close();
            }
            private void AddTeacher(object parameter)
            {
                Teachers.Add(new Models.Teacher { TeacherId = Teachers.Count + 1, Name = "New Teacher",Email ="new@emailcreted.com" });
            }

            private void DeleteTeacher(object parameter)
            {
                if (SelectedTeacher != null)
                {
                    Teachers.Remove(SelectedTeacher);
                }
            }

            private bool CanDeleteTeacher(object parameter)
            {
                return SelectedTeacher != null;
            }

            private void AddStudent(object parameter)
            {
                Students.Add(new Models.Student { StudentId = Students.Count + 1, Name = "New Student", Email = "new.student@example.com"});
            }

            private void DeleteStudent(object parameter)
            {
                if (SelectedStudent != null)
                {
                    Students.Remove(SelectedStudent);
                }
            }

            private bool CanDeleteStudent(object parameter)
            {
                return SelectedStudent != null;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

