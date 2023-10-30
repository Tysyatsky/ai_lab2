using AI_Lab2.Helpers;

namespace AI_Lab2;

public class TreeNode
{
    private readonly string _name;
    private readonly LinkedList<TreeNode> _children;
    private readonly int _artPoints;
    private readonly int _peoplePoints;
    private readonly int _technologyPoints;
    private Func<Input, bool> Rule { get; set; }
    public string Name { get { return _name; } }

    public TreeNode(string name, Func<Input, bool> rules)
    {
        _name = name;
        _artPoints = 0;
        _peoplePoints = 0;
        _technologyPoints = 0;
        _children = new LinkedList<TreeNode>();
        Rule = rules;
    }

    public TreeNode(string name, Func<Input, bool> rules, int art, int people, int technology)
    {
        _name = name;
        _artPoints = art;
        _peoplePoints = people;
        _technologyPoints = technology;
        _children = new LinkedList<TreeNode>();
        Rule = rules;
    }

    public void AddChild(TreeNode node)
    {
        if (node is null || _children is null)
        {
            return;
        }

        _children.AddLast(node);
    }

    public void Traverse(TreeNode treeNode)
    {   
        if (treeNode is null)
        {
            return;
        }

        if (treeNode.Rule(TreeNodeHelpers.Input
            ?? throw new ArgumentException("Input is null")))
        {
            Console.WriteLine(treeNode.Name);
            TreeNodeHelpers.Stats?.Modify(
                treeNode._artPoints,
                treeNode._peoplePoints,
                treeNode._technologyPoints);

            if (!treeNode._children.Any() && TreeNodeHelpers.Stats is not null)
            {
                TreeNodeHelpers.Stats.Name = treeNode.Name;
                return;
            }

            foreach (var child in treeNode._children)
            {
                Traverse(child);
            }
        }
    }

    public LinkedList<TreeNode> GetChildren()
    {
        return _children;
    }
}
