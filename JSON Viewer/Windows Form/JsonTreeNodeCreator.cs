using Alex75.JsonViewer.BusinessObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex75.JsonViewer.WindowsForm
{
    internal class JsonTreeNodeCreator
    {

        internal static JsonTreeNode CreateNode(string property, JToken item)
        {
            NodeType type;
            string text;
            string textWhenSelected = null;

            if (item.Type == JTokenType.Object || item.Type == JTokenType.Array)
            {
                text = property;
                textWhenSelected = text;
            }
            else
            {
                type = NodeType.Value;
                string value = item.ToString();
                text = property == null ? 
                    value : 
                    string.Format($"{property}: {value}");
                textWhenSelected = string.Format($"{text} (type: {item.Type})");
            }

            type = item.Type == JTokenType.Object ? NodeType.Object :
                item.Type == JTokenType.Array ? NodeType.Array :
                NodeType.Value;
            
            var node = new JsonTreeNode(type, text, textWhenSelected);
            node.ImageKey = item.Type.ToString();
            node.SelectedImageKey = node.ImageKey;

            return node;
        }
    }
}
