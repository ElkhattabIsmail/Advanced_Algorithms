using System;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace BinaryTreeImplementation
{
    public class BT_Node<T>
    {
        public T Value { get; set; }
        public BT_Node<T> Left { get; set; }
        public BT_Node<T> Right { get; set; }

        public BT_Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        public BT_Node<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            var newNode = new BT_Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BT_Node<T>> queue = new Queue<BT_Node<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }
        // Print the tree visually
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }
        private void PrintTree(BT_Node<T> root, int space)
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
        private void PreOrderTraversal(BT_Node<T> node)
        {
            /* 
             * => Useful tool for a wide range of applications, from tree copying to expression evaluation. 
             
              PreOrder Traversal visits the current node before its child nodes. 
              The process for PreOrder Traversal is as follows:

                 - Visit the current node.
                 - Recursively perform PreOrder Traversal of the left subtree.
                 - Recursively perform PreOrder Traversal of the right subtree.
            */


            // ROOT - LEFT SubTree - RIGHT SubTree


            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(BT_Node<T> node)
        {

            /*
             * 
             * Useful in scenarios where you need to visit child nodes before their parents, such as when
                calculating the size or depth of a tree, or when performing certain cleanup or evaluation
                tasks that require child nodes to be processed first.


              PostOrder Traversal visits the current node after its child nodes. 
              The process for PostOrder Traversal is:

                - Recursively perform PostOrder Traversal of the left subtree.
                - Recursively perform PostOrder Traversal of the right subtree.
                - Visit the current node.
           */


            // Left -> RIGHT -> ROOT


            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
            Console.WriteLine();
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
            Console.WriteLine();
        }

        private void InOrderTraversal(BT_Node<T> node)
        {

            /*
             * This method ensures that nodes are visited in ascending order for binary search trees,
             * making it particularly useful for operations like tree sorting and building sorted lists from trees.
             
            
              LEFT - ROOT - RIGHT

             */
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }
        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
            Console.WriteLine();
        }

        private void LevelOrderTraversal(BT_Node<T> node)
        {
            if (node == null) return;

            var FirstNode = node;

            /*
             - Used when you want to travers Data Level By Level.
             - It is useful in structured layers or levels.

            
              Level by Level

             */

            Queue<BT_Node<T>> queue = new Queue<BT_Node<T>>();
            queue.Enqueue(node);
            

            while (queue.Count > 0)
            {
                var Vertex = queue.Dequeue();

                if (Vertex == FirstNode )
                    Console.Write(Vertex.Value );
                else
                    Console.Write(", " + Vertex.Value );

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

            Queue<BT_Node<T>> nodeQueue = new Queue<BT_Node<T>>();
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
        public bool IsNodesExistAtLevel(int level ,T value)
        {
            if (Root == null || level < 0)
                return false;

            Queue<BT_Node<T>> nodeQueue = new Queue<BT_Node<T>>();
            Queue<int> levelQueue = new Queue<int>();

            nodeQueue.Enqueue(Root);
            levelQueue.Enqueue(0);

            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                var currentLevel = levelQueue.Dequeue();

                if (currentLevel == level)
                {
                    if (Equals( currentNode.Value,value ))
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");

            
            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);

            binaryTree.PrintTree();


            List<int> Nodes = binaryTree.GetNodesAtLevel(2);
            Console.WriteLine("\nAll Nodes In Level 2 Tree :\n");
            foreach (int node in Nodes)
            {
                Console.WriteLine(node + " ");
            }


            var isExist = binaryTree.IsNodesExistAtLevel(2, 9);
            Console.WriteLine($"\nIs 9 Exist In Level 2 Tree ?  {isExist}:\n");

            Console.WriteLine($"\nIs 3 Exist In Level 2 Tree ?  {binaryTree.IsNodesExistAtLevel(2, 3)}:\n");

            Console.WriteLine("\nLevelOrder Traversal (Level by Level):");
            binaryTree.LevelOrderTraversal();

            Console.WriteLine("\nPreOrder Traversal (Current-Left SubTree - Right SubTree):");
            binaryTree.PreOrderTraversal();

            Console.WriteLine("\nPostorder Traversal (Left SubTree - Right SubTree - Current):");
            binaryTree.PostOrderTraversal();


            Console.WriteLine("\nInorder Traversal: Left-Current-Right");
            binaryTree.InOrderTraversal();


            Console.ReadKey();

        }
    }
}
