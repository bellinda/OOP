using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.BinarySearchTree
{
    class TestingBinSearchTrees
    {
        static void Main()
        {
            BinarySearchTree<int> intTree = new BinarySearchTree<int>();
            intTree.Insert(16);
            intTree.Insert(12);
            intTree.Insert(11);
            intTree.Insert(17);
            intTree.Insert(13);
            intTree.ToString();
            Console.WriteLine(intTree);
            intTree.Remove(13);
            Console.WriteLine(intTree);
            foreach (var node in intTree)
            {
                Console.WriteLine(node);
            }
        }
    }
}
