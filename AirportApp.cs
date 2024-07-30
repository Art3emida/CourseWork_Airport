using CourseWork_Airport.Exceptions;
using CourseWork_Airport.Models;
using CourseWork_Airport.Services.AirportsFilter;
using CourseWork_Airport.Services.AirportsSorter;
using CourseWork_Airport.Services.DataDisplayer;
using CourseWork_Airport.Services.DataProvider;
using CourseWork_Airport.Services.UserInput;
using CourseWork_Airport.Services.UserOutput;

namespace CourseWork_Airport
{
    public class AirportApp
    {
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;
        private readonly IDataProvider _dataProvider;
        private readonly IDataDisplayer _dataDisplayer;
        private readonly IAirportsSorter _sorter;
        private readonly IAirportsFilter _filter;

        public AirportApp(
            IUserInput userInput,
            IUserOutput userOutput,
            IDataProvider dataProvider,
            IDataDisplayer dataDisplayer,
            IAirportsSorter sorter,
            IAirportsFilter filter
        ) {
            _userInput = userInput;
            _userOutput = userOutput;
            _dataProvider = dataProvider;
            _dataDisplayer = dataDisplayer;
            _sorter = sorter;
            _filter = filter;
        }

        public void Run()
        {
            Airport[] airports = _dataProvider.GetAirports();

            _sorter.Sort(airports);

            while (true)
            {
                try
                {
                    string destination = _userInput.GetString("Enter the destination name to display the routes:");

                    var filteredAirports = FilterAirportsByDestination(airports, destination);
                    _dataDisplayer.DisplayAirports(filteredAirports);

                    var choice = _userInput.GetString("\nDo you wish to continue? Press Enter to proceed, or type any other character to exit.", "continue");
                    if (choice != "continue")
                        break;
                }
                catch (NoFlightsToDestinationException ex)
                {
                    _userOutput.ShowMessage(ex.Message);
                }
            }
        }

        private Airport[] FilterAirportsByDestination(Airport[] airports, string destination)
        {
            var filteredAirports = _filter.Filter(airports, destination);
            if (filteredAirports.Length == 0)
                throw new NoFlightsToDestinationException("There are no flights to the specified destination. Try again.");

            return filteredAirports;
        }
    }
}
