using CourseWork_Airport.Models;

namespace CourseWork_Airport.Services.AirportsFilter
{
    public interface IAirportsFilter
    {
        Airport[] Filter(Airport[] airports, string destination);
    }
}
