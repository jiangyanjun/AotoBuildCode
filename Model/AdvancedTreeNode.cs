using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Model
{
    public class AdvancedTreeNode: TreeNode
    {
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
