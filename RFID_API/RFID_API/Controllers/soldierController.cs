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


        public Models.soldierComplete Get(int SID, string val)
        {
            Models.soldierComplete output = new Models.soldierComplete();

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
            output.allergies = "";
            output.conditions = "";
            output.vaccinations = "";
            output.medications = "";

            allergyController aCon = new allergyController();
            conditionController cCon = new conditionController();
            medicationController mCon = new medicationController();
            vaccinationController vCon = new vaccinationController();

            List<Models.allergy> allergies = aCon.Get(SID);
            List<Models.condition> conditions = cCon.Get(SID);
            List<Models.medication> medications = mCon.Get(SID);
            List<Models.vaccination> vaccinations = vCon.Get(SID);

            foreach(Models.allergy e in allergies)
            {
                output.allergies += e.type + ", ";
            }
            if (output.allergies != "")
            {
                output.allergies = output.allergies.Substring(0, output.allergies.Length - 2);
            }

            foreach (Models.condition e in conditions)
            {
                output.conditions += e.type + ", ";
            }
            if (output.conditions != "")
            {
                output.conditions = output.conditions.Substring(0, output.conditions.Length - 2);
            }

            foreach (Models.vaccination e in vaccinations)
            {
                output.vaccinations += e.type + ", ";
            }
            if (output.vaccinations != "")
            {
                output.vaccinations = output.vaccinations.Substring(0, output.vaccinations.Length - 2);
            }

            foreach (Models.medication e in medications)
            {
                output.medications += e.type + ", ";
            }
            if (output.medications != "")
            {
                output.medications = output.medications.Substring(0, output.medications.Length - 2);
            }
            



            sqlConnection1.Close();
            return output;
        }



        public List<Models.soldierComplete> Get(string val)
        {
            List<Models.soldierComplete> output = new List<Models.soldierComplete>();

            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection sqlConnection1 = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT [SID] FROM soldiers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            List<int> ids = new List<int>();

            while (reader.Read())
            {
                ids.Add((int)reader["SID"]);
            }

            foreach(int id in ids)
            {
                Models.soldierComplete temp = Get(id, "a");
                output.Add(temp);
            }

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