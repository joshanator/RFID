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
    public class allergyController : ApiController
    {
        public List<Models.allergy> Get()
        {
            List < Models.allergy> output = new List<Models.allergy>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Allergies";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int SID = (int)reader["SID"];
                string type = (string)reader["Type"];

                output.Add(Models.allergyBuilder.Parse(SID, type));
            }
            sqlConnection1.Close();

            return output;
        }


        public List<Models.allergy> Get(int SID)
        {
            List<Models.allergy> output = new List<Models.allergy>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Allergies WHERE SID = " + SID;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string type = (string)reader["Type"];

                output.Add(Models.allergyBuilder.Parse(SID, type));
            }
            sqlConnection1.Close();

            return output;
        }
    }
}
