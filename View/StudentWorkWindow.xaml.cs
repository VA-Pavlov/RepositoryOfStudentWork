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

namespace DPKPApp.View
{
    /// <summary>
    /// Логика взаимодействия для StudentWorkWindow.xaml
    /// </summary>
    public partial class StudentWorkWindow : Window
    {
        public StudentWorkWindow()
        {
            InitializeComponent();
            // Путь к файлу Word
            string filePath = @"C:\Users\admin\Downloads\Павлов.docx";

            // Открываем файл через WebBrowser
            webBrowser.Navigate(new Uri(filePath));
        }
    }
}
