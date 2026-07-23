using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    public class Tree
    {
        private Node _root;

        private Tree(Node root)
        {
            _root = root;
        }

        public Dictionary<byte, string> GetDictionary()
        {
            if (_root.GetType() == typeof(Leaf))
            {
                var leafDict = new Dictionary<byte, string>();
                leafDict.Add(((Leaf)_root).Value, "0");
                return leafDict;
            }

            var dict = new Dictionary<byte, string>();
            RecursiveDepthSearch(_root, dict, "");

            return dict;

            void RecursiveDepthSearch(Node node, Dictionary<byte, string> dict, string path)
            {
                if (node.GetType() == typeof(Leaf)) dict.Add(((Leaf)node).Value, path);
                else
                {
                    Branch branch = (Branch)node;

                    RecursiveDepthSearch(branch.Left, dict, path + "0");
                    RecursiveDepthSearch(branch.Right, dict, path + "1");
                }
            }
        }

        public static Tree GetTreeFromArray(IReadOnlyList<byte> bytes)
        {
            int[] counts = new int[256];

            foreach (byte b in bytes) counts[b]++;

            List<Node> nodes = new List<Node>();
            for (int value = 0; value < 256; value++)
            {
                if (counts[value] == 0) continue;
                nodes.Add(new Leaf(counts[value], (byte)value));
            }

            while (nodes.Count > 1)
            {
                nodes.Sort((x1, x2) => x1.Count - x2.Count);
                nodes.Add(new Branch(nodes[0], nodes[1]));
                nodes.RemoveRange(0, 2);
            }

            return new Tree(nodes[0]); 
        }
    }
}
