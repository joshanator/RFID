using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID_API.Models
{
    public class condition
    {
        public int SID { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
    }

    public static class conditionBuilder
    {
        public static condition Parse(int SID, string type, DateTime date)
        {
            condition output = new condition();
            output.SID = SID;
            output.type = type;
            output.date = date;

            return output;
        }
    }
}