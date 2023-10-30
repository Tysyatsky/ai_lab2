using AI_Lab2.Enums;

namespace AI_Lab2.Helpers;

public class InputHelpers
{
    public static List<Subjects> SafeSubjectsInput(string message)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();
        return MapToEnum(input);
    }

    public static int SafeIntInput(string message)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();

        if (int.TryParse(input, out int value))
        {
            return value;
        }
        else
        {
            return 0;
        }

    }

    public static bool SafeBoolInput(string message)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();

        if (bool.TryParse(input, out bool value))
        {
            return value;
        }
        else
        {
            return false;
        }
    }

    private static List<Subjects> MapToEnum(string? subjectsStr)
    {
        var subjects = new List<Subjects>();

        if (subjectsStr is null)
        {
            return subjects;
        }

        var splittedWords = subjectsStr.Split(new char[] { ',' }).ToList();

        foreach (string subject in splittedWords)
        {
            if (Enum.TryParse(subject, out Subjects result))
            {
                subjects.Add(result);
            }
        }

        return subjects;
    }
}
