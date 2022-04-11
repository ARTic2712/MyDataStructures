namespace MyDataStructures.Queue
{
    public class NodeQueue<T> : INodeQueue<T>
    {
        public T Value { get; set; }
        public NodeQueue(T value)
        {
            Value = value;
        }
        public NodeQueue() { }
    }
}
