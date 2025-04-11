using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BinarySearchTreeDemo
{
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public BinarySearchTreeNode<T> Left { get; set; }
        public BinarySearchTreeNode<T> Right { get; set; }

        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Root { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void InsertWithoutRecursion(T value)
        {
            var newNode = new BinarySearchTreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }
            // 45 , 15, 79, 90, 10, 55, 12, 20, 50
            var current = Root;

            while (current != null)
            {
                if (value.CompareTo(current.Value) > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        break;
                    }
                    else
                        current = current.Right;
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        break;
                    }
                    else
                        current = current.Left;
                }
            }
        }

        public void Insert(T value)
        {
            Root = Insert(Root, value);
        }

        private BinarySearchTreeNode<T> Insert(BinarySearchTreeNode<T> node, T value)
        {
            if (node == null)
                return new BinarySearchTreeNode<T>(value);

            else if (value.CompareTo(node.Value) < 0)
                node.Left = Insert(node.Left, value);

            else if (value.CompareTo(node.Value) > 0)
                node.Right = Insert(node.Right, value);

            return node;
        }


        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
            Console.WriteLine();
        }
        private void InOrderTraversal(BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PreOrderTraversal(BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
            Console.WriteLine();
        }
        private void LevelOrderTraversal(BinarySearchTreeNode<T> node)
        {
            if (node == null) return;
            var FirstNode = node;

            /*
             - Used when you want to travers Data Level By Level.
             - It is useful in structured layers or levels.

            
              Level by Level

             */

            Queue<BinarySearchTreeNode<T>> queue = new Queue<BinarySearchTreeNode<T>>();
            queue.Enqueue(node);


            while (queue.Count > 0)
            {
                var Vertex = queue.Dequeue();

                if (Vertex == FirstNode)
                    Console.Write(Vertex.Value);
                else
                    Console.Write(", " + Vertex.Value);

                if (Vertex.Left != null)
                {
                    queue.Enqueue(Vertex.Left);
                }
                if (Vertex.Right != null)
                {
                    queue.Enqueue(Vertex.Right);
                }

            }
        }

        public List<T> GetNodesAtLevel(int level)
        {
            List<T> result = new List<T>();
            if (Root == null || level < 0)
                return result;

            Queue<BinarySearchTreeNode<T>> nodeQueue = new Queue<BinarySearchTreeNode<T>>();
            Queue<int> levelQueue = new Queue<int>();

            nodeQueue.Enqueue(Root);
            levelQueue.Enqueue(0);

            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                var currentLevel = levelQueue.Dequeue();

                if (currentLevel == level)
                {
                    result.Add(currentNode.Value);
                }

                if (currentNode.Left != null)
                {
                    nodeQueue.Enqueue(currentNode.Left);
                    levelQueue.Enqueue(currentLevel + 1);
                }

                if (currentNode.Right != null)
                {
                    nodeQueue.Enqueue(currentNode.Right);
                    levelQueue.Enqueue(currentLevel + 1);
                }
            }

            return result;
        }
        public bool IsNodesExistAtLevel(int level, T value)
        {
            if (Root == null || level < 0)
                return false;

            Queue<BinarySearchTreeNode<T>> nodeQueue = new Queue<BinarySearchTreeNode<T>>();
            Queue<int> levelQueue = new Queue<int>();

            nodeQueue.Enqueue(Root);
            levelQueue.Enqueue(0);

            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                var currentLevel = levelQueue.Dequeue();

                if (currentLevel == level)
                {
                    if (Equals(currentNode.Value, value))
                        return true;
                }

                if (currentNode.Left != null)
                {
                    nodeQueue.Enqueue(currentNode.Left);
                    levelQueue.Enqueue(currentLevel + 1);
                }

                if (currentNode.Right != null)
                {
                    nodeQueue.Enqueue(currentNode.Right);
                    levelQueue.Enqueue(currentLevel + 1);
                }
            }

            return false;
        }
        // Print the tree visually
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }
        public bool Search(T value)
        {
            return Search(Root, value) != null;
        }

        private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> node, T value)
        {
            if (node == null || node.Value.Equals(value))
                return node;

            if (value.CompareTo(node.Value) < 0)
                return Search(node.Left, value);

            else
                return Search(node.Right, value);
        }

        // No Recursion
        public bool SearchUsingLoop(T value)
        {
            return SearchUsingLoops(Root, value) != null;
        }
        private BinarySearchTreeNode<T> SearchUsingLoops(BinarySearchTreeNode<T> node, T value)
        {
            while (node != null)
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value)) 
                    return node;

                if (node.Value.CompareTo(value) > 0)
                    node = node.Left;
                else
                    node = node.Right;
            }
            return null;
        }

        private void PrintTree(BinarySearchTreeNode<T> root, int space)
        {
            int COUNT = 10;  // Distance between levels
            if (root == null)
                return;

            space += COUNT;
            PrintTree(root.Right, space);

            Console.WriteLine();
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.WriteLine(root.Value);
            PrintTree(root.Left, space);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nInserting : 45, 15, 79, 90, 10, 55, 12, 20, 50\r\n");

            var bst = new BinarySearchTree<int>();

            // Using Recursion
            //bst.Insert(45);
            //bst.Insert(15);
            //bst.Insert(79);
            //bst.Insert(90);
            //bst.Insert(10);
            //bst.Insert(55);
            //bst.Insert(12);
            //bst.Insert(20);
            //bst.Insert(50);
            //bst.PrintTree();
            //Console.WriteLine();
            //Console.WriteLine();



            bst.InsertWithoutRecursion(45);
            bst.InsertWithoutRecursion(15);
            bst.InsertWithoutRecursion(79);
            bst.InsertWithoutRecursion(90);
            bst.InsertWithoutRecursion(10);
            bst.InsertWithoutRecursion(55);
            bst.InsertWithoutRecursion(12);
            bst.InsertWithoutRecursion(20);
            bst.InsertWithoutRecursion(50);
            bst.PrintTree();

            Console.WriteLine("\nDoes the BST contain 79? " + bst.Search(79)); // Expected: True
            Console.WriteLine("Does the BST contain 100? " + bst.Search(100)); // Expected: False

            Console.WriteLine("Does the BST contain 15? " + bst.SearchUsingLoop(15)); // Expected: True
            Console.WriteLine("Does the BST contain 3 ? " + bst.SearchUsingLoop(3)); //  Expected: false
            Console.WriteLine("Does the BST contain 3 ? " + bst.SearchUsingLoop(45)); // Expected: trure (Root)

            Console.WriteLine("\nInOrder Traversal:");
            bst.InOrderTraversal();

            Console.WriteLine("\nPreOrder Traversal:");
            bst.PreOrderTraversal();

            Console.WriteLine("\nPostOrder Traversal:");
            bst.PostOrderTraversal();

            Console.WriteLine("\nPostOrder Traversal:");
            bst.LevelOrderTraversal();

            Console.ReadKey();

        }
    }
}
