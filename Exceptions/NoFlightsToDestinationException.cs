namespace CourseWork_Airport.Exceptions
{
    public class NoFlightsToDestinationException : Exception
    {
        public NoFlightsToDestinationException(string message) : base(message)
        {
        }
    }
}
