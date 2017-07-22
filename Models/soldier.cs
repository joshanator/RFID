using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID_API.Models
{
    public class soldier
    {
        public int SID {get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bloodType { get; set; }

        public int height { get; set; }
        public int weight { get; set; }
        public string rank { get; set; }
        public string supervisor { get; set; }
        public string contact { get; set; }

    }
}