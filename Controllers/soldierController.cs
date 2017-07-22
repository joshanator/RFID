using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RFID_API.Controllers
{
    public class soldierController : ApiController
    {
        public int Get()
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=tcp:socialstocks.database.windows.net,1433;Initial Catalog=RFID;Persist Security Info=False;User ID=petersonjoshua;Password=31@F3r0.97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT SID FROM soldiers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();

            return 1;
        }
    }


}