using System;

namespace MyDataStructures.BinarySearchTree
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; internal set; }
        public int Count { get; internal set; } = 1;

        public Node<T> Left { get; internal set; } = null;
        public Node<T> Right { get; internal set; } = null;

        public Node(T value)
        {
            Value = value;
        }        
    }
}
