
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alex75.JsonViewer.BusinessObjects;
using Newtonsoft.Json.Linq;

namespace Alex75.JsonViewer.WindowsForm
{
    public class JsonTreeNode : TreeNode
    {        
        public NodeType NodeType { get; set; }

        public string TextWhenSelected {
            get {
                return textWhenSelected;
            }
        }

        public bool IsExpandable {
            get {
                return NodeType == NodeType.Object || NodeType == NodeType.Array;
            }
        }

        public JsonTreeNode(NodeType nodeType, string text, string textWhenSelected = null)
        {
            NodeType = nodeType;
            Text = text;
            this.textWhenSelected = textWhenSelected ?? text;            
        }

        private string textWhenSelected;
    }
}
