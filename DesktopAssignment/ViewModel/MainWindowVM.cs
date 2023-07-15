using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using DesktopAssignment.Model;
using DesktopAssignment.View;

namespace DesktopAssignment.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<StudentUsers> users;
        [ObservableProperty]
        public StudentUsers selectedStudent = null;

		public MainWindowVM()
		{
			users = new ObservableCollection<StudentUsers>();
			BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
			users.Add(new StudentUsers(23, "Tom", "Lathem", "12/1/2000\t", image1, 2.35));
			BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
			users.Add(new StudentUsers(25, "Michel", "Clark", "12/1/1998\t", image2, 3.11));
			BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
			users.Add(new StudentUsers(24, "Ricky", "Ponting", "12/1/1999\t", image3, 2.72));
			BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
			users.Add(new StudentUsers(24, "Ross ", "Taylor", "12/1/1999\t", image4, 3.24));
			BitmapImage image5 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
			users.Add(new StudentUsers(23, "Mark", "Wood", "12/1/2000\t", image5, 2.97));
			BitmapImage image6 = new BitmapImage(new Uri("/Images/6.png", UriKind.Relative));
			users.Add(new StudentUsers(23, "Mandana", "Smrithi", "17/1/1998\t", image6, 3.17));
			BitmapImage image7 = new BitmapImage(new Uri("/Images/7.png", UriKind.Relative));
			users.Add(new StudentUsers(23, "Chamari", "Athapattu", "15/1/1997\t", image7, 3.40));
			BitmapImage image8 = new BitmapImage(new Uri("/Images/8.png", UriKind.Relative));
			users.Add(new StudentUsers(23, "Roston", "Chase", "12/10/1999\t", image8, 2.97));

		}

		public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

		[RelayCommand]
		public void MinimizeWindow()
		{
			Application.Current.MainWindow.WindowState = WindowState.Minimized;
		}

		[RelayCommand]
		public void CloseWindow()
		{
			Application.Current.MainWindow.Close();
		}


		[RelayCommand]
        public void Message()
        {
            MessageBox.Show($"{selectedStudent.FirstName} value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            try
            {
                var vm = new AddStudentVM();
                vm.title = " ";
                AddStudentWindow window = new AddStudentWindow(vm);
                //Application.Current.MainWindow.Close();
                window.ShowDialog();
                

                if (vm.Student != null && vm.Student.FirstName != null)
                {
                    users.Add(vm.Student);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the student. Error message: {ex.Message}", "Error");
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                users.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void EditStudent()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
                vm.title = "";
                var window = new AddStudentWindow(vm);
                //Application.Current.MainWindow.Close();
                window.ShowDialog();


                int index = users.IndexOf(selectedStudent);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        
	}
}
