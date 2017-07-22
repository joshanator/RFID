using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID_API.Models
{
    public class allergy
    {
        public int SID { get; set; }
        public string type { get; set; }
    }

    public static class allergyBuilder
    {
        public static allergy Parse(int SID, string type)
        {
            allergy output = new allergy();
            output.SID = SID;
            output.type = type;

            return output;
        }
    }
}