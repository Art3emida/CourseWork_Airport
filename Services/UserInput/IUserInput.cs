namespace CourseWork_Airport.Services.UserInput
{
    public interface IUserInput
    {
        string GetString(string hint, string? defaultValue = null);
        int GetInteger(string hint, int minValue = 1);
    }
}
