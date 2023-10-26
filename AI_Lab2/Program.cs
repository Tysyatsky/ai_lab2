using AI_Lab2.Enums;
using AI_Lab2.Helpers;

namespace AI_Lab2;

internal class Program
{
    private static readonly Func<Input, bool> DefaultRule = (input) => input is not null;
    static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        TreeNodeHelpers.Stats = new Stats();
        
        // GenerateInput();

        Console.WriteLine("Hello, World!");

        var testInput = TreeNodeHelpers.Input = Input.Create(100, true, true, 5, 2, true, new List<Subjects>() { Subjects.Math, Subjects.Geometry});

        var actualRoot = new TreeNode("root", DefaultRule);

        var root = BuildTestTree();

        root.Traverse(root);

        PrintResults();
    }

    private static void PrintResults()
    {
        var results = (TreeNodeHelpers.Stats?.GetFinalModifiers())
            ?? throw new ArgumentNullException("Stats can not be null on result!");

        results.TryGetValue("Art", out int artPoints);
        results.TryGetValue("People", out int peoplePoint);
        results.TryGetValue("Technology", out int technology);

        Console.WriteLine("Result: ");
        Console.WriteLine(artPoints);
        Console.WriteLine(peoplePoint);
        Console.WriteLine(technology);
    }

    private static TreeNode BuildTestTree()
    {
        var root = new TreeNode("root", DefaultRule);
        var node1 = new TreeNode("node1", (input) => Input.IsSalaryMatter, 0, 2, 8);
        var node2 = new TreeNode("node2", (input) => !Input.IsSalaryMatter, 5, 3, 0);
        var leaf = new TreeNode("leaf", (input) => Input.Salary > 50, -9, 1, 2);

        root.AddChild(node1);
        root.AddChild(node2);
        node1.AddChild(leaf);

        return root;
    }

    private static TreeNode BuildTree()
    {
        var root = new TreeNode("root", DefaultRule);

        var leafArt = new TreeNode("art", DefaultRule);
        var leafPeople = new TreeNode("people", DefaultRule);
        var leafTechnology = new TreeNode("technology", DefaultRule);



        return root;
    }

    private static Input GenerateInput()
    {
        var subjects = InputHelpers.SafeSubjectsInput("Enter your favourite subjects: ");
        var isSalaryMatter = InputHelpers.SafeBoolInput("Is salary matter for you? True/False: ");
        var likePeople = InputHelpers.SafeBoolInput("Do you like people? True/False: ");
        var loveCartoons = InputHelpers.SafeBoolInput("Do you like cartoons? True/False: ");
        var salary = InputHelpers.SafeIntInput("What salary do you want in the future? Enter number from 0: ");
        var timeSpentOnline = InputHelpers.SafeIntInput("How much time in hours do you spend online a day? Enter number from 0 to 24: ");
        var socialMediaCount = InputHelpers.SafeIntInput("How many social medias do you use? Enter number from 0: ");

        return TreeNodeHelpers.Input = Input.Create(salary, isSalaryMatter, likePeople, timeSpentOnline, socialMediaCount, loveCartoons, subjects);
    }
}