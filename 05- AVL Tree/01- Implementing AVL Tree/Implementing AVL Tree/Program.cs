using System;
using System.Collections.Generic;
using System.Xml.Linq;

class AVLNode
{
    public int Value { get; set; }
    public AVLNode Left { get; set; }
    public AVLNode Right { get; set; }
    public int Height { get; set; }

    public AVLNode(int value)
    {
        Value = value;
        Height = 1; // Initially, when a node is created, its height is set to 1.
    }
}

class AVLTree
{
    private AVLNode Root;
    public void InsertIterative(int value)
    {
        Root = InsertIterative(Root, value);
    }

    private AVLNode InsertIterative(AVLNode root, int value)
    {
        AVLNode newNode = new AVLNode(value);
        Stack<AVLNode> stack = new Stack<AVLNode>();
        AVLNode current = root;

        // If tree is empty
        if (current == null)
            return newNode;

        // Standard BST insertion (iterative)
        while (true)
        {
            stack.Push(current);

            if (value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                current = current.Left;
            }
            else if (value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                current = current.Right;
            }
            else
                return root;
            // Duplicate value - no insertion needed
        }

        // Now we need to backtrack and update heights/balance
        while (stack.Count > 0)
        {
            current = stack.Pop();
            UpdateNodeHeight(current);

            // If we have parent in stack, we need to update its child pointer
            if (stack.Count > 0)
            {
                AVLNode parent = stack.Peek();

                if (parent.Left == current)
                    parent.Left = Balance(current);
                else
                    parent.Right = Balance(current);
            }
            else // This is the root node
                root = Balance(current);
        }
        return root;
    }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }
    private AVLNode Insert(AVLNode node, int value)
    {
        if (node == null)
            return new AVLNode(value);


        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else if (value > node.Value)
            node.Right = Insert(node.Right, value);
        else
            return node; // Duplicate values are not allowed

        UpdateNodeHeight(node);
        // return node;
        return Balance(node);
    }

    private void UpdateNodeHeight(AVLNode node)
    {
        //this will add 1 to the max height and update the node height.
        node.Height = 1 + Math.Max(GetNodeHeight(node.Left) , GetNodeHeight(node.Right));
    }

    private int GetNodeHeight(AVLNode node)
    {
        //this will get the height of the node, incase the node is null it will return 0.
        return node != null ? node.Height : 0;
    }

    private int GetBalanceFactor(AVLNode node)
    {
        return (node != null) ? GetNodeHeight(node.Left) - GetNodeHeight(node.Right) : 0;
    }

    private AVLNode Balance(AVLNode node)
    {
        
        //this function will balance the node.

        int balanceFactor = GetBalanceFactor(node);

        //decide which rotation to use and work accordengly.

        // RR - Right Rotation Case : Parent BF=-2 , Child BF for right child = -1 or 0
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
            return LeftRotate(node); // In Right Rotation Case We Use LeftRotate To maintaining the balance of the tree.

        // LL Case: Parent BF= +2 , Child BF for left child = +1 or 0
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
            return RightRotate(node);  // In left Rotation Case We Use LeftRotate To maintaining the balance of the tree.


        // LR - Left Rotation Case : Parent BF=+2 , Child BF for right child = -1 
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            //Step1: Perform left rotation
            node.Left = LeftRotate(node.Left);
            //Step2: Perfrom Rigth Rotation
            return RightRotate(node);
        }

        // RL - Right-Left Rotation Case : Parent BF=-2 , Child BF for right child = +1
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
        {
            //Step1: Perform right rotation
            node.Right = RightRotate(node.Right);
            //Step2: Perfrom Left Rotation
            return LeftRotate(node);
        }
        return node;
    }
    private AVLNode RightRotate(AVLNode OriginalRoot)
    {

        //Remember the algorithm
        // The left child of the node becomes the new Root of the subtree.
        // The original Root node becomes the right child of the new Root.
        // If the new Root already had a right child, it becomes the left child of the new right child(the original Root).


        // The left child of the node becomes the new Root of the subtree.
        AVLNode NewRoot = OriginalRoot.Left;

        //Save the Original Rigth Child Temperorly
        AVLNode OriginalRightChild = NewRoot.Right;


        //The original Root node becomes the right child of the new Root.
        NewRoot.Right = OriginalRoot;

        // The original Root node becomes the right child of the new Root.
        OriginalRoot.Left = OriginalRightChild;

        //After the rotation, the heights of the nodes may no longer be correct.
        //These two lines call a method UpdateNodeHeight for
        //both OriginalRoot and NewRoot to recalculate their heights based on the heights of their children.
        //This is crucial for maintaining the balance of the AVL tree.
        UpdateNodeHeight(OriginalRoot);
        UpdateNodeHeight(NewRoot);

        //Finally, the node NewRoot, which is now the Root of this subtree after the rotation, is returned.
        return NewRoot;
    }

    private AVLNode LeftRotate(AVLNode OriginalRoot)
    {

        //Remember the algorithm: go back to presentation.
        // The right child of the node becomes the new Root of the subtree.
        // The original Root node becomes the left child of the new Root.
        // If the new Root already had a left child, it becomes the right child of the new right child(the original Root).

        //Right child of the node becomes the new Root of the subtree
        AVLNode NewRoot = OriginalRoot.Right;
        //Save the Original Left Child Temperorly
        AVLNode OriginalLeftChild = NewRoot.Left;

        //Original Root node becomes the left child of the new Root.
        NewRoot.Left = OriginalRoot;
        
        //The new Root  left child,it becomes the right child of the new right child(the original Root)
        OriginalRoot.Right = OriginalLeftChild;

        //After the rotation, the heights of the nodes may no longer be correct.
        //These two lines call a method UpdateNodeHeight for
        //both OriginalRoot and NewRoot to recalculate their heights based on the heights of their children.
        //This is crucial for maintaining the balance of the AVL tree.
        UpdateNodeHeight(OriginalRoot);
        UpdateNodeHeight(NewRoot);

        //Finally, the node NewRoot, which is now the Root of this subtree after the rotation, is returned.
        return NewRoot;
    }

    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    private void PrintTree(AVLNode node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }
            Console.WriteLine(node.Value);
            PrintTree(node.Left, indent, false);
            PrintTree(node.Right, indent, true);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();

        //RR
        //int[] values = { 10, 20, 30 };

        //LL
        //int[] values = { 30, 20, 10 };

        //LR
        //int[] values = { 30, 10, 20 };

        //RL
        //int[] values = { 10, 30, 20 };

        // Inserting values
        //int[] values = { 10, 20, 30, 40, 50, 25 };

        // Inserting More values
        int[] values = { 3090, 18, 10, 20, 30, 40, 50, 25, 1, 56, 87, 101, 333, };

        foreach (var value in values)
        {
            if (value == 25)
                values[0] += 0;
            Console.WriteLine($"Inserting {value} into the AVL tree.");
            tree.Insert(value);
            tree.PrintTree();
            Console.WriteLine("\n-------------------------------------------------\n");
        }

        // Insert Method Iteratively.

        /*
        foreach (var value in values)
        {
            if (value == 50)
                values[0] += 0;

            Console.WriteLine($"Inserting {value} into the AVL tree.");
            tree.InsertIterative(value);
            tree.PrintTree();
            Console.WriteLine("\n-------------------------------------------------\n");
        }  
        */

        Console.ReadKey();  

    }
}
