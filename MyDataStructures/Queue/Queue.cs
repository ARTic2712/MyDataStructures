using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDataStructures.Queue
{
    public class Queue<Node,T> where Node: class, INodeQueue<T>,new()
    {
        private List<Node> Data { get; set; } = new List<Node>();
        public bool Empty => !Data.Any();
        public void Enqueue(Node node)
        {
            Data.Add(node);
        }
        public void Enqueue(T value)
        {
            var val = new Node();
            val.Value = value;
            Data.Add(val);
        }
        public Node Dequeue()
        {
            if (!Data.Any()) return null;

            var node = Data[0];
            Data.RemoveAt(0);
            return node;
        }
        public Node Peek()
        {
            if (!Data.Any()) return null;

            return Data[0];
        }

        public void Print()
        {
            Console.WriteLine( string.Join(", ", Data.Select(s=>s.Value)));
        }
    }
}
