using CourseWork_Airport.Services.UserOutput;

namespace CourseWork_Airport.Services.UserInput
{
    public class ConsoleUserInput : IUserInput
    {
        private readonly IUserOutput _userOutput;
        public ConsoleUserInput(IUserOutput userOutput)
        {
            _userOutput = userOutput;
        }

        public string GetString(string hint, string? defaultValue = null)
        {
            string input;

            do
            {
                _userOutput.ShowMessage(hint);
                input = Console.ReadLine() ?? "";

                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        if (defaultValue == null)
                        {
                            throw new ArgumentException("Input cannot be empty.");
                        }
                        else
                        {
                            input = defaultValue;
                            _userOutput.ShowMessage("[GENERATED] " + defaultValue + Environment.NewLine);
                        }
                    }

                    break;
                }
                catch (ArgumentException ex)
                {
                    _userOutput.ShowMessage(ex.Message);
                }
            }
            while (true);

            return input;
        }

        public int GetInteger(string hint, int minValue = 1)
        {
            int input;

            do
            {
                try
                {
                    _userOutput.ShowMessage(hint);
                    input = int.Parse(Console.ReadLine() ?? "");

                    if (input < minValue)
                        throw new ArgumentException($"Input must be greater then {minValue - 1}. Try again");

                    break;
                }
                catch (FormatException)
                {
                    _userOutput.ShowMessage("Input should contain only numbers. Try again");
                }
                catch (ArgumentException ex)
                {
                    _userOutput.ShowMessage(ex.Message);
                }
            }
            while (true);

            return input;
        }
    }
}
