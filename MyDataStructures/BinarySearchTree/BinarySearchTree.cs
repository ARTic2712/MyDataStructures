using MyDataStructures.Queue;
using System;
using System.Collections.Generic;

namespace MyDataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T:IComparable
    {
        private Node<T> _root = null;
        private Node<T> Root { get { return _root; } set { _root = value; } } 
        public int Height => HeightMethod(Root);

        #region Add,Delete,Find
        /// <summary>
        /// Adding a new value to the tree
        /// </summary>
        /// <param name="value"></param>
        public BinarySearchTree<T> Add(T value)
        {
            Root = Add(Root, value);
            return this;
        }
        private Node<T> Add(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value);
            }
            //if node has the same value increase Count
            if (node.Value.Equals(value))
            {
                node.Count++;
                return node;
            }
            //if value less than node value add to left node
            if (node.Value.CompareTo(value) > 0)
            {
                node.Left = Add(node.Left, value);
                return node;
            }
            //if value more than node value add to right node
            node.Right = Add(node.Right, value);
            return node;
        }

        public Node<T> Find(T value)
        {
            return Find(Root, value);
        }
        private Node<T> Find(Node<T> node,T value)
        {
            if (node == null) return null;
            if (node.Value.Equals(value))
            {
                return node;
            }
            if (node.Value.CompareTo(value) > 0)
            {
                return Find(node.Left, value);
            }
            return Find(node.Right, value);
        }
        public void Delete(T value)
        {
            Delete(ref _root, value);
        }
        private void Delete(ref Node<T> node,T value)
        {
            if (node == null) return;
            if (node.Left!=null && node.Left.Value.Equals(value))
            {
                node.Left = Delete(node.Left);
                var left = node.Left;
                if (node.Left!=null)
                    Delete(ref left, node.Left.Value);
            }
            if (node.Right != null && node.Right.Value.Equals(value))
            {
                node.Right = Delete(node.Right);
                var rightNode = node.Right;
                if (node.Right != null)
                    Delete(ref rightNode, node.Right.Value);
            }

            if (node.Value.CompareTo(value) > 0)
            {
                var left = node.Left;
                Delete(ref left, value);
            }
            var right = node.Right;
            Delete(ref right, value);    
        }
        private Node<T> Delete(Node<T> node)
        {
            if (node.Left == null && node.Right == null)
            {
                return null;
            }
            if (node.Left == null)
            {
                return node.Right;
            }
            if (node.Right == null)
            {
                return node.Left;
            }
            var right = node.Right;
            var min = Min(right);
            node.Value = min.Value;
            node.Count = min.Count;
            return node;
        }
        private (T Value, int Count) Min(Node<T> node)
        {
            if (node.Left == null)
            {
                return (node.Value, node.Count);
            }
            return Min(node.Left);
        }
        #endregion

        #region Traversals
        /// <summary>
        /// In order DFS traversal
        /// </summary>
        /// <returns></returns>
        public List<T> DFSInOrderTraversal()
        {
            List<T> result = new List<T>();
            DFSInOrderTraversal(Root,ref result);
            return result;
        }
        private void DFSInOrderTraversal(Node<T> node, ref List<T> list)
        {
            if (node == null) return;
            DFSInOrderTraversal(node.Left, ref list);
            list.Add(node.Value);
            DFSInOrderTraversal(node.Right, ref list);
        }
        /// <summary>
        /// Pre order DFS traversal
        /// </summary>
        /// <returns></returns>
        public List<T> DFSPreOrderTraversal()
        {
            List<T> result = new List<T>();
            DFSPreOrderTraversal(Root, ref result);
            return result;
        }
        private void DFSPreOrderTraversal(Node<T> node, ref List<T> list)
        {
            if (node == null) return;
            list.Add(node.Value);
            DFSPreOrderTraversal(node.Left, ref list);
            DFSPreOrderTraversal(node.Right, ref list);
        }
        /// <summary>
        /// Post order DFS traversal
        /// </summary>
        /// <returns></returns>
        public List<T> DFSPostOrderTraversal()
        {
            List<T> result = new List<T>();
            DFSPostOrderTraversal(Root, ref result);
            return result;
        }
        private void DFSPostOrderTraversal(Node<T> node, ref List<T> list)
        {
            if (node == null) return;
            DFSPostOrderTraversal(node.Left, ref list);
            DFSPostOrderTraversal(node.Right, ref list);
            list.Add(node.Value);
        }
        /// <summary>
        /// BFT Traversal
        /// </summary>
        /// <returns></returns>
        public List<T> BFT()
        {
            if (Root == null) return new List<T>();
            List<T> result = new List<T>();
            var queue = new Queue<NodeQueue<Node<T>>, Node<T>>();
            queue.Enqueue(Root);
            while (!queue.Empty)
            {
                var node = queue.Dequeue();
                if (node.Value.Left != null) queue.Enqueue(node.Value.Left);
                if (node.Value.Right != null) queue.Enqueue(node.Value.Right);
                result.Add(node.Value.Value);
            }
            return result;
        }
        #endregion

        private int HeightMethod(Node<T> node)
        {
            if (node == null) return 0;

            int leftHeight = HeightMethod(node.Left);
            int rightHeight = HeightMethod(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public void Invert()
        {
            Root = Invert(Root);
        }
        private Node<T> Invert(Node<T> root)
        {
            if (root == null) return root;
            var temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;
            root.Left = Invert(root.Left);
            root.Right = Invert(root.Right);
            return root;
        }
    }
}
