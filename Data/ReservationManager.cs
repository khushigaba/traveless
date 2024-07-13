using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Traveless.Data
{
    public class ReservationManager
    {
        //defining a Path to the CSV file containing reservation data
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\reservation.csv");

        // defining a Static list to store reservation objects
        public static List<Reservation> ReservationList = new List<Reservation>();

        //defining a Static list to store updated reservation data for saving to file
        public static List<string> updated_reservations = new List<string>();

        //defining a Constructor to initialize the ReservationManager and populate reservations
        public ReservationManager()
        {
            // Clearing the reservation list before populating it
            ReservationList.Clear();
            populateReservations();
        }

        //defining a Method to read the CSV file and populate the ReservationList
        private void populateReservations()
        {
            Reservation reserve;
            // Reading all lines from the CSV file
            foreach (string line in File.ReadAllLines(filePath))
            {
                // Checking if the file length is less than 10 bytes (possibly an empty file or header-only)
                if (new FileInfo(filePath).Length < 10)
                {
                    //
                }
                else
                {
                    // Splitting each line by comma to extract reservation details
                    string[] parts = line.Split(",");
                    Flights flight = new Flights(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], int.Parse(parts[6]), double.Parse(parts[7]));
                    string name = parts[8];
                    string citizenship = parts[9];
                    string reservationCode = parts[10];
                    string status = parts[11];

                    // Creating a new Reservation object and adding it to the list
                    reserve = new Reservation(flight, name, citizenship, reservationCode, status);
                    ReservationList.Add(reserve);
                }

            }
        }

        // creating a Static method to get the list of reservations
        public static List<Reservation> GetReservations()
        {
            return ReservationList;
        }

        //creating a Static method to make a new reservation
        public static string MakeReservation(Flights flight, string name, string citizenship)
        {
            // Generating a random reservation code
            Random _random = new Random();
            char letter = (char)('A' + _random.Next(0, 26));
            int digits = _random.Next(1000, 10000);
            string reservationCode = $"{letter}{digits}";

            // Creating a new Reservation object and adding it to the list
            Reservation reserved;
            reserved = new Reservation(flight, name, citizenship, reservationCode);
            ReservationList.Add(reserved);

            // Saving the updated reservation list to the file
            saveFile();

            // Returning the generated reservation code
            return reservationCode;
        }

        // creating a Static method to save the updated reservation list to the CSV file
        private static void saveFile()
        {
            //defining Path to the CSV file containing reservation data
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\reservation.csv");
            string addReservations;
            // Clearing the updated reservation list before adding new data
            updated_reservations.Clear();
            // Looping through the reservation list to format reservation data for saving
            foreach (Reservation items in ReservationList)
            {
                addReservations = $"{items.FormatForFile()}";
                updated_reservations.Add(addReservations);
            }
            // Writing all lines to the CSV file
            File.WriteAllLines(filePath, updated_reservations);
        }

        // creating a Static method to update a reservation's details
        public static void updateReservation(string reserveCode, string updatedName, string UpdatedCitizenship, string updatedStatus)
        {
            // Looping through the reservation list to find the reservation with the matching reservation code
            foreach (Reservation items in ReservationList)
            {
                if (items.ReservationCode == reserveCode)
                {
                    // Updating reservation details
                    items.Name = updatedName;
                    items.Citizenship = UpdatedCitizenship;

                    // Checking if status is updated and update flight status accordingly
                    if (updatedStatus != items.Status)
                    {
                        if (updatedStatus == "Active")
                        {
                            FlightManager.updateStatusAdd(items.Flight.FlightCode);
                            items.Status = updatedStatus;
                        }
                        else if (updatedStatus == "Inactive")
                        {
                            FlightManager.updateStatusRem(items.Flight.FlightCode);
                            items.Status = updatedStatus;
                        }
                    }
                }
            }
            // Saving the updated reservation list to the file
            saveFile();
        }

    }
}
