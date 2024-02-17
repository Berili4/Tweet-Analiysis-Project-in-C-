using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class TreeNode
    {
        public int Data { get; set; }
        public Liste<TreeNode> Children { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Children = new Liste<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }

}