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
using System.Windows.Shapes;
using School_Management_System.Models;
using School_Management_System.ViewModels;

namespace School_Management_System.Views
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public Student(Models.Student student) // Accept the Student object in the constructor
        {
            InitializeComponent();

            // Pass the student object to the StudentVM
            ViewModels.StudentVM sm = new ViewModels.StudentVM(student);
            this.DataContext = sm; // Set the DataContext to the StudentVM
        }
    }
}
