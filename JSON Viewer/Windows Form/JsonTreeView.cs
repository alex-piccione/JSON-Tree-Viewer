using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Alex75.JsonViewer.BusinessObjects;

namespace Alex75.JsonViewer.WindowsForm
{
    public class JsonTreeView : TreeView
    {
        public void ShowJson(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);

            LoadTree(json);
        }

        private void LoadTree(JObject json)
        {
            Nodes.Clear();            

            var rootNode = new JsonTreeNode(NodeType.Object, "(root)");
            Nodes.Add(rootNode);
            SelectedNode = rootNode;

            rootNode.ImageKey = rootNode.NodeType.ToString();
            rootNode.SelectedImageKey = rootNode.ImageKey;

            foreach (var child in json)
            {
                AddNode(rootNode, child.Key, child.Value);
            }

            rootNode.Expand();
        }

        private void AddNode(JsonTreeNode parentNode, string property, JToken item)
        {
            JsonTreeNode node;
            NodeType type;
            string text;
            string value;
            switch (item.Type)
            {
                case JTokenType.String:
                    type = NodeType.Value;
                    value = item.ToString();
                    text = string.Format($"{property}: {value}");
                    break;
                case JTokenType.Array:
                    type = NodeType.Array;
                    text = property;
                    break;
                case JTokenType.Object:
                    type = NodeType.Object;
                    text = property;
                    break;
                default:
                    type = NodeType.Value;
                    value = item.Type.ToString();
                    text = string.Format($"{property}: {value}");
                    break;
            }

            node = new JsonTreeNode(type, text);
            node.ImageKey = type.ToString();
            node.SelectedImageKey = node.ImageKey;
            parentNode.Nodes.Add(node);

            if (item.Type == JTokenType.Array)
            {
                LoadArray(item, node);
            }

            if (item.Type == JTokenType.Object)
            {
                LoadObject(item as JObject, node);
            }
        }

        private void LoadArray(JToken value, JsonTreeNode node)
        {
            foreach (var item in value)
            {
                AddNode(node, null, item);
            }
        }

        private void LoadObject(JObject obj, JsonTreeNode node)
        {
            foreach (var item in obj)
            {
                AddNode(node, item.Key, item.Value);
            }
        }

    }
}
