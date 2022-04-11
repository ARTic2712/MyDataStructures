using MyDataStructures.BinarySearchTree;
using MyDataStructures.Queue;
using System;

namespace DataStructureSandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Binary Search Tree
            ////////BINARY SEARCH TREEE//////////////////////////

            var BST = new BinarySearchTree<int>();
            BST.Add(25).Add(15).Add(10).Add(12).Add(50).Add(35).Add(22).Add(31).Add(70).Add(4).Add(24).Add(90).Add(44).Add(18).Add(66).Add(28).Add(18);

            //Traverses 
            Console.WriteLine($"InOrder DFS traversal: {string.Join(" ", BST.DFSInOrderTraversal())}");
            Console.WriteLine($"Pre-Order DFS traversal: {string.Join(" ", BST.DFSPreOrderTraversal())}");
            Console.WriteLine($"Post-Order DFS traversal: {string.Join(" ", BST.DFSPostOrderTraversal())}");
            Console.WriteLine($"BFT traversal: {string.Join(" ", BST.BFT())}");
            BST.Invert();
            Console.WriteLine($"BFT traversal: {string.Join(" ", BST.BFT())}");

            //Console.WriteLine($"Find 18: {BST.Find(18)?.Value.ToString() ?? "Not found!"}");
            //Console.WriteLine($"Find 18 count: {BST.Find(18)?.Count.ToString() ?? "Not found!"}");
            //Console.WriteLine($"Find 45 count: {BST.Find(45)?.Value.ToString() ?? "Not found!"}");

            //BST.Delete(12);
            //Console.WriteLine($"Delete 12");
            //BST.Delete(50);
            //Console.WriteLine($"Delete 50");
            //BST.Delete(31);
            //Console.WriteLine($"Delete 31");
            //Console.WriteLine($"InOrder DFS traversal after deleting: {string.Join(" ", BST.DFSInOrderTraversal())}");

            ////Height
            //Console.WriteLine($"Tree height: {BST.Height}");
            #endregion

            #region Queue
            //var queue = new Queue<NodeQueue<int>,int>();
            //queue.Enqueue(4);
            //queue.Enqueue(6);
            //queue.Enqueue(3);
            //queue.Enqueue(8);
            //Console.WriteLine(queue.Dequeue()?.Value);
            //Console.WriteLine(queue.Dequeue()?.Value);
            //queue.Print();
            //Console.WriteLine(queue.Peek()?.Value);
            //queue.Print();
            //Console.WriteLine(queue.Dequeue()?.Value);
            //Console.WriteLine(queue.Dequeue()?.Value);
            //Console.WriteLine(queue.Dequeue()?.Value);

            #endregion
            Console.ReadLine();
        }
    }
}
