namespace AI_Lab2
{
    internal class Program
    {
        public static Stats Stats = new Stats();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var input = new Input(100, true, "Math, PE, Geometry", true, 5, 2, true);

            var root = new TreeNode<int>(input, Stats, (input) => input is not null, 0.0, 0.0, 0.0);
            var node1 = new TreeNode<int>(input, Stats, (input) => input.IsSalaryMatter, 0.0, 0.2, 0.8);
            var node2 = new TreeNode<int>(input, Stats, (input) => !input.IsSalaryMatter, 0.5, 0.5, 0.0);
            var leaf = new TreeNode<int>(input, Stats, (input) => input.Salary > 50, -0.9, 0.1, 0.2);

            // root.AddChild(node1);
            root.AddChild(node1);
            root.AddChild(node2);
            node1.AddChild(leaf);

            root.Traverse(root);

            var results = Stats.GetFinalModifiers();

            Console.WriteLine("Result: ");

            results.TryGetValue("Art", out double artPoints);
            results.TryGetValue("People", out double peoplePoint);
            results.TryGetValue("Technology", out double technology);

            Console.WriteLine(artPoints);
            Console.WriteLine(peoplePoint);
            Console.WriteLine(technology);
        }
    }
}