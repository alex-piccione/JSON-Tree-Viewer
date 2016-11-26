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
        private ContextMenuStrip treeContextMenu;
        private IContainer components;
        private ToolStripMenuItem expandAllMenuItem;
        private StatusStrip statusStrip1;
        private string previouslySelectedNodeText = null;

        public JsonTreeView()
        {
            InitializeComponent();
            this.AfterSelect += this_AfterSelect;
            this.MouseDown += this_MouseDown;
            expandAllMenuItem.Click += expandAllMenuItem_Click;

            LoadImgaeList();
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.treeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllMenuItem});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(147, 30);
            this.treeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.treeContextMenu_Opening);
            // 
            // expandAllMenuItem
            // 
            this.expandAllMenuItem.Name = "expandAllMenuItem";
            this.expandAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.expandAllMenuItem.ShowShortcutKeys = false;
            this.expandAllMenuItem.Size = new System.Drawing.Size(146, 26);
            this.expandAllMenuItem.Text = "&Expand All";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(200, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // JsonTreeView
            // 
            this.ContextMenuStrip = this.treeContextMenu;
            this.FullRowSelect = true;
            this.treeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private new JsonTreeNode SelectedNode
        {
            get { return base.SelectedNode as JsonTreeNode; }
            set { base.SelectedNode = value; ; }
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

        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = GetNodeAt(e.Location);
                if (node != null)
                {
                    base.SelectedNode = node;
                }
            }
        }

        private void treeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            expandAllMenuItem.Visible = SelectedNode.IsExpandable;
            expandAllMenuItem.Enabled = SelectedNode.Nodes.Count > 0;
        }

        private void expandAllMenuItem_Click(object sender, EventArgs e)
        {   
            if (SelectedNode != null)
            {
                BeginUpdate();
                SelectedNode.ExpandAll();
                EndUpdate();
            }       
        }

        #endregion
    }
}
