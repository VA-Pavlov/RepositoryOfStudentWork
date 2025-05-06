using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DPKPApp.Data
{
    public class LoginClass
    {
        private SqlConnection connection = new SqlConnection(ConnectionClass.lineConnection);
        public void CreateUser(string Login, string Password, string FirstName, string Name, string SecondName)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Teachers VALUES('{Login}','{Password}','{FirstName}','{Name}','{SecondName}');", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                connection.Close();
            }
        }
        public bool FindUser(string Login, string Password)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Id FROM Teachers WHERE Login = '{Login}' AND Password = '{Password}'", connection);
                var id = cmd.ExecuteScalar();
                connection.Close();
                return id is null ? false : true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                connection.Close();
            }
            return false;
        }
    }
}
