using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID_API.Models
{
    public class medication
    {
        public int SID { get; set; }
        public string type { get; set; }
        public string dose { get; set; }
        public string frequency { get; set; }
    }

    public static class medicationbuilder
    {
        public static medication Parse(int SID, string type, string dose, string frequency)
        {
            medication output = new medication();
            output.SID = SID;
            output.type = type;
            output.dose = dose;
            output.frequency = frequency;

            return output;
        }
    }
}