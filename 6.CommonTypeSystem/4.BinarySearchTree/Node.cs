using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.BinarySearchTree
{
    public class Node<T> : IComparable<Node<T>>
        where T: IComparable<T>
    {
        private T value;
        private Node<T> parentNode;
        private Node<T> leftChildNode;
        private Node<T> rightChildNode;

        public Node(T value, Node<T> parentNode = null, Node<T> leftChildNode = null, Node<T> rightChildNode = null)
        {
            this.value = value;
            this.parentNode = parentNode;
            this.leftChildNode = leftChildNode;
            this.rightChildNode = rightChildNode;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Node<T> ParentNode
        {
            get { return this.parentNode; }
            set { this.parentNode = value; }
        }

        public Node<T> LeftChildNode
        {
            get { return this.leftChildNode; }
            set { this.leftChildNode = value; }
        }

        public Node<T> RightChildNode
        {
            get { return this.rightChildNode; }
            set { this.rightChildNode = value; }
        }



        public int CompareTo(Node<T> other)
        {
            return this.value.CompareTo(other.value);
        }

        public override bool Equals(object obj)
        {
            Node<T> newNode = obj as Node<T>;
            if (newNode == null)
            {
                return false;
            }
            return this.CompareTo(newNode) == 0;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode() ^ this.leftChildNode.GetHashCode();
        }
    }
}
