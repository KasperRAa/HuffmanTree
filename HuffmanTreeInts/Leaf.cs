using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTreeInts
{
    internal class Leaf : Node
    {
        public int Value { get; }

        public Leaf(int count, int value) : base(count)
        {
            Value = value;
        }
    }
}
