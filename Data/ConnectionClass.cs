using DPKPApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DPKPApp.Data
{
    public static class ConnectionClass
    {
        private static SqlConnection connection = new SqlConnection("Data Source=VIACHESLAV;Initial Catalog=ATT;Integrated Security=True;");

        public static List<Object> GetTables()
        {
            try
            {
                List<Object> tables = new List<Object>();
                connection.Open();
                var departments = GetDepartamentList();
                var groups = GetGroupsList(departments);
                var students = GetStudensList(groups);
                var types = GetTypesOfStudentWorkList();
                var teachers = GetTeachersList();
                var studentsWork = GetStudentWorksList(types,teachers,students);
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

        private static List<Departament> GetDepartamentList()
        {
            List<Departament> departaments = new List<Departament>();
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
            return departaments;
        }
        private static List<Model.Group> GetGroupsList(List<Departament> departaments)
        {
            List<Model.Group> groups = new List<Model.Group>();
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
        private static List<Student> GetStudensList(List<Model.Group> groups)
        {
            List<Student> students = new List<Student>();
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
        private static List<TypeOfStudentWork> GetTypesOfStudentWorkList()
        {
            List<TypeOfStudentWork> types = new List<TypeOfStudentWork>();
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
            return types;
        }
        private static List<Teacher> GetTeachersList()
        {
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Teachers", connection);
            var table = cmd.ExecuteReader();
            while (table.Read())
            {
                teachers.Add(
                    new Teacher()
                    {
                        Id = table.GetInt32(0),
                        Login = table.GetString(1),
                        Password = table.GetString(2),
                        FirstName = table.GetString(3),
                        Surname = table.GetString(4),
                        SecondName = table.GetString(5)
                    }
                    );
            }
            return teachers;
        }
        private static List<StudentWork> GetStudentWorksList(List<TypeOfStudentWork> types, List<Teacher> teachers, List<Student> students)
        {
            List<StudentWork> studentWorks = new List<StudentWork>();
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
