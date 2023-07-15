using DesktopAssignment.ViewModel;
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

namespace DesktopAssignment.View
{
   
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow(AddStudentVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void lblBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
            
        }

        
    }
}
