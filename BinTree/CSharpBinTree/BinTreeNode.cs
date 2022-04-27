using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBinTree
{
    public class BinTreeNode
    {
        public int Value { get; set; }
        public BinTreeNode Left { get; set; }
        public BinTreeNode Right { get; set; }

        public BinTreeNode(int val)
        {
            Value = val;
        }
    }
}
