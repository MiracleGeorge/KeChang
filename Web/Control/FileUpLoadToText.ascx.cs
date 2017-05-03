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
        /// 路径
        /// </summary>
        public string Text
        {
            set { txtFileName.Text = value; }
            get { return txtFileName.Text; }
        }

        /// <summary>
        /// 文件URL
        /// </summary>
        public string FileUrl
        {
            get
            {
                if (FileType == FileTypeEnum.Image)
                {
                    return String.IsNullOrEmpty(Text) ? "" : "<a href=\"" + Text + "\" target=\"_blank\"><img src=\"" + Converts.SmallImageFilePath(Text, "x_") + "\" /></a><a href=\"javascript:void(0)\" title=\"删除\" class=\"delete_file\" onclick=\"deleteUploadImg(this)\"></a>";
                }
                else
                {
                    return String.IsNullOrEmpty(Text) ? "" : "<a href=\"" + Text + "\" target=\"_blank\">" + Text + "<a href=\"javascript:void(0)\" title=\"删除\" class=\"delete_file\" onclick=\"deleteUploadImg(this)\"></a>";
                }
            }
        }

        /// <summary>
        /// 文件类型
        /// </summary>
        public FileTypeEnum FileType
        {
            get { return (FileTypeEnum)ViewState["FileType"]; }
            set { ViewState["FileType"] = value; }
        }

        /// <summary>
        /// 是否必选
        /// </summary>
        public bool Required
        {
            set
            {
                if (value == true) divupload.Attributes["class"] = "upload-box box single-upload validate[required]";
            }
        }

        /// <summary>
        /// 是否需要水印
        /// </summary>
        private bool isWaterMark = true;
        public bool IsWaterMark
        {
            get { return isWaterMark; }
            set { isWaterMark = value; }
        }

        /// <summary>
        /// 缩略图配置，格式：（50|50,100|100,150|150）第一个缩略图宽度|第一个缩略图高度,第二个缩略图宽度|第二个缩略图高度
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