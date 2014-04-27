using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Windows;

namespace SimuTraining.util
{
    public class BreadCrumb
    {
        private BreadCrumb() { }

        private static Node root = null;
        private static XmlDocument xml = new XmlDocument();

        public static Node getRoot()
        {
            if (root == null)
            {
                xml.Load("conf/Directory.xml");
                getDirectory();
            }

            return root;
        }

        private static void getDirectory()
        {
            XmlElement element = xml.DocumentElement;
            root = new Node();

            root.Name = "首页";
            root.Parent = null;
            root.Leaf = false;
            root.Description = null;
            root.Filelocation = null;

            //addChildren(root, element);
        }

        private static void addChildren(Node node, XmlNode item)
        {
            node.Name = item.Attributes["name"].Value.ToString();
            String level = item.Attributes["level"].Value.ToString();
            node.Level = Convert.ToInt32(item.Attributes["level"].Value.ToString());
            node.Leaf = item.Attributes["leaf"].Value.ToString().Equals("true");

            node.Description = ConfigurationManager.AppSettings[node.Name + "description"].ToString();
            if (node.Leaf)
            {
                node.Filelocation = ConfigurationManager.AppSettings[node.Name + "file"].ToString();
            }

            XmlNodeList list = item.ChildNodes;
            foreach (XmlNode child in list)
            {
                Node childNode = new Node();
                childNode.Parent = node;
                addChildren(childNode, child);
            }

        }

    }

    public class Node
    {
        private String name;
        private String description;
        private String filelocation;
        private int level;
        private Boolean leaf;
        private Node parent;
        private List<Node> children;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Filelocation
        {
            get { return filelocation; }
            set { filelocation = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public Boolean Leaf
        {
            get { return leaf; }
            set { leaf = value; }
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }

        public Node() { }


    }
}
