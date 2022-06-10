using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using JokesAPP.Models;
using JokesAPP.Request;

namespace JokesAPP.DAO
{
    public class LoginDAO
    {
        public int updated;
     
        private static string _connStr = @"
                Server=127.0.0.1,1433;
                Database=Master;
                User Id=SA;
                Password=Password@123
            ";

        public LoginModel GetUser(string email, string password)
        {
            
            var user = new LoginModel();
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM dbo.Users WHERE Email ='" + email + "' And Password ='" + password + "';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        user.UserID = reader.GetInt32(0);
                        user.Email= reader.GetString(1);
                    }
                }
                return user;
            }
        }


        public Int64 Create(LoginModel loginModel)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO dbo.Users (Email, Password, CreatedAt)  Values('" + loginModel.Email + "','" + loginModel.Password + "','" + loginModel.CreatedAt + "');";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                var created = command.ExecuteNonQuery();
                return created;

            }
        }
        public Boolean GetBYEmail(String Email)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM dbo.Users WHERE Email ='" + Email + "';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == true)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
        }



    }
    
}
