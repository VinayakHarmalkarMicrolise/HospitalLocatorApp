using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLocatorApp
{
    internal class Program
    {
        // This function is for printing the list of hospital details.
        public static void printListOfHospitals(List<Hospital> hospitalList)
        {
            Console.WriteLine("List of Hospitals in your area :");
            Console.WriteLine(hospitalList.Count + " hospital(s) found against given pincode. See the list below...");
            int countOfHospital = 0;
            foreach (Hospital hospital in hospitalList)
            {
                Console.Write("(Hospital " + ++countOfHospital+") ");
                Console.Write(hospital.nameOfHospital);
                Console.Write(" | " + hospital.addressOfHospital);
                Console.WriteLine(" | " + hospital.pinCodeOfHospital);
                foreach (var slot in hospital.slotsAvailabilityForVaccinations)
                {
                    Console.Write(slot.dateOfSlotAvailable.ToString("dd/MM/yyyy") + ": ");
                    Console.WriteLine(slot.numberOfFreeSlots+" free slots");
                }
                Console.WriteLine("--------------------------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            List<Hospital> hospitalList;
            try
            {
                // User input for the hosptials to be generated
                Console.WriteLine("Enter the number of hospitals to be generated: ");
                int numberOfHospitalsWantToEnter = int.Parse(Console.ReadLine());

                // User input for the slots to be generated in each hospital
                Console.WriteLine("Enter the number of days of slots to be generated: ");
                int numberDaysOfSlots = int.Parse(Console.ReadLine());

                // Generates the data(list of all hospital) and return it, and it is stored in the hospitalList variable 
                hospitalList = TestDataGenerator.GenerateHospitals(numberOfHospitalsWantToEnter, numberDaysOfSlots);
                
                // This is for clearing the screen
                Console.Clear();

                // Takes input from user of the pincode to be searched.
                // If the user enters a pincode of not length 6 then, user need to re-enter the pincode
                int pincodeToSearch =0;
                int flag = 0;
                do
                {
                    if(flag == 1)
                    {
                        Console.WriteLine("Enter valid pincode :");
                        pincodeToSearch = int.Parse(Console.ReadLine());
                    }
                    if(flag == 0)
                    {
                        Console.WriteLine("Enter the pincode to search hospitals :");
                        pincodeToSearch = int.Parse(Console.ReadLine());
                    }
                    if(pincodeToSearch.ToString().Length != 6)
                    {
                        flag = 1;
                    }               
                } while (pincodeToSearch.ToString().Length != 6);

                // Time recorded before search starts
                var timeRecordedBeforeSearch = DateTime.Now;
                
                // Following line returns list of hospitals which are present at given pincode
                List<Hospital> resultOfSearchWithPincode = HospitalFinder.searchHospitalWithPincode(pincodeToSearch, hospitalList);
                
                // Time recorded after the search is completed 
                DateTime timeRecordedAfterSearch = DateTime.Now;

                // Time required for search is calculated
                TimeSpan diff = timeRecordedAfterSearch - timeRecordedBeforeSearch;

                // If - Else block for printing the hospitals searched by pincode
                if (resultOfSearchWithPincode.Count == 0)
                {
                    // If there are no hospitals available printed this display
                    Console.WriteLine("No hospital available at the given pincode " + pincodeToSearch);
                    Console.WriteLine("Search result returned in "+diff.ToString("ss':'ffffff")+" Milliseconds ");
                }
                else
                {
                    printListOfHospitals(resultOfSearchWithPincode);
                    Console.WriteLine("Search result returned in " + diff.ToString("ss':'ffffff") +" Milliseconds");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}