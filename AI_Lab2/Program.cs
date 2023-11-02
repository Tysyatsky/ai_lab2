using AI_Lab2.Enums;
using AI_Lab2.Helpers;

namespace AI_Lab2;

internal class Program
{
    private static readonly Func<bool> DefaultRule = () => TreeNodeHelpers.Input is not null;
    static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        TreeNodeHelpers.Stats = new Stats();
        
        GenerateInput();

        // TreeNodeHelpers.Input = Input.Create(1000, false, false, 1, 5, false, new List<Subjects>() { Subjects.Biology });

        var actualRoot = BuildTree();

        actualRoot.Traverse(actualRoot);

        PrintResults();
    }

    private static void PrintResults()
    {
        var results = (TreeNodeHelpers.Stats?.GetFinalModifiers())
            ?? throw new ArgumentNullException("Stats can not be null on result!");

        OutputHelper.PrintFinalScore(results);
    }

    private static TreeNode BuildTestTree()
    {
        var root = new TreeNode("root", DefaultRule);
        var node1 = new TreeNode("node1", () => Input.IsSalaryMatter, 0, 2, 8);
        var node2 = new TreeNode("node2", () => !Input.IsSalaryMatter, 5, 3, 0);
        var leaf = new TreeNode("leaf", () => Input.Salary > 50, -9, 1, 2);

        root.AddChild(node1);
        root.AddChild(node2);
        node1.AddChild(leaf);

        return root;
    }

    private static TreeNode BuildTree()
    {
        var root = new TreeNode("root", DefaultRule);

        var nodeA1 = new TreeNode("nodeA1", () => !Input.IsSalaryMatter, 10, 5, 0);
        var nodeA2 = new TreeNode("nodeA2", () => Input.IsSalaryMatter, 0, 5, 10);

        var nodeB1 = new TreeNode("nodeB1", () => Input.Salary > 0 && Input.Salary < 1000, 10, 5, 0);
        var nodeB2 = new TreeNode("nodeB2", () => Input.Salary < 2000, 0, 5, 0);
        var nodeB3 = new TreeNode("nodeB3", () => Input.Salary >= 2000, 0, 5, 10);

        var nodeC1 = new TreeNode("Art", () => Input.LovesCartoons, 25, 5, 0);
        var nodeC2 = new TreeNode("Design", () => Input.LovesCartoons, 15, 5, 0);
        var nodeC3 = new TreeNode("nodeC3", () => Input.LovesCartoons, 10, 0, -5);

        var nodeC11 = new TreeNode("nodeC11", () => !Input.LovesCartoons, -10, 5, 10);
        var nodeC21 = new TreeNode("nodeC21", () => !Input.LovesCartoons, 5, 5, 5); 
        var nodeC31 = new TreeNode("nodeC31", () => !Input.LovesCartoons, 0, 20, 20);

        var nodeD11 = new TreeNode("Teacher", () => Input.FavouriteSubjects.Contains(Subjects.Math) || Input.FavouriteSubjects.Contains(Subjects.Programming) || Input.FavouriteSubjects.Contains(Subjects.Algebra) ||
         Input.FavouriteSubjects.Contains(Subjects.Chemistry) || Input.FavouriteSubjects.Contains(Subjects.Biology) || Input.FavouriteSubjects.Contains(Subjects.PE), 0, 0, 40);
        var nodeD21 = new TreeNode("Management", () => Input.FavouriteSubjects.Contains(Subjects.Geometry) || Input.FavouriteSubjects.Contains(Subjects.English) || Input.FavouriteSubjects.Contains(Subjects.Language), 5, 15, 5); // management
        var nodeD31 = new TreeNode("Artist", () => Input.FavouriteSubjects.Contains(Subjects.Phycology) || Input.FavouriteSubjects.Contains(Subjects.Art), 50, 0, 0); // art

        var nodeD12 = new TreeNode("nodeD12", () => Input.FavouriteSubjects.Contains(Subjects.Math) || Input.FavouriteSubjects.Contains(Subjects.Programming) || Input.FavouriteSubjects.Contains(Subjects.Algebra), 0, 0, 40);
        var nodeD22 = new TreeNode("nodeD22", () => Input.FavouriteSubjects.Contains(Subjects.Geometry) || Input.FavouriteSubjects.Contains(Subjects.English) || Input.FavouriteSubjects.Contains(Subjects.Language), 5, 15, 5);
        var nodeD32 = new TreeNode("nodeD32", () => Input.FavouriteSubjects.Contains(Subjects.Chemistry) || Input.FavouriteSubjects.Contains(Subjects.Biology) || Input.FavouriteSubjects.Contains(Subjects.PE), 0, 15, 10);
        var nodeD42 = new TreeNode("nodeD42", () => Input.FavouriteSubjects.Contains(Subjects.Phycology) || Input.FavouriteSubjects.Contains(Subjects.Art), 50, 0, 0);

        var nodeD13 = new TreeNode("nodeD13", () => Input.FavouriteSubjects.Contains(Subjects.Math) || Input.FavouriteSubjects.Contains(Subjects.Programming) || Input.FavouriteSubjects.Contains(Subjects.Algebra), 0, 0, 40);
        var nodeD23 = new TreeNode("nodeD23", () => Input.FavouriteSubjects.Contains(Subjects.Geometry) || Input.FavouriteSubjects.Contains(Subjects.English) || Input.FavouriteSubjects.Contains(Subjects.Language), 5, 15, 5);
        var nodeD33 = new TreeNode("Doctor", () => Input.FavouriteSubjects.Contains(Subjects.Chemistry) || Input.FavouriteSubjects.Contains(Subjects.Biology) || Input.FavouriteSubjects.Contains(Subjects.PE), 0, 15, 10);
        var nodeD43 = new TreeNode("Design", () => Input.FavouriteSubjects.Contains(Subjects.Phycology) || Input.FavouriteSubjects.Contains(Subjects.Art), 50, 0, 0);

        var nodeD14 = new TreeNode("Development", () => Input.FavouriteSubjects.Contains(Subjects.Math) || Input.FavouriteSubjects.Contains(Subjects.Programming) || Input.FavouriteSubjects.Contains(Subjects.Algebra), 0, 0, 40); // dev
        var nodeD24 = new TreeNode("Private tutor", () => Input.FavouriteSubjects.Contains(Subjects.Geometry) || Input.FavouriteSubjects.Contains(Subjects.English) || Input.FavouriteSubjects.Contains(Subjects.Language), 5, 15, 5);
        var nodeD34 = new TreeNode("nodeD34", () => Input.FavouriteSubjects.Contains(Subjects.Phycology) || Input.FavouriteSubjects.Contains(Subjects.Art), 50, 0, 0);

        var nodeE1 = new TreeNode("Management", () => Input.LikePeople, 0, 15, 0); // management
        var nodeE2 = new TreeNode("Nurse", () => Input.LikePeople, 0, 15, 0);
        var nodeE3 = new TreeNode("Phycologist", () => Input.LikePeople, 0, 15, 0);
        var nodeE4 = new TreeNode("Teacher", () => Input.LikePeople, 0, 15, 0);
        var nodeE5 = new TreeNode("Art tutor", () => Input.LikePeople, 0, 15, 0);
        var nodeE6 = new TreeNode("nodeE6", () => Input.LikePeople, 0, 15, 0);

        var nodeE11 = new TreeNode("Development", () => !Input.LikePeople, 0, -15, 0); // dev
        var nodeE21 = new TreeNode("nodeE21", () => !Input.LikePeople, 0, -15, 0);
        var nodeE31 = new TreeNode("nodeE31", () => !Input.LikePeople, 0, -15, 0);
        var nodeE41 = new TreeNode("Mechanik", () => !Input.LikePeople, 0, -15, 0);
        var nodeE51 = new TreeNode("Animator", () => !Input.LikePeople, 0, -15, 0);
        var nodeE61 = new TreeNode("Phyciatrist", () => !Input.LikePeople, 0, -15, 0);

        var nodeF1 = new TreeNode("nodeF1", () => Input.TimeSpentOnline < 3, 0, 5, 0);
        var nodeF2 = new TreeNode("nodeF2", () => Input.TimeSpentOnline >= 3 && Input.TimeSpentOnline < 6, 0, 10, 0);
        var nodeF3 = new TreeNode("SSM", () => Input.TimeSpentOnline >= 6, 0, 25, 0);
        var nodeF4 = new TreeNode("Influencer", () => Input.TimeSpentOnline >= 12, 0, 30, 0);

        var nodeG1 = new TreeNode("Unemplayed", () => Input.SocialMediaCount < 5, 0, 5, 0);
        var nodeG2 = new TreeNode("Law", () => Input.SocialMediaCount >= 5, 0, 15, 0);

        var nodeG3 = new TreeNode("Gardener", () => Input.SocialMediaCount < 5, 0, 5, 0);
        var nodeG4 = new TreeNode("SSM", () => Input.SocialMediaCount >= 5, 0, 15, 0);


        root.AddChild(nodeA1); // salary matter
        root.AddChild(nodeA2); // salary doesn't matter

        nodeA1.AddChild(nodeB1); 
        nodeA1.AddChild(nodeB2);
        nodeA2.AddChild(nodeB2);
        nodeA2.AddChild(nodeB3);

        nodeB1.AddChild(nodeC1); // Art
        nodeB1.AddChild(nodeC11);
        nodeB2.AddChild(nodeC2); // Design
        nodeB2.AddChild(nodeC21);
        nodeB3.AddChild(nodeC3);
        nodeB3.AddChild(nodeC31);

        nodeC11.AddChild(nodeD11); // d
        nodeC11.AddChild(nodeD21); // d
        nodeC11.AddChild(nodeD31); // d
        nodeC21.AddChild(nodeD12);
        nodeC21.AddChild(nodeD22);
        nodeC21.AddChild(nodeD32);
        nodeC21.AddChild(nodeD42);
        nodeC3.AddChild(nodeD13);
        nodeC3.AddChild(nodeD23);
        nodeC3.AddChild(nodeD33); // d
        nodeC3.AddChild(nodeD43); // d
        nodeC31.AddChild(nodeD14); // d
        nodeC31.AddChild(nodeD24); // d
        nodeC31.AddChild(nodeD33); // d
        nodeC31.AddChild(nodeD34);

        nodeD12.AddChild(nodeE1); // management
        nodeD12.AddChild(nodeE11); // dev
        nodeD22.AddChild(nodeE1); // management
        nodeD22.AddChild(nodeE11); // dev
        nodeD32.AddChild(nodeE2); // d
        nodeD32.AddChild(nodeE21);
        nodeD42.AddChild(nodeE3); // d
        nodeD42.AddChild(nodeE31);
        nodeD13.AddChild(nodeE4); // management
        nodeD13.AddChild(nodeE41); // dev
        nodeD23.AddChild(nodeE5); // d
        nodeD23.AddChild(nodeE51); // d
        nodeD34.AddChild(nodeE6);
        nodeD34.AddChild(nodeE61); // d

        nodeE21.AddChild(nodeF1);
        nodeE21.AddChild(nodeF2);
        nodeE21.AddChild(nodeF3); //d
        nodeE31.AddChild(nodeF1);
        nodeE31.AddChild(nodeF2);
        nodeE31.AddChild(nodeF3); //d
        nodeE6.AddChild(nodeF1);
        nodeE6.AddChild(nodeF2);
        nodeE6.AddChild(nodeF3); //d
        nodeE6.AddChild(nodeF4); //d

        nodeF1.AddChild(nodeG1);
        nodeF1.AddChild(nodeG2);
        nodeF2.AddChild(nodeG3);
        nodeF2.AddChild(nodeG4);

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