using CourseWork_Airport.Models;

namespace CourseWork_Airport.Services.AirportsSorter
{
    public class FlightNumberAscSorter : IAirportsSorter
    {
        public void Sort(Airport[] airports)
        {
            Array.Sort(airports, (a, b) => a.FlightNumber.CompareTo(b.FlightNumber));
        }
    }
}
