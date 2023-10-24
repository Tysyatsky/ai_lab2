using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_Lab2
{
    public class TreeNode<T>
    {
        private LinkedList<TreeNode<T>> _children;
        private readonly double _artPoints;
        private readonly double _peoplePoints;
        private readonly double _technologyPoints;

        public static Stats? Stats;
        public Input Input;
        public Func<Input, bool> Rules { get; set; }

        public TreeNode(Input input, Stats stats, Func<Input, bool> rules)
        {
            _artPoints = 0;
            _peoplePoints = 0;
            _technologyPoints = 0;
            Stats = stats;
            Input = input;
            Rules = rules;
            _children = new LinkedList<TreeNode<T>>();
        }

        public TreeNode(Input input, Stats stats, Func<Input, bool> rules, double art, double people, double technology)
        {
            _artPoints = art;
            _peoplePoints = people;
            _technologyPoints = technology;
            Stats = stats;
            Input = input;
            Rules = rules;
            _children = new LinkedList<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> node)
        {
            if (node is null || _children is null)
            {
                return;
            }

            _children.AddLast(node);
        }

        public void Traverse(TreeNode<T> treeNode)
        {   
            if (treeNode is null ||
                treeNode._children is null ||
                !treeNode._children.Any())
            {
                return;
            }
            treeNode._artPoints.ToString();

            foreach (var child in treeNode._children)
            {   
                Console.WriteLine(child._artPoints.ToString());
                var childToTraverse = treeNode._children?.SingleOrDefault(child => child.Rules(Input));

                if (childToTraverse != null)
                {
                    Stats?.Modify(childToTraverse._artPoints, childToTraverse._peoplePoints, childToTraverse._technologyPoints);
                    Traverse(childToTraverse);
                }
            }
        }

        public LinkedList<TreeNode<T>> GetChildren()
        {
            return _children;
        }
    }
}
