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
    public class medicationController : ApiController
    {
        public List<Models.medication> Get()
        {
            List<Models.medication> output = new List<Models.medication>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Medications";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int SID = (int)reader["SID"];
                string type = (string)reader["Type"];
                string dose = (string)reader["Dose"];
                string frequency = (string)reader["Frequency"];

                output.Add(Models.medicationbuilder.Parse(SID, type, dose, frequency));
            }
            sqlConnection1.Close();

            return output;
        }


        public List<Models.medication> Get(int SID)
        {
            List<Models.medication> output = new List<Models.medication>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Medications WHERE SID = " + SID;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string type = (string)reader["Type"];
                string dose = (string)reader["Dose"];
                string frequency = (string)reader["Frequency"];

                output.Add(Models.medicationbuilder.Parse(SID, type, dose, frequency));
            }
            sqlConnection1.Close();

            return output;
        }
    }
}