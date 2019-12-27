using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arduino
{
    public class Database
    {
        static string connectionInfo = "Server=localhost;port=3306;database=weather;username=root;password=d9324340";

        public List<string> GetWeatherForDay(int id)
        {
            List<string> ls = new List<string>();

            MySqlConnection connection = new MySqlConnection(connectionInfo);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM weather where id = " + id;
            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            MySqlDataReader dr = command.ExecuteReader();
            dr.Read();
            ls.Add(dr["temperature"].ToString());
            dr.Read();
            ls.Add(dr["humidity"].ToString());
            connection.Close();
            return ls;
        }

        public static void UpdateDatabase(List<string> values)
        {
            MySqlConnection connection = new MySqlConnection(connectionInfo);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE weather SET temperature = " + values.ElementAt(0) + ", humidity = " + values.ElementAt(1);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
