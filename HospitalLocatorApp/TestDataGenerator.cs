using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalLocatorApp
{
    // This class is used for generating the data in list format.
    public static class TestDataGenerator { 
        // Following function is used for generating the random strings for name and address of hospitals by passing length of the string.
        public static string stringGenerator(int flag)
        {
            const string chars = "ABCDEFGHIJKLMNOP" +
                "QRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random randomObjectForString = new Random();
            int length;
            
            // Used for identifying if the string to be generated is for name or address. 
            if (flag == 0) { length = randomObjectForString.Next(5, 10); }
            else { length = randomObjectForString.Next(10, 15); }
            char[] temporaryArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                int index = randomObjectForString.Next(chars.Length);
                temporaryArray[i] = chars[index];
                //System.Threading.Thread.Sleep(1);
            }
            return new string(temporaryArray);
        }
            
        public static List<Hospital> GenerateHospitals(int numberOfHospitals, int numberOfDaysOfSlots)
        {
            // Number of Hospital to be generated
            int numberOfHospitalsWantToEnter;
            numberOfHospitalsWantToEnter = numberOfHospitals;
            string nameOfHospital;
            string hospitalAddress;

            // List for storing the data of hospitals generated
            List<Hospital> hospitalList = new List<Hospital>(); 
            DateTime currentDate = DateTime.Now.Date;
            Hospital currentHospital;
            Random randomObjectForPincode = new Random();
            int Pin = randomObjectForPincode.Next(400000, 400010);
            int randomNumberForAddressAndName = randomObjectForPincode.Next(1, 1000);

            // This for loop is used for generating and storing the hospital details
            for (int hospitalNo = 0; hospitalNo < numberOfHospitalsWantToEnter; hospitalNo++)
            {
                // Generating the name and address of hospital and creating a object of hospital
                nameOfHospital = stringGenerator(0);
                hospitalAddress = stringGenerator(1) ;
                currentHospital = new Hospital(nameOfHospital,hospitalAddress,Pin);
                
                // This for loop is used for generating the free slots in hospital for seven days from current date
                for (int day= 0; day < numberOfDaysOfSlots; day++)
                {
                    System.Threading.Thread.Sleep(1);
                    currentHospital.AddNewFreeSlots(currentDate, randomObjectForPincode.Next(0,100));
                    currentDate = currentDate.AddDays(1);
                }

                hospitalList.Add(currentHospital);
                Pin = randomObjectForPincode.Next(400000, 400010);
                currentDate = DateTime.Now.Date;
            }
            return hospitalList;
        }
    }
}
