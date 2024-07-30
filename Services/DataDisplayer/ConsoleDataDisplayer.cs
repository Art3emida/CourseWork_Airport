using CourseWork_Airport.Exceptions;
using CourseWork_Airport.Models;
using CourseWork_Airport.Services.UserOutput;

namespace CourseWork_Airport.Services.DataDisplayer
{
    public class ConsoleDataDisplayer : IDataDisplayer
    {
        private readonly IUserOutput _userOutput;

        public ConsoleDataDisplayer(IUserOutput userOutput)
        {
            _userOutput = userOutput;
        }

        public void DisplayAirports(Airport[] airports)
        {
            foreach (Airport airport in airports)
            {
                _userOutput.ShowMessage($"Flight number: {airport.FlightNumber}, Aircraft type: {airport.AircraftType}");
            }
        }
    }
}
