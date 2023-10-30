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

        var testInput = TreeNodeHelpers.Input = Input.Create(1001, true, true, 5, 2, true, new List<Subjects>() { Subjects.Biology});

        var actualRoot = BuildTree();

        //var root = BuildTestTree();

        //root.Traverse(root);

        actualRoot.Traverse(actualRoot);

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

        var nodeA1 = new TreeNode("nodeA1", (input) => !Input.IsSalaryMatter, 0, 3, 5);
        var nodeA2 = new TreeNode("nodeA2", (input) => Input.IsSalaryMatter, 1, 2, 0);

        var nodeB1 = new TreeNode("nodeB1", (input) => Input.Salary > 0 && Input.Salary <= 100, 4, 3, 0);
        var nodeB2 = new TreeNode("nodeB2", (input) => Input.Salary > 100 && Input.Salary <= 1000, 2, 4, 3);
        var nodeB3 = new TreeNode("nodeB3", (input) => Input.Salary > 1000 && Input.Salary <= 10000, 0, 3, 6);
        var nodeB4 = new TreeNode("nodeB4", (input) => Input.Salary > 10000, 0, 1, 8);

        var nodeC1 = new TreeNode("nodeC1", (input) => Input.LovesCartoons && Input.IsSalaryMatter && Input.LikePeople, 2, -1, 2);
        var nodeC2 = new TreeNode("nodeC2", (input) => Input.LovesCartoons && !Input.IsSalaryMatter && Input.LikePeople, 5, 0, -5);
        var nodeC3 = new TreeNode("nodeC3", (input) => !Input.LovesCartoons && Input.IsSalaryMatter && Input.LikePeople, -2, 0, 8);
        var nodeC4 = new TreeNode("Teacher", (input) => !Input.LovesCartoons && !Input.IsSalaryMatter && Input.LikePeople, -1, 8, -1); // teacher
        var nodeC5 = new TreeNode("Development", (input) => !Input.LovesCartoons && Input.IsSalaryMatter && !Input.LikePeople, -2, -2, 9); // developer
        var nodeC6 = new TreeNode("nodeC6", (input) => !Input.LovesCartoons && !Input.IsSalaryMatter && !Input.LikePeople, -2, -2, -2); 
        var nodeC7 = new TreeNode("Artist", (input) => Input.LovesCartoons && Input.IsSalaryMatter && !Input.LikePeople, 8, -1, -1); // art
        var nodeC8 = new TreeNode("nodeC8", (input) => !Input.LovesCartoons && !Input.IsSalaryMatter && Input.LikePeople, -1, 8, -1); // ???

        root.AddChild(nodeA1); // salary matter
        root.AddChild(nodeA2); // salary doesn't matter

        nodeA1.AddChild(nodeB1); 
        nodeA1.AddChild(nodeB2);
        nodeA2.AddChild(nodeB3);
        nodeA2.AddChild(nodeB4);

        nodeB1.AddChild(nodeC2);
        nodeB1.AddChild(nodeC4);
        nodeB2.AddChild(nodeC6);
        nodeB2.AddChild(nodeC8);

        nodeB3.AddChild(nodeC1);
        nodeB3.AddChild(nodeC3);
        nodeB4.AddChild(nodeC5);
        nodeB4.AddChild(nodeC7);

        BuildSubjectsSubTree(nodeC1);
        BuildSubjectsSubTree(nodeC2);
        BuildSubjectsSubTree(nodeC3);
        BuildSubjectsSubTree(nodeC6);
        BuildSubjectsSubTree(nodeC8);

        return root;
    }

    private static TreeNode BuildSubjectsSubTree(TreeNode root)
    {
        var nodeD1 = new TreeNode("Development", (input) => Input.FavouriteSubjects?.Contains(Subjects.Math) ?? false, 0, 2, 10); // Math -> Dev
        var nodeD11 = new TreeNode("nodeD11", (input) => !Input.FavouriteSubjects?.Contains(Subjects.Math) ?? false, 0, 2, 10); // Math -> Dev
        var nodeD2 = new TreeNode("Influencer", (input) => Input.FavouriteSubjects.Contains(Subjects.Phycology), 1, 10, 2); // Phycology -> Influencer
        var nodeD21 = new TreeNode("nodeD21", (input) => !Input.FavouriteSubjects.Contains(Subjects.Phycology), 1, 10, 2); // Phycology -> Influencer
        var nodeD3 = new TreeNode("Artist", (input) => Input.FavouriteSubjects.Contains(Subjects.Art), 10, 1, 0); // Art -> Artist
        var nodeD31 = new TreeNode("nodeD31", (input) => !Input.FavouriteSubjects.Contains(Subjects.Art), 10, 1, 0); // Art -> Artist
        var nodeD4 = new TreeNode("nodeD4", (input) => Input.FavouriteSubjects.Contains(Subjects.PE), 0, 5, 0);
        var nodeD5 = new TreeNode("Development", (input) => Input.FavouriteSubjects.Contains(Subjects.Programming), 1, 2, 15); // Programming -> Dev 
        var nodeD51 = new TreeNode("nodeD51", (input) => !Input.FavouriteSubjects.Contains(Subjects.Programming), 1, 2, 15); // Programming -> Dev 
        var nodeD6 = new TreeNode("Development", (input) => Input.FavouriteSubjects.Contains(Subjects.Algebra), 0, 0, 5); // Alge -> Dev
        var nodeD61 = new TreeNode("nodeD61", (input) => !Input.FavouriteSubjects.Contains(Subjects.Algebra), 0, 0, 5); // Alge -> Dev
        var nodeD7 = new TreeNode("nodeD7", (input) => Input.FavouriteSubjects.Contains(Subjects.English), 0, 5, 0);
        var nodeD8 = new TreeNode("Development", (input) => Input.FavouriteSubjects.Contains(Subjects.Geometry), 0, 0, 5); // Geo -> Dev
        var nodeD81 = new TreeNode("nodeD81", (input) => !Input.FavouriteSubjects.Contains(Subjects.Geometry), 0, 0, 5); // Geo -> Dev
        var nodeD9 = new TreeNode("Doctor", (input) => Input.FavouriteSubjects.Contains(Subjects.Biology) || Input.FavouriteSubjects.Contains(Subjects.Chemistry), 2, 10, 3); // doctor

        var nodeF2 = new TreeNode("Design", (input) => Input.TimeSpentOnline > 4 && Input.TimeSpentOnline <= 8, 8, 2, 2); // Design
        var nodeF3 = new TreeNode("Influencer", (input) => Input.TimeSpentOnline > 8 && Input.TimeSpentOnline <= 12, 2, 10, 2); // Insluencer
        var nodeF4 = new TreeNode("Development", (input) => Input.TimeSpentOnline > 12 && Input.TimeSpentOnline <= 16, 1, 2, 3); // Dev
        var nodeF5 = new TreeNode("Teacher", (input) => Input.TimeSpentOnline > 16 && Input.TimeSpentOnline <= 20, 2, 5, 1); // teacher
        var nodeF6 = new TreeNode("Management", (input) => Input.TimeSpentOnline > 20 && Input.TimeSpentOnline < 24, 0, 4, 3); // management

        var leafArtist = new TreeNode("Artist", DefaultRule);
        var leafTeacher = new TreeNode("Teacher", DefaultRule);
        var leafDevelopment = new TreeNode("Development", DefaultRule);
        var leafDesign = new TreeNode("Design", DefaultRule);
        var leafManagement = new TreeNode("Management", DefaultRule);
        var leafInfluencer = new TreeNode("Influencer", DefaultRule);
        var leafDoctor = new TreeNode("Doctor", DefaultRule);

        root.AddChild(nodeD1);
        root.AddChild(nodeD11);

        nodeD11.AddChild(nodeD2);
        nodeD11.AddChild(nodeD21);

        nodeD21.AddChild(nodeD3);
        nodeD21.AddChild(nodeD31);

        nodeD31.AddChild(nodeD4);
        nodeD31.AddChild(nodeD5);
        nodeD31.AddChild(nodeD51);

        nodeD51.AddChild(nodeD6);
        nodeD51.AddChild(nodeD61);
        
        nodeD61.AddChild(nodeD7);
        nodeD61.AddChild(nodeD8);
        nodeD61.AddChild(nodeD81);
        
        nodeD81.AddChild(nodeD9);
        nodeD81.AddChild(nodeF6);

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