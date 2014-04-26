using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimuTraining.util
{
    public class BreadCrumb
    {
        private static Node root = null;

        private BreadCrumb() { }

        public static Node getRoot()
        {
            if (root == null)
            {
                root = new Node();
                root.Name = "首页";
                root.Parent = null;

                // get all children
            }
            return root;
        }
    }

    public class Node
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Node parent;
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private List<Node> children;
        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }

        public Node() { }

        public Node(String name, Node parent, List<Node> children) 
        {
            this.name = name;
            this.parent = parent;
            this.children = children;
        }
    }
}
