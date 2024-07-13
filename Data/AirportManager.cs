using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class AirportManager
    {
        //defining a Path to the CSV file containing airport data
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\airports.csv");

        // defining Static list to store airport objects
        public static List<Airports> airportList = new List<Airports>();

        //defining a Constructor to initialize the AirportManager and populate flights
        public AirportManager()
        {
            populateFlights();
        }

        // defining a Method to read the CSV file and populate the airportList
        private void populateFlights()
        {
            Airports airports;
            // Reading all lines from the CSV file
            foreach (string line in File.ReadAllLines(filePath))
            {
                // Splitting each line by comma to extract airport code and name
                string[] parts = line.Split(",");
                string code = parts[0];
                string name = parts[1];

                // Creating a new Airports object and adding it to the list
                airports = new Airports(code, name);
                airportList.Add(airports);
            }
        }

        //defining Static method to get the list of airports
        public static List<Airports> GetAirports()
        {
            return airportList;
        }
    }
}
