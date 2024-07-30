using CourseWork_Airport.Models;

namespace CourseWork_Airport.Services.AirportsSorter
{
    public class FlightNumberDescSorter : IAirportsSorter
    {
        public void Sort(Airport[] airports)
        {
            Array.Sort(airports, (a, b) => b.FlightNumber.CompareTo(a.FlightNumber));
        }
    }
}
