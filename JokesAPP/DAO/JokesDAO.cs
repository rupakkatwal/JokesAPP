using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using JokesAPP.Models;
using JokesAPP.Request;

namespace JokesAPP.DAO
{
    public class JokesDAO
    {
        public int UserID;

        private static string _connStr = @"
                Server=127.0.0.1,1433;
                Database=Master;
                User Id=SA;
                Password=Password@123
            ";


        public List<JokesModel> fetchall()
        {
            List<JokesModel> JokesList = new List<JokesModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM dbo.Jokes ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        JokesModel Joke = new JokesModel();
                        Joke.JokesID = reader.GetInt32(0);
                        Joke.JokesQuestion = reader.GetString(1);
                        Joke.JokesAnswer = reader.GetString(2);
                        Joke.CreatedAt = reader.GetDateTime(3);
                        JokesList.Add(Joke);
                    }
                    
                }
                connection.Close();

            }
            return JokesList;
        }
        public int update(JokesModel JokesModel)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "UPDATE dbo.Jokes SET JokesQuestion ='" + JokesModel.JokesQuestion + "', JokesAnswer ='" + JokesModel.JokesAnswer + "', CreatedAt ='" + JokesModel.CreatedAt + "' WHERE JokesID = '" + JokesModel.JokesID + "';";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                int updated = command.ExecuteNonQuery();
                return updated;
            }


        }
        public int Create(JokesModel JokesModel)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO dbo.Jokes (JokesQuestion, JokesAnswer, CreatedAt)  Values('" + JokesModel.JokesQuestion + "','" + JokesModel.JokesAnswer + "','" + JokesModel.CreatedAt + "');";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                int created = command.ExecuteNonQuery();

                return created;
            }


        }

        public int Delete(int id)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "DELETE FROM  dbo.Jokes WHERE JokesID = '" + id + "';";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                int deleted = command.ExecuteNonQuery();
                return deleted;

            }


        }

        public void Signout(int id)
        {

            //access the database
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlQuery = "UPDATE dbo.User SET IsLogin = 0  WHERE UserId = '" + id + "';";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                int updated = command.ExecuteNonQuery();
                
            }
        }

        public List<JokesModel> SearchList(JokesRequest req)
        {
            var JokesList = new List<JokesModel>();
            using (SqlConnection connection = new SqlConnection(_connStr))
            {

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                StringBuilder sbSQL = new StringBuilder(1000);
                sbSQL.Append("SELECT * FROM dbo.Jokes WHERE 1=1");

                if (!String.IsNullOrEmpty(req.JokesQuestion))
                {
                    sbSQL.Append(" AND JokesQuestion LIKE '%' + @JokesQuestion + '%'");
                    SqlParameter param = new SqlParameter("@JokesQuestion", req.JokesQuestion);
                    command.Parameters.Add(param);

                }
                
                if (req.CreatedAt != DateTime.MinValue)
                {
                    sbSQL.Append(" AND CreatedAt <= @CreatedAt ");
                    SqlParameter param = new SqlParameter("@CreatedAt", req.CreatedAt);
                    command.Parameters.Add(param);
                }
              
                command.CommandText = sbSQL.ToString();
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        JokesModel Joke = new JokesModel();
                        Joke.JokesID = reader.GetInt32(0);
                        Joke.JokesQuestion = reader.GetString(1);
                        Joke.JokesAnswer = reader.GetString(2);
                        Joke.CreatedAt = reader.GetDateTime(3);
                        JokesList.Add(Joke);
                    }

                }
                connection.Close();

            }
            return JokesList;
        }
        public JokesModel GetById(int id)
        {
            JokesModel Joke = new JokesModel();
            using (SqlConnection connection = new SqlConnection(_connStr))
            {

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                StringBuilder sbSQL = new StringBuilder(1000);
                sbSQL.Append("SELECT * FROM dbo.Jokes WHERE 1=1");
                if (id > 0)
                {
                    sbSQL.Append(" AND JokesID <= @JokesID ");
                    SqlParameter param = new SqlParameter("@JokesID", id);
                    command.Parameters.Add(param);
                }

                command.CommandText = sbSQL.ToString();
                command.CommandType = CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        Joke.JokesID = reader.GetInt32(0);
                        Joke.JokesQuestion = reader.GetString(1);
                        Joke.JokesAnswer = reader.GetString(2);
                        Joke.CreatedAt = reader.GetDateTime(3);
                    }

                }
                connection.Close();

            }
            return Joke;
        }

    }
}
