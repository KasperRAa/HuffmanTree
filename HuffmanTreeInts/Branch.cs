using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTreeInts
{
    internal class Branch : Node
    {
        public Node Left { get; }
        public Node Right { get; }

        public Branch(Node left, Node right) : base(left.Count + right.Count)
        {
            Left = left;
            Right = right;
        }
    }
}
