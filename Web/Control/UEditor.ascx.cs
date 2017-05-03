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
        /// ���
        /// </summary>
        public Unit Width
        {
            get { return txt_editor.Width; }
            set { txt_editor.Width = value; }
        }

        /// <summary>
        /// �߶�
        /// </summary>
        public Unit Height
        {
            get { return txt_editor.Height; }
            set { txt_editor.Height = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Text
        {
            get { return txt_editor.Text; }
            set { txt_editor.Text = value; }
        }
    }
}