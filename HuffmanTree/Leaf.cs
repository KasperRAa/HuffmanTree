using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    internal class Leaf : Node
    {
        public byte Value { get; }

        public Leaf(int count, byte value) : base(count)
        {
            Value = value;
        }
    }
}
