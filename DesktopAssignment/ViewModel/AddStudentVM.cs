using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using DesktopAssignment.Model;
using System.Windows.Input;

namespace DesktopAssignment.ViewModel
{
    public partial class AddStudentVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public AddStudentVM(StudentUsers u)
        {
            try
            {
                Student = u;

                firstname = Student.FirstName;
                lastname = Student.LastName;
                age = Student.Age;
                gpa = Student.GPA;
                dateofbirth = Student.DateOfBirth;
                selectedImage = Student.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the view model: {ex.Message}", "Error");
            }
        }

        public AddStudentVM()
        {

        }

		


		[RelayCommand]
        public void UploadPhoto()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == true)
                {
                    selectedImage = new BitmapImage(new Uri(dialog.FileName));
                    MessageBox.Show("Image successfully uploaded!", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while uploading the image: {ex.Message}", "Error");
            }
        }

        public StudentUsers Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {
            try
            {
                if (gpa < 0 || gpa > 4)
                {
                    MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                    return;
                }
                if (Student == null)
                {
                    Student = new StudentUsers()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Age = age,
                        DateOfBirth = dateofbirth,
                        Image = selectedImage,
                        GPA = gpa
                    };
                }
                else
                {
                    Student.FirstName = firstname;
                    Student.LastName = lastname;
                    Student.Age = age;
                    Student.GPA = gpa;
                    Student.Image = selectedImage;
                    Student.DateOfBirth = dateofbirth;
                }
                if (Student.FirstName != null)
                {
                    CloseAction();
                }
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the student: {ex.Message}", "Error");
            }
        }
    }
}
