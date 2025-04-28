using DPKPApp.Data;
using DPKPApp.Model;
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

namespace DPKPApp.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogeWindow.xaml
    /// </summary>
    public partial class CatalogeWindow : Window
    {
        public CatalogeWindow()
        {
            InitializeComponent();
            DiplomaWorksList.ItemsSource = Tables.StudentWorks;
            TypeFilterComboBox.ItemsSource = Tables.TypeOfStudents;
            GroupFilterComboBox.ItemsSource = Tables.Groups;
            TeacherFilterComboBox.ItemsSource = Tables.Teachers;
        }

        private void ResetFiltersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProjectWindow createNewProjectWindow = new CreateNewProjectWindow();

        }

        private void EditProjectButton_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshListButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
