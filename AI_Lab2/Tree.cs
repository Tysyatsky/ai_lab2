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

        public Func<bool, Stats> Rules { get; set; }

        public Func<List<double>> GetModifiers { get; set; }

        public void Traverse(TreeNode<T> treeNode)
        {
            foreach (var child in _children)
            {
                if(child.Rules())
            }
        }

        public LinkedList<TreeNode<T>> GetChildren()
        {
            return _children;
        }
    }
}
