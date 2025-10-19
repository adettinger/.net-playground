using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Reflection.Metadata;

namespace GenericBinaryTree
{
    class GenericBinaryNode<T>
    {
        public GenericBinaryNode<T>? Parent { get; set; }
        public GenericBinaryNode<T>? RightChild { get; set; }
        public GenericBinaryNode<T>? LeftChild { get; set; }

        public T Value { get; set; }

        public GenericBinaryNode(T value)
        {
            this.Value = value;
        }

        public bool IsRoot()
        {
            return Parent == null;
        }

        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("");
                indent += "| ";
            }
            Console.WriteLine(Value);

            var children = new List<GenericBinaryNode<T>>();
            if (this.LeftChild != null)
                children.Add(this.LeftChild);
            if (this.RightChild != null)
                children.Add(this.RightChild);

            for (int i = 0; i < children.Count; i++)
                children[i].PrintPretty(indent, i == children.Count - 1);

        }
    }

    class GenericBinaryTree<T>
    {
        GenericBinaryNode<T>? Root { get; set; }

        public GenericBinaryTree(GenericBinaryNode<T>? root) 
        {
            this.Root = root;
        }
        public void DisplayTree()
        {
            //Display tree in BFS to cmd line
            Root?.PrintPretty("", true);
        }
    }
}