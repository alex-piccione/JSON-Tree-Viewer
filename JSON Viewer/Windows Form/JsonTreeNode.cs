
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alex75.JsonViewer.BusinessObjects;

namespace Alex75.JsonViewer.WindowsForm
{
    public class JsonTreeNode : TreeNode
    {        
        public NodeType NodeType { get; set; }

        public JsonTreeNode(NodeType nodeType, string text)
        {
            NodeType = nodeType;
            Text = text;
        }
    }
}
