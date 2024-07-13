using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Traveless.Data
{
    public class FlightManager
    {
        // defining Path to the CSV file containing flight data
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\flights.csv");

        //defining Static list to store flight objects
        public static List<Flights> flightList = new List<Flights>();

        //defining Static list to store updated flight data for saving to file
        public static List<string> updated_flightList = new List<string>();

        // defining Constructor to initialize the FlightManager and populate flights
        public FlightManager()
        {
            // Clear the flight list before populating it
            flightList.Clear();
            populateFlights();
        }

        //defining Method to read the CSV file and populate the flightList
        private void populateFlights()
        {
            Flights flights;
            // Reading all lines from the CSV file
            foreach (string line in File.ReadAllLines(filePath))
            {
                // Splitting each line by comma to extract flight details
                string[] parts = line.Split(",");
                string code = parts[0];
                string flightName = parts[1];
                string origin = parts[2];
                string destination = parts[3];
                string day = parts[4];
                string time = parts[5];
                int seats = int.Parse(parts[6]);
                double price = double.Parse(parts[7]);

                // Creating a new Flights object and adding it to the list
                flights = new Flights(code, flightName, origin, destination, day, time, seats, price);
                flightList.Add(flights);
            }
        }

        // defining Static method to get the list of flights
        public static List<Flights> GetFlights()
        {
            return flightList;
        }

        // defining Static method to update the seats left for a specific flight
        public static void UpdateFlight(Flights flight)
        {
            // Loop through the flight list to find the flight with the matching flight code
            foreach (var item in flightList)
            {
                if (item.FlightCode == flight.FlightCode)
                {
                    item.Seatsleft = flight.Seatsleft;
                    break;
                }
            }
            // Saving the updated flight list to the file
            saveFile();
        }

        // defining a Static method to save the updated flight list to the CSV file
        private static void saveFile()
        {
            // defining a Path to the CSV file containing flight data
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\flights.csv");
            string addFlights;
            // clearing the updated flight list before adding new data
            updated_flightList.Clear();
            // Looping through the flight list to format flight data for saving
            foreach (Flights items in flightList)
            {
                addFlights = $"{items.FormatForFile()}";
                updated_flightList.Add(addFlights);
            }
            // Write all lines to the CSV file
            File.WriteAllLines(filePath, updated_flightList);
        }

        // defining a Static method to increment the seats left for a specific flight
        public static void updateStatusAdd(string FCode)
        {
            // Looping through the flight list to find the flight with matching flight code
            foreach (var item in flightList)
            {
                if (item.FlightCode == FCode)
                {
                    item.Seatsleft += 1;
                }
            }
            // Saving the updated flight list to the file
            saveFile();
        }

        // defining a Static method to decrement the seats left for a specific flight
        public static void updateStatusRem(string FCode)
        {
            // Looping through the flight list to find the flight with matching flight code
            foreach (var item in flightList)
            {
                if (item.FlightCode == FCode)
                {
                    item.Seatsleft -= 1;
                }
            }
            // Saving the updated flight list to the file
            saveFile();
        }
    }
}
