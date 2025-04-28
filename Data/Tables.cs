using DPKPApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DPKPApp.Data
{
    static public class Tables
    {
        public static ObservableCollection<Departament> departaments;
        private static ObservableCollection<Group> groups;
        private static ObservableCollection<Student> students;
        private static ObservableCollection<StudentWork> studentWorks;
        private static ObservableCollection<Teacher> teachers;
        private static ObservableCollection<TypeOfStudentWork> typeOfStudents;

        public static ObservableCollection<Departament> Departaments { get { return departaments; } }
        public static ObservableCollection<Group> Groups { get { return groups; } }
        public static ObservableCollection<Student> Students { get { return students; } }
        public static ObservableCollection<StudentWork> StudentWorks { get { return studentWorks; } }
        public static ObservableCollection<Teacher> Teachers { get { return teachers; } }
        public static ObservableCollection<TypeOfStudentWork> TypeOfStudents { get { return typeOfStudents; } }
        public static bool RefreshTabls()
        {
            try
            {
                var tables = ConnectionClass.GetTables();
                foreach (var table in tables)
                {
                    if (table is ObservableCollection<Departament>) departaments = (ObservableCollection<Departament>)table;
                    if (table is ObservableCollection<Group>) groups = (ObservableCollection<Group>)table;
                    if (table is ObservableCollection<Student>) students = (ObservableCollection<Student>)table;
                    if (table is ObservableCollection<StudentWork>) studentWorks = (ObservableCollection<StudentWork>)table;
                    if (table is ObservableCollection<Teacher>) teachers = (ObservableCollection<Teacher>)table;
                    if (table is ObservableCollection<TypeOfStudentWork>) typeOfStudents = (ObservableCollection<TypeOfStudentWork>)table;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
