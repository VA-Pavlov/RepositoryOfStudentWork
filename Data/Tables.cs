using DPKPApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DPKPApp.Data
{
    static public class Tables
    {
        private static List<Departament> departaments;
        private static List<Group> groups;
        private static List<Student> students;
        private static List<StudentWork> studentWorks;
        private static List<Teacher> teachers;
        private static List<TypeOfStudentWork> typeOfStudents;

        public static bool RefreshTabls()
        {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка!",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
