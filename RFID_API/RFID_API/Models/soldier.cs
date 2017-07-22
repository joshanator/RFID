using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID_API.Models
{
    public class soldier
    {
        public int SID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bloodType { get; set; }

        public int height { get; set; }
        public int weight { get; set; }
        public DateTime birthday { get; set; }
        public DateTime lastVisit { get; set; }
        public string rank { get; set; }
        public string supervisor { get; set; }
        public string contact { get; set; }
        public string photoLink { get; set; }

    }

    public class soldierComplete
    {
        public int SID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bloodType { get; set; }

        public int height { get; set; }
        public int weight { get; set; }
        public DateTime birthday { get; set; }
        public DateTime lastVisit { get; set; }
        public string rank { get; set; }
        public string supervisor { get; set; }
        public string contact { get; set; }
        public string photoLink { get; set; }
        public string allergies { get; set; }
        public string conditions { get; set; }
        public string medications { get; set; }
        public string vaccinations { get; set; }
    }


    public static class soldierBuilder
    {
        public static soldier Parse(int SID, string firstName, string lastName, string bloodType, int height, int weight, DateTime birthday, DateTime lastVisit, string rank, string supervisor, string contact, string photoLink)
        {
            soldier output = new soldier();
            output.SID = SID;
            output.firstName = firstName;
            output.lastName = lastName;
            output.bloodType = bloodType;
            output.height = height;
            output.weight = weight;
            output.birthday = birthday;
            output.lastVisit = lastVisit;
            output.rank = rank;
            output.supervisor = supervisor;
            output.contact = contact;
            output.photoLink = photoLink;

            return output;
        }


        public static soldierComplete Parse(int SID, string firstName, string lastName, string bloodType, int height, int weight, DateTime birthday, DateTime lastVisit, string rank, string supervisor, string contact, string photoLink, string conditions, string vaccinations, string allergies, string medications)
        {
            soldierComplete output = new soldierComplete();
            output.SID = SID;
            output.firstName = firstName;
            output.lastName = lastName;
            output.bloodType = bloodType;
            output.height = height;
            output.weight = weight;
            output.birthday = birthday;
            output.lastVisit = lastVisit;
            output.rank = rank;
            output.supervisor = supervisor;
            output.contact = contact;
            output.photoLink = photoLink;
            output.allergies = allergies;
            output.conditions = conditions;
            output.medications = medications;
            output.vaccinations = vaccinations;


            return output;
        }
    }
}