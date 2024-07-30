/*
    Завдання 12
    Створіть консольний застосунок «Аеропорт».
    Умова задачі
    Визначити клас з ім'ям Airport, який містить такі поля:
    • назву пункту призначення;
    • номер рейсу;
    • тип літака.
    І методи:
    • введення даних масив з n елементів типу Airport;
    • упорядкувати масив за спаданням номера рейсу;
    • виведення номера рейсів і типів літаків, що вилітають у пункт, назва якого збіглася з назвою,
    введеною користувачем.
*/

using CourseWork_Airport.Services.AirportsFilter;
using CourseWork_Airport.Services.AirportsSorter;
using CourseWork_Airport.Services.DataDisplayer;
using CourseWork_Airport.Services.DataProvider;
using CourseWork_Airport.Services.UserInput;
using CourseWork_Airport.Services.UserOutput;

namespace CourseWork_Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserOutput userOutput = new ConsoleUserOutput();
            IUserInput userInput = new ConsoleUserInput(userOutput);
            IDataProvider dataProvider = new ConsoleDataProvider(userInput, userOutput);
            IDataDisplayer dataDisplayer = new ConsoleDataDisplayer(userOutput);
            IAirportsSorter sorter = new FlightNumberDescSorter();
            IAirportsFilter filter = new DestinationAirportsFilter();

            var airportApplication = new AirportApp(
                userInput,
                userOutput,
                dataProvider,
                dataDisplayer,
                sorter,
                filter
            );
            airportApplication.Run();
        }
    }
}
