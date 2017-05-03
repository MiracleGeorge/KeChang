using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouHoo.Web.Control
{
    public partial class UEditor : BaseControl
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public Unit Width
        {
            get { return txt_editor.Width; }
            set { txt_editor.Width = value; }
        }

        /// <summary>
        /// 高度
        /// </summary>
        public Unit Height
        {
            get { return txt_editor.Height; }
            set { txt_editor.Height = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Text
        {
            get { return txt_editor.Text; }
            set { txt_editor.Text = value; }
        }
    }
}