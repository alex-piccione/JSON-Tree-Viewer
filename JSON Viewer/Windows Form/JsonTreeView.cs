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
        private TreeNode previouslySelectedNode = null;
        private string previouslySelectedNodeText = null;

        public JsonTreeView()
        {
            LoadImgaeList();
            this.AfterSelect += this_AfterSelect;
        }

        private void LoadImgaeList()
        {
            ImageList treeImages = new ImageList();
            treeImages.ImageSize = new Size(16, 16);
            ComponentResourceManager images = new ComponentResourceManager(typeof(Resources.NodeImages));
            foreach (var type in Enum.GetNames(typeof(JTokenType)))
            {
                try
                {
                    treeImages.Images.Add(type, (Bitmap)images.GetObject(type));
                }
                catch (Exception)
                {
                    treeImages.Images.Add(type, (Bitmap)images.GetObject("Undefined"));
                }
            }

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

            LoadObject(json, rootNode);

            rootNode.Expand();
        }

        private void AddNode(JsonTreeNode parentNode, string property, JToken item)
        {
            var node = JsonTreeNodeCreator.CreateNode(property, item);
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

        #region UI events

        private void this_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // restore previous seelcted node text and store the next
            if (previouslySelectedNode != null)
            {
                previouslySelectedNode.Text = previouslySelectedNodeText;
            }
            previouslySelectedNode = e.Node;
            previouslySelectedNodeText = e.Node.Text;

            e.Node.Text = ((JsonTreeNode)e.Node).TextWhenSelected;
        }

        #endregion
    }
}
