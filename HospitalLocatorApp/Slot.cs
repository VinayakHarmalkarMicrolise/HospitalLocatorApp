using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLocatorApp
{
    public class Slot
    {
        public DateTime dateOfSlotAvailable
        {
            get; set;
        }

        public int numberOfFreeSlots
        {
            get; set;
        }

        public Slot(DateTime dateOfSlotAvailability, int numberOfSlotsAvailable) 
        {
            dateOfSlotAvailable = dateOfSlotAvailability;
            numberOfFreeSlots = numberOfSlotsAvailable;
        }
    }
}