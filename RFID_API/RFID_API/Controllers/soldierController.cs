using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RFID_API.Controllers
{
    public class soldierController : ApiController
    {
        public List<Models.soldier> Get()
        {
            List<Models.soldier> output = new List<Models.soldier>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM soldiers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int SID = (int)reader["SID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string bloodType = (string)reader["BloodType"];
                int height = (int)reader["Height"];
                int weight = (int)reader["Weight"];
                DateTime birthday = (DateTime)reader["Birthday"];
                DateTime lastVisit = (DateTime)reader["LastVisit"];
                string rank = (string)reader["Rank"];
                string supervisor = (string)reader["Supervisor"];
                string contact = (string)reader["Contact"];
                string photoLink = (string)reader["PhotoLink"];


                output.Add(Models.soldierBuilder.Parse(SID, firstName, lastName, bloodType, height, weight, birthday, lastVisit, rank, supervisor, contact, photoLink));
            }
            sqlConnection1.Close();

            return output;
        }


        public Models.soldier Get(int SID)
        {
            Models.soldier output = new Models.soldier();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM soldiers WHERE SID = " + SID;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output.SID = SID;
                output.firstName = (string)reader["FirstName"];
                output.lastName = (string)reader["LastName"];
                output.bloodType = (string)reader["BloodType"];
                output.height = (int)reader["Height"];
                output.weight = (int)reader["Weight"];
                output.birthday = (DateTime)reader["Birthday"];
                output.lastVisit = (DateTime)reader["LastVisit"];
                output.rank = (string)reader["Rank"];
                output.supervisor = (string)reader["Supervisor"];
                output.contact = (string)reader["Contact"];
                output.photoLink = (string)reader["PhotoLink"];
            }

            sqlConnection1.Close();
            return output;
        }


        public byte[] Get(int SID, int bytes)
        {
            allergyController aCon = new allergyController();
            conditionController cCon = new conditionController();
            medicationController mCon = new medicationController();

            List<Models.allergy> allergies = aCon.Get(SID);
            List<Models.condition> conditions = cCon.Get(SID);
            List<Models.medication> medications = mCon.Get(SID);

            string output = "";
            byte[] toBytes = Encoding.ASCII.GetBytes((SID.ToString() + "/").Replace(" ",""));
            byte[] temp = toBytes;
            foreach (Models.allergy e in allergies)
            {
                output = e.type + "/";
                temp = toBytes.Concat(Encoding.ASCII.GetBytes(output.Replace(" ", ""))).ToArray();
                if(temp.Length <= bytes)
                {
                    toBytes = temp;
                }
            }
            foreach (Models.condition e in conditions)
            {
                output = e.type + "/";
                temp = toBytes.Concat(Encoding.ASCII.GetBytes(output.Replace(" ", ""))).ToArray();
                if (temp.Length <= bytes)
                {
                    toBytes = temp;
                }
            }
            foreach (Models.medication e in medications)
            {
                output = e.type + "/";
                temp = toBytes.Concat(Encoding.ASCII.GetBytes(output.Replace(" ", ""))).ToArray();
                if (temp.Length <= bytes)
                {
                    toBytes = temp;
                }
            }


            return toBytes;
        }
    }
}