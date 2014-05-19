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

            addChildren(root, element, 0);
        }

        private static void addChildren(Node node, XmlNode item, int index)
        {
            node.Name = item.Attributes["name"].Value.ToString();
            String level = item.Attributes["level"].Value.ToString();
            node.Level = Convert.ToInt32(item.Attributes["level"].Value.ToString());

            if (node.Level == 1)
            {
                if (node.Name.Equals("组织指挥"))
                {
                    node.ImageName = "org";
                }
                else if (node.Name.Equals("基本技术"))
                {
                    node.ImageName = "basic";
                }
                else if (node.Name.Equals("技能应用"))
                {
                    node.ImageName = "comp";
                }
                else
                {
                    node.ImageName = "emerg";
                }
            }
            else if (node.Level > 1)
            {
                node.ImageName = node.Parent.ImageName + "_" + index;
            }
            
            node.Leaf = item.Attributes["leaf"].Value.ToString().Equals("true");

            if (ConfigHolder.getInfo().ContainsKey(node.Name + ".d"))
            {
                String des = ConfigHolder.getInfo()[node.Name + ".d"];
                if (!des.StartsWith("        "))
                    node.Description = "        " + des;
            }
            else
            {
                node.Description = "";
            }

            if (ConfigHolder.getInfo().ContainsKey(node.Name + ".dd"))
            {
                String des = ConfigHolder.getInfo()[node.Name + ".dd"];
                node.ExceptionDescription = des;
            }
            else
            {
                node.ExceptionDescription = "";
            }

            if (node.Leaf && ConfigHolder.getInfo().ContainsKey(node.Name + ".f"))
            {
                node.Filelocation = "media/" + ConfigHolder.getInfo()[node.Name + ".f"];
            }
            else
            {
                node.Filelocation = "";
            }

            XmlNodeList list = item.ChildNodes;

            for (int i = 1; i <= list.Count; ++i)
            {
                Node childNode = new Node();
                childNode.Parent = node;
                node.Children.Add(childNode);
                addChildren(childNode, list[i-1], i);
            }

        }

        private static String paragraph(String input)
        {
            String result = "";

            if (!input.StartsWith("        "))
                result = "        " + input;

            if (result.Length > 60)
            { 
                
            }

            return result;
        }
    }

    public class Node
    {
        private String name;
        private String description;
        private String exceptionDescription;
        private String imageName;
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

        public String ExceptionDescription
        {
            get { return exceptionDescription; }
            set { exceptionDescription = value; }
        }

        public String ImageName
        {
            get { return imageName; }
            set { imageName = value; }
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

        public Node() 
        {
            children = new List<Node>();
        }


    }
}
