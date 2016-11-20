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
using System.Resources;
using System.Collections;

namespace Alex75.JsonViewer.WindowsForm
{
    [Browsable(false)]
    [DesignTimeVisible(false)]
    [Designer("JSON Tree View")]
    public class JsonTreeView : TreeView
    {
        private const string IMAGE_KEY_ARRAY_ITEM = "Array item";

        public JsonTreeView()
        {
            LoadImgaeList();
        }

        private void LoadImgaeList()
        {
            //System.Resources.arra
            ImageList treeImages = new ImageList();
            treeImages.ImageSize = new Size(16, 16);
            ComponentResourceManager resources = new ComponentResourceManager(GetType());
            foreach (var type in Enum.GetNames(typeof(NodeType)))
            {
                try
                {
                    treeImages.Images.Add(type, (Bitmap)resources.GetObject(type));
                }
                catch (Exception)
                { }
            }

            treeImages.Images.Add(IMAGE_KEY_ARRAY_ITEM, (Bitmap)resources.GetObject(IMAGE_KEY_ARRAY_ITEM));


            //resources.GetObject("array");

            //string resxFile = @".\" + GetType().Name + ".resx";
            //using (ResXResourceReader resxReader = new ResXResourceReader(resxFile))
            //{
            //    foreach (DictionaryEntry entry in resxReader)
            //    {
            //        if (((string)entry.Key) == (NodeType.Array.ToString()))
            //            treeImages.Images.Add(NodeType.Array.ToString(), (Bitmap)entry.Value);                    
            //    }
            //}

            this.ImageList = treeImages;
        }

        public void ShowJson(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            LoadTree(json);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                    text = CreateNodeDisplayText(property, value);
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
                    text = CreateNodeDisplayText(property, value);
                    break;
            }

            node = new JsonTreeNode(type, text);
            node.ImageKey = type.ToString();
            node.SelectedImageKey = node.ImageKey;
            parentNode.Nodes.Add(node);

            // item of Array
            if (property == null)
            {
                node.ImageKey = IMAGE_KEY_ARRAY_ITEM;
                node.SelectedImageKey = node.ImageKey;
            }

            if (item.Type == JTokenType.Array)
            {
                LoadArray(item, node);
            }

            if (item.Type == JTokenType.Object)
            {
                LoadObject(item as JObject, node);
            }
        }

        private string CreateNodeDisplayText(string property, string value)
        {
            return property == null ? value : string.Format($"{property}: {value}");
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
