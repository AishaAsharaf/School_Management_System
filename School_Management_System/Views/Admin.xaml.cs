using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using School_Management_System.ViewModels;

namespace School_Management_System.Views
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
       

        public Admin(Models.Admin admin, ObservableCollection<Models.Student> students, ObservableCollection<Models.Teacher> teachers)
        {
            InitializeComponent();
            DataContext = new AdminVM(admin, students, teachers); // Set the DataContext to the AdminVM
        }

       
    }
}
