using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLocatorApp
{
    public class Hospital
    {
        public string nameOfHospital
        {
            get; set;
        }

        public string addressOfHospital
        {
            get; set;
        }

        public int pinCodeOfHospital
        {
            get; set;
        }

        public List<Slot>  slotsAvailabilityForVaccinations = new List<Slot>();
       

        public Hospital(string nameOfHospital, string addressOfHospital, int pinCodeOfHospital)
        {
            this.nameOfHospital = nameOfHospital;
            this.addressOfHospital = addressOfHospital;
            this.pinCodeOfHospital = pinCodeOfHospital;
            
        }

        // This adds new free slots for given date
        public void AddNewFreeSlots(DateTime date, int numberOfSlots) 
        {
            slotsAvailabilityForVaccinations.Add(new Slot(date, numberOfSlots));
        }
    }
}