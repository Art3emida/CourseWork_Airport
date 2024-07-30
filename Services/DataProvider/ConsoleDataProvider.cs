using CourseWork_Airport.Models;
using CourseWork_Airport.Services.UserInput;
using CourseWork_Airport.Services.UserOutput;

namespace CourseWork_Airport.Services.DataProvider
{
    public class ConsoleDataProvider : IDataProvider
    {
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;
        private readonly Random _random;

        public ConsoleDataProvider(IUserInput userInput, IUserOutput userOutput)
        {
            _userInput = userInput;
            _userOutput = userOutput;
            _random = new Random();
        }

        public Airport[] GetAirports()
        {
            int n = _userInput.GetInteger("Enter the number of flights:");
            Airport[] airports = new Airport[n];

            for (int i = 0; i < n; i++)
            {
                _userOutput.ShowMessage($"Enter the information for flight {i + 1}:");
                _userOutput.ShowMessage("(You can press Enter without entering any information, and random values will be generated)");

                string destination = _userInput.GetString("Destination name (for example London):", GenerateRandomDestination());
                string flightNumber = _userInput.GetString("Flight number (for example F15768):", GenerateRandomFlightNumber());
                string aircraftType = _userInput.GetString("Aircraft type (for example Boeing 747):", GenerateRandomAircraftType());

                airports[i] = new Airport(destination, flightNumber, aircraftType);
            }

            return airports;
        }

        private string GenerateRandomFlightNumber()
        {
            int number = _random.Next(1, 10);
            return $"F{number}";
        }

        private string GenerateRandomDestination()
        {
            string[] destinations = {
                "London",
                "Berlin",
                "Rome",
                "New York",
                "Miami"
            };
            int index = _random.Next(destinations.Length);
            return destinations[index];
        }

        private string GenerateRandomAircraftType()
        {
            string[] aircraftTypes = {
                "Boeing 737",
                "Boeing 747",
                "Airbus A320",
                "Airbus A380",
                "Broiler 747"
            };
            int index = _random.Next(aircraftTypes.Length);
            return aircraftTypes[index];
        }
    }
}
