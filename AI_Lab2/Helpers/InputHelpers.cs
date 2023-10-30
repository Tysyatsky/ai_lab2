using AI_Lab2.Enums;
using System.Net;

namespace AI_Lab2.Helpers;

public static class InputHelpers
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

        var splittedWords = subjectsStr.Split(',').ToList();

        foreach (string subject in splittedWords)
        {
            if (Enum.TryParse(subject, out Subjects result))
            {
                subjects.Add(result);
            }
        }

        return subjects.UpdateSubjects();
    }

    private static List<Subjects> UpdateSubjects(this List<Subjects> subjects)
    {
        if (subjects is null)
        {
            throw new ArgumentNullException(nameof(subjects));
        }

        return subjects.Count == 1 ? subjects : subjects.Take(1).ToList();
    }
}
