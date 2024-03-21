using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLocatorApp
{
    // This class is used for making search operation on the list and target variable given (pincodeToSearch).
    public class HospitalFinder
    {
        // Function used for searching the hospital with pincode.
        public static List<Hospital> searchHospitalWithPincode(int pincodeToSearch, List<Hospital> listOfAllHospital)
        {
            List<Hospital> currentHospitalList= new List<Hospital>();
            foreach(Hospital currentHospital in listOfAllHospital)
            {
                if (currentHospital.pinCodeOfHospital == pincodeToSearch)
                {
                    currentHospitalList.Add(currentHospital);
                }
            }
            return currentHospitalList;
        }
    }
}
