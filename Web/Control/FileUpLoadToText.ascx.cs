using System;
using System.Collections.Generic;
using YouHoo.DataTools;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.Web;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using System.Data;

namespace YouHoo.Web.Control
{
    public partial class FileUpLoadToText : BaseControl
    {
        /// <summary>
        /// ·��
        /// </summary>
        public string Text
        {
            set { txtFileName.Text = value; }
            get { return txtFileName.Text; }
        }

        /// <summary>
        /// �ļ�URL
        /// </summary>
        public string FileUrl
        {
            get
            {
                if (FileType == FileTypeEnum.Image)
                {
                    return String.IsNullOrEmpty(Text) ? "" : "<a href=\"" + Text + "\" target=\"_blank\"><img src=\"" + Converts.SmallImageFilePath(Text, "x_") + "\" /></a><a href=\"javascript:void(0)\" title=\"ɾ��\" class=\"delete_file\" onclick=\"deleteUploadImg(this)\"></a>";
                }
                else
                {
                    return String.IsNullOrEmpty(Text) ? "" : "<a href=\"" + Text + "\" target=\"_blank\">" + Text + "<a href=\"javascript:void(0)\" title=\"ɾ��\" class=\"delete_file\" onclick=\"deleteUploadImg(this)\"></a>";
                }
            }
        }

        /// <summary>
        /// �ļ�����
        /// </summary>
        public FileTypeEnum FileType
        {
            get { return (FileTypeEnum)ViewState["FileType"]; }
            set { ViewState["FileType"] = value; }
        }

        /// <summary>
        /// �Ƿ��ѡ
        /// </summary>
        public bool Required
        {
            set
            {
                if (value == true) divupload.Attributes["class"] = "upload-box box single-upload validate[required]";
            }
        }

        /// <summary>
        /// �Ƿ���Ҫˮӡ
        /// </summary>
        private bool isWaterMark = true;
        public bool IsWaterMark
        {
            get { return isWaterMark; }
            set { isWaterMark = value; }
        }

        /// <summary>
        /// ����ͼ���ã���ʽ����50|50,100|100,150|150����һ������ͼ���|��һ������ͼ�߶�,�ڶ�������ͼ���|�ڶ�������ͼ�߶�
        /// </summary>
        private string thumbnailConfig;
        public string ThumbnailConfig
        {
            get { return thumbnailConfig; }
            set { thumbnailConfig = value; }
        }
    }

    public enum FileTypeEnum
    {
        Image = 0,
        File = 1
    }
}