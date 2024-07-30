using CourseWork_Airport.Models;

namespace CourseWork_Airport.Services.AirportsFilter
{
    internal class DestinationAirportsFilter : IAirportsFilter
    {
        public Airport[] Filter(Airport[] airports, string destination)
        {
            return airports.Where(a => a.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToArray();
        }
    }
}
