namespace CourseWork_Airport.Services.UserOutput
{
    public class ConsoleUserOutput : IUserOutput
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
