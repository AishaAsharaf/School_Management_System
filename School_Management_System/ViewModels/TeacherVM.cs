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
using School_Management_System.Models;
using School_Management_System.Views;
using System.Windows;

namespace School_Management_System.ViewModels
{
    public class TeacherVM : INotifyPropertyChanged
    {
        public ObservableCollection<Models.Student> Students { get; set; }
        private Models.Student _selectedStudent;

        public Models.Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public ICommand UpdateMarksCommand { get; }
        public ICommand GoBack { get; }
        public TeacherVM(ObservableCollection<Models.Student> students)
        {
            Students = students;
            UpdateMarksCommand = new Command.RelayCommand(UpdateMarks);
            GoBack = new Command.RelayCommand(Back);
        }
        private void Back(object parameter)
        {
            Views.Login login = new Views.Login();
            login.Show();
            Application.Current.MainWindow.Close();
        }

        private void UpdateMarks(object parameter)
        {

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
