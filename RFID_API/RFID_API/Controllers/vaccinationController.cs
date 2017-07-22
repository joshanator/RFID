using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RFID_API.Controllers
{
    public class vaccinationController : ApiController
    {
        public List<Models.vaccination> Get()
        {
            List<Models.vaccination> output = new List<Models.vaccination>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Vaccinations";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int SID = (int)reader["SID"];
                string type = (string)reader["Type"];
                DateTime date = (DateTime)reader["Date"];

                output.Add(Models.vaccinationBuilder.Parse(SID, type, date));
            }
            sqlConnection1.Close();

            return output;
        }

        public List<Models.vaccination> Get(int SID)
        {
            List<Models.vaccination> output = new List<Models.vaccination>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Vaccinations WHERE SID = " + SID;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string type = (string)reader["Type"];
                DateTime date = (DateTime)reader["Date"];

                output.Add(Models.vaccinationBuilder.Parse(SID, type, date));
            }
            sqlConnection1.Close();

            return output;
        }
    }
}
