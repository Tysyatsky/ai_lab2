namespace AI_Lab2.Helpers;

public static class OutputHelper
{
    public static void PrintName(string name) => Console.WriteLine(name);

    public static void PrintMessage(string message) => Console.WriteLine(message);

    public static void PrintFinalScore(Dictionary<string, float> scores)
    {
        Console.Write("Orientation: ");
        PrintName(TreeNodeHelpers.Stats.Name);
        Console.WriteLine("Result: ");
        foreach (var score in scores)
        {
            Console.WriteLine(KeyValuePairTemplate(score));
        }
    }

    private static string KeyValuePairTemplate<TKey, TValue>(KeyValuePair<TKey, TValue> pair) => $"{pair.Key}: {pair.Value}";
}
