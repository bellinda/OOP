using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _4.BinarySearchTree
{
    public struct BinarySearchTree<T> : IComparable<BinarySearchTree<T>>, ICloneable, IEnumerable<T>
        where T: IComparable<T>
    {
        private Node<T> root;

        public BinarySearchTree(Node<T> root = null)
        {
            this.root = root;
        }

        public Node<T> Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public Node<T> Insert(T value, Node<T> parentNode, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new Node<T>(value);
                currentNode.ParentNode = parentNode;
            }
            else
            {
                int compared = value.CompareTo(currentNode.Value);
                if (compared < 0)
                {
                    currentNode.LeftChildNode = Insert(value, currentNode, currentNode.LeftChildNode);
                }
                else if (compared > 0)
                {
                    currentNode.RightChildNode = Insert(value, currentNode, currentNode.RightChildNode);
                }
            }
            return currentNode;
        }

        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("I can't insert a nullable value in your tree");
            }
            this.root = Insert(value, null, root);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (root.ParentNode != null)
            {
                builder.Append(root.ParentNode.Value + " ");
            }
            AppendNodes(ref builder, this.root);
            return builder.ToString();
        }

        private void AppendNodes(ref StringBuilder builder, Node<T> root)
        {
            if (root == null) return;

            AppendNodes(ref builder, root.LeftChildNode);
            builder.Append(root.Value);
            builder.Append(" ");
            AppendNodes(ref builder, root.RightChildNode);
        }

        public Node<T> Find(T value)
        {
            Node<T> node = this.root;
            while (node != null)
            {
                int compared = value.CompareTo(node.Value);
                if (compared < 0)
                {
                    node = node.LeftChildNode;
                }
                else if (compared > 0)
                {
                    node = node.RightChildNode;
                }
                else
                    break;
            }
            return node;
        }

        public void Remove(T value)
        {
            Node<T> mustBeDeleted = Find(value);
            if (mustBeDeleted == null)
            {
                return;
            }
            Remove(mustBeDeleted);
        }

        public void Remove(Node<T> node)
        {
            //the node has two child nodes
            if (node.LeftChildNode != null && node.RightChildNode != null)
            {
                Node<T> replace = node.RightChildNode;
                while (replace.LeftChildNode != null)
                {
                    replace = replace.LeftChildNode;
                }
                node.Value = replace.Value;
                node = replace;
            }
            //the node has one or zero child nodes
            Node<T> child = node.LeftChildNode != null ? node.LeftChildNode : node.RightChildNode;
            if (child != null)
            {
                child.ParentNode = node.ParentNode;
                if (node.ParentNode == null)
                {
                    root = child;
                }
                else
                {
                    if (node.ParentNode.LeftChildNode == node)
                    {
                        node.ParentNode.LeftChildNode = child;
                    }
                    else
                    {
                        node.ParentNode.RightChildNode = child;
                    }
                }
            }
            else
            {
                if (node.ParentNode == null)
                {
                    root = null;
                }
                else
                {
                    if (node.ParentNode.LeftChildNode == node)
                    {
                        node.ParentNode.LeftChildNode = null;
                    }
                    else
                    {
                        node.ParentNode.RightChildNode = null;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            //BinarySearchTree<T> newTree = obj as BinarySearchTree<T>;
            BinarySearchTree<T> newTree = (BinarySearchTree<T>)obj;
            if (newTree == null)
            {
                return false;
            }
            return this.CompareTo(newTree) == 0;
        }

        public int CompareTo(BinarySearchTree<T> other)
        {
            return this.Root.Value.CompareTo(other.Root.Value);
        }

        public override int GetHashCode()
        {
            return this.Root.GetHashCode() ^ 17;  //to be an unique number
        }

        public static bool operator ==(BinarySearchTree<T> first, BinarySearchTree<T> second)
        {
            return BinarySearchTree<T>.Equals(first, second);
        }

        public static bool operator !=(BinarySearchTree<T> first, BinarySearchTree<T> second)
        {
            return !BinarySearchTree<T>.Equals(first, second);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public BinarySearchTree<T> Clone()
        {
            BinarySearchTree<T> original = this;
            BinarySearchTree<T> cloned = new BinarySearchTree<T>();
            PreorderTreeWalk(original.root, x => cloned.Insert(x.Value));
            return cloned;
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<Node<T>> values = new List<Node<T>>();
            PreorderTreeWalk(this.root, x => values.Add(x));
            foreach (Node<T> value in values)
            {
                yield return value.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private void PreorderTreeWalk(Node<T> node, Action<Node<T>> action)
        {
            if (node != null)
            {
                action(node);
                PreorderTreeWalk(node.LeftChildNode, action);
                PreorderTreeWalk(node.RightChildNode, action);
            }
        }

        //private List<Node<T>> GetNodes(Node<T> node)  //, ref List<Node<T>> nodes
        //{
        //    List<Node<T>> list = new List<Node<T>>();
        //    list.Add(node);
        //    if (node.LeftChildNode != null)
        //    {
        //        GetNodes(node.LeftChildNode);
        //        list.Add(node.LeftChildNode);
        //    }
        //    if (node.RightChildNode != null)
        //    {
        //        GetNodes(node.RightChildNode);
        //        list.Add(node.RightChildNode);
        //    }
        //    return list;
            
        //}
    }
}
