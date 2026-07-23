using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    internal abstract class Node
    {
        public int Count { get; }

        public Node(int count)
        {
            Count = count;
        }
    }
}
