using DPKPApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DPKPApp.Data
{
    public static class ConnectionClass
    {
        public static string lineConnection = "Data Source=WIN-PKUO4L9RGT8;Initial Catalog=ATT;Integrated Security=True;";
        private static SqlConnection connection = new SqlConnection(lineConnection);

        public static ObservableCollection<Object> GetTables()
        {
            try
            {
                ObservableCollection<Object> tables = new ObservableCollection<Object>();
                connection.Open();
                var departments = GetDepartamentObservableCollection();
                var groups = GetGroupsObservableCollection(departments);
                var students = GetStudensObservableCollection(groups);
                var types = GetTypesOfStudentWorkObservableCollection();
                var teachers = GetTeachersObservableCollection();
                var studentsWork = GetStudentWorksObservableCollection(types,teachers,students);
                tables.Add(departments);
                tables.Add(groups);
                tables.Add(students);
                tables.Add(types);
                tables.Add(teachers);
                tables.Add(studentsWork);
                connection.Close();
                return tables;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private static ObservableCollection<Departament> GetDepartamentObservableCollection()
        {
            ObservableCollection<Departament> departaments = new ObservableCollection<Departament>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departaments", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                departaments.Add(
                    new Departament()
                    {
                        Id = table.GetInt32(0),
                        Name = table.GetString(1)
                    }
                    );
            }
            table.Close();
            return departaments;
        }
        private static ObservableCollection<Model.Group> GetGroupsObservableCollection(ObservableCollection<Departament> departaments)
        {
            ObservableCollection<Model.Group> groups = new ObservableCollection<Model.Group>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Groups", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                groups.Add(
                    new Model.Group()
                    {
                        Id = table.GetInt32(0),
                        Name = table.GetString(1)
                    }
                    );
            }
            table.Close();
            foreach (var group in groups)
            {
                foreach (var departament in departaments)
                {
                    if (group.Id == departament.Id)
                    {
                        group.Departament = departament;
                        break;
                    }
                }
            }
            return groups;
        }
        private static ObservableCollection<Student> GetStudensObservableCollection(ObservableCollection<Model.Group> groups)
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                students.Add(
                    new Student()
                    {
                        Id = table.GetInt32(0),
                        FirstName = table.GetString(1),
                        Surname = table.GetString(2),
                        SecondName = table.GetString(3)
                    }
                    );
            }
            table.Close();
            foreach (var student in students)
            {
                foreach (var group in groups)
                {
                    if (group.Id == student.Id)
                    {
                        student.GroupNumber = group;
                        break;
                    }
                }
            }
            return students;
        }
        private static ObservableCollection<TypeOfStudentWork> GetTypesOfStudentWorkObservableCollection()
        {
            ObservableCollection<TypeOfStudentWork> types = new ObservableCollection<TypeOfStudentWork>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TypeOfStudentWork", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                types.Add(
                    new TypeOfStudentWork()
                    {
                        Id = table.GetInt32(0),
                        Name = table.GetString(1),
                        Description = table.GetString(2)
                    }
                    );
            }
            table.Close();
            return types;
        }
        private static ObservableCollection<Teacher> GetTeachersObservableCollection()
        {
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Teachers", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                teachers.Add(
                    new Teacher()
                    {
                        Id = table.GetInt32(0),
                        FirstName = table.GetString(3),
                        Surname = table.GetString(4),
                        SecondName = table.GetString(5)
                    }
                    );
            }
            table.Close();
            return teachers;
        }
        private static ObservableCollection<StudentWork> GetStudentWorksObservableCollection(ObservableCollection<TypeOfStudentWork> types, ObservableCollection<Teacher> teachers, ObservableCollection<Student> students)
        {
            ObservableCollection<StudentWork> studentWorks = new ObservableCollection<StudentWork>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentWorks", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                studentWorks.Add(
                    new StudentWork()
                    {
                        Id = table.GetInt32(0),
                        Name = table.GetString(1),
                        DateOfDefense = table.GetDateTime(2),
                        Grabe = table.GetInt32(3)
                    }
                    );
            }
            table.Close();
            foreach (var studentWork in studentWorks)
            {
                foreach (var student in students)
                {
                    if (studentWork.Id == student.Id)
                    {
                        studentWork.Student = student;
                        break;
                    }
                }
            }
            foreach (var studentWork in studentWorks)
            {
                foreach (var teacher in teachers)
                {
                    if (studentWork.Id == teacher.Id)
                    {
                        studentWork.Teacher = teacher;
                        break;
                    }
                }
            }
            foreach (var studentWork in studentWorks)
            {
                foreach (var type in types)
                {
                    if (studentWork.Id == type.Id)
                    {
                        studentWork.TypeOfWork = type;
                        break;
                    }
                }
            }
            return studentWorks;
        }
    }
}
