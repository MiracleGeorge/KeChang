using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;

namespace YouHoo.Web.Control
{
    public partial class FileUpload : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rmsg = "{msg:'未定义操作',flag:'0'}";
                string action = DataRequest.FormString("act").ToLower();
                switch (action)
                {
                    case "uploadfile":
                        rmsg = UploadFile();
                        break;
                    case "deletefile":
                        rmsg = DeleteFile();
                        break;
                    default:
                        break;
                }
                Response.Write(rmsg);
                Response.End();
            }
        }

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        protected string UploadFile()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            HttpPostedFile file = HttpContext.Current.Request.Files[0];//上传的文件数据
            int fileSize = file.ContentLength;//获得文件大小，以字节为单位
            if (file != null)
            {
                string filePath = "";
                //取得文件名(抱括路径)里最后一个"."的索引
                int intExt = file.FileName.LastIndexOf(".");
                //取得文件扩展名(包括".")
                string strExt = file.FileName.Substring(intExt);
                //生成随机文件名 
                string saveName = Converts.ToDateTime(DateTime.Now, "ddHHmmss") + new Random().Next(1111, 9999) + strExt;
                //保存地址
                string uploadPath = "/UploadFiles/file/" + Converts.ToDateTime(DateTime.Now, "yyyy") + "/" + Converts.ToDateTime(DateTime.Now, "MM") + "/";
                string savePath = Server.MapPath(uploadPath);
                //判断是否存在该地址
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);//若不存在则新建地址
                }
                filePath = uploadPath + saveName;
                file.SaveAs(savePath + saveName);

                //保存文件信息
                YouhooSysFilesModel model = new YouhooSysFilesModel();
                model.TableId = DataRequest.FormInt("tableId");
                model.TableFileId = DataRequest.FormInt("tableFileId");
                model.FileName = file.FileName;
                model.FilePath = filePath;
                model.FileSize = FileHelper.ComputeSize(file.ContentLength);
                string returnInfo = "";
                int errorCode = new YouhooSysFilesBLL().InsertUpdate(model, 0);
                DatabasePrompt.GetPromptInfo(errorCode, "上传文件", out returnInfo, this);
                rmsg = "{msg:'" + returnInfo + "','fileId':'" + model.FileId + "',fileName:'" + model.FileName + "',filePath:'" + model.FilePath + "',flag:'" + errorCode + "'}";
            }
            else
            {
                rmsg = "{msg:'请选择要上传的文件！',flag:'0'}";
            }
            return rmsg;
        } 
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        protected string DeleteFile()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取文件ID
            int fileId = DataRequest.FormInt("fileId");
            string returnInfo = "";
            int errorCode = new YouhooSysFilesBLL().Delete(fileId.ToString(), 0);
            DatabasePrompt.GetPromptInfo(errorCode, "删除", out returnInfo, this);
            rmsg = "{msg:'" + returnInfo + "',flag:'" + errorCode + "'}";
            return rmsg;
        } 
        #endregion
    }
}