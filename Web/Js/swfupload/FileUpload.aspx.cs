using System;
using System.Configuration;
using System.IO;
using System.Web;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;
using YouHoo.Web;

namespace YouHoo.Web.Control
{
    public partial class FileUpload : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            switch (DataConvert.ToInt32(DataRequest.QueryString("handler")))
            {
                case PublicParameters.OnePram: ImageUpLoad(); break;
                case PublicParameters.TwoPram: ImagesUpLoad(); break;
                case PublicParameters.ThreePram: DeleteImage(); break;
                case PublicParameters.FourPram: setFocusImg(); break;
            }
        }

        #region 单个文件上传
        /// <summary>
        /// 单个文件上传
        /// </summary>
        private void ImageUpLoad()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["Filedata"];//上传的文件数据
            int fileSize = file.ContentLength;//获得文件大小，以字节为单位
            if (file != null)
            {
                string path = UploadImage(file, DataRequest.QueryInt("FileType"), true, DataRequest.QueryInt("IsWater"), DataRequest.QueryString("thumbnailConfig"));
                HttpContext.Current.Response.Write("{\"status\":1, \"msg\":\"上传文件成功！\", \"fileType\":\"" + DataRequest.QueryInt("FileType") + "\", \"name\":\"" + file.FileName + "\", \"path\":\"" + path + "\", thumb:\"" + Converts.SmallImageFilePath(path, "x_") + "\", \"size\":" + fileSize + ", \"ext\":\"" + Converts.SubFileExt(file.FileName) + "\"}");
            }
            else
            {
                HttpContext.Current.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
            }
        }
        #endregion

        #region 多个文件上传
        /// <summary>
        /// 多个文件上传
        /// </summary>
        private void ImagesUpLoad()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["Filedata"];//上传的文件数据
            int fileSize = file.ContentLength; //获得文件大小，以字节为单位
            if (file != null)
            {
                string path = UploadImage(file, DataRequest.QueryInt("FileType"), false, 1, DataRequest.QueryString("thumbnailConfig"));
                YouhooSysFilesModel data = new YouhooSysFilesModel();
                data.TableId = DataConvert.ToInt32(DataRequest.QueryString("TableId"));
                data.TableFileId = DataConvert.ToInt32(DataRequest.QueryString("TableFileId"));
                data.FilePath = path;
                data.FileName = file.FileName;
                data.FileSize = FileHelper.ComputeSize(file.ContentLength);
                string returnInfo = "";
                int errorCode = new YouhooSysFilesBLL().InsertUpdate(data, 0);
                DatabasePrompt.GetPromptInfo(errorCode, "上传文件", out returnInfo, this);
                HttpContext.Current.Response.Write("{\"status\":\"" + errorCode + "\", \"msg\":\"" + returnInfo + "\", \"fileType\":\"" + DataRequest.QueryInt("FileType") + "\", \"fileid\":\"" + data.FileId + "\", \"name\":\"" + data.FileName + "\", \"path\":\"" + data.FilePath + "\",\"thumb\":\"" + Converts.SmallImageFilePath(path, "x_") + "\", \"size\":\"" + data.FileSize + "\", \"ext\":\"" + Converts.SubFileExt(data.FileName) + "\"}");
            }
            else
            {
                HttpContext.Current.Response.Write("{\"status\": \"0\", \"msg\": \"请选择要上传文件！\"}");
            }
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        protected void DeleteImage()
        {
            int returnvalue = new YouhooSysFilesBLL().Delete(DataRequest.QueryString("fileid"), 0);
            switch (returnvalue)
            {
                case -99: HttpContext.Current.Response.Write("error"); break;
                case -1: HttpContext.Current.Response.Write("error"); break;
                default: HttpContext.Current.Response.Write("ok"); break;
            }
        }
        #endregion

        #region 设置封面
        /// <summary>
        /// 设置封面
        /// </summary>
        protected void setFocusImg()
        {
            YouhooSysFilesModel data = new YouhooSysFilesBLL().GetModel(DataConvert.ToInt32(DataRequest.QueryString("fileid")));
            data.Remark = "1";
            int returnvalue = new YouhooSysFilesBLL().InsertUpdate(data, 0);
            switch (returnvalue)
            {
                case -99: HttpContext.Current.Response.Write("error"); break;
                case -1: HttpContext.Current.Response.Write("error"); break;
                default: HttpContext.Current.Response.Write("ok"); break;
            }
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="IsThumbnail"></param>
        /// <param name="ThumbnailWidth"></param>
        /// <param name="ThumbnailHeight"></param>
        /// <returns></returns>
        protected string UploadImage(HttpPostedFile file, int fileType, bool isSingle, int isWateRmark, string thumbnailConfig)
        {
            string filePath = "";
            //检查上传文件不为空
            if (file != null)
            {
                //取得文件名(抱括路径)里最后一个"."的索引
                int intExt = file.FileName.LastIndexOf(".");
                //取得文件扩展名(包括".")
                string strExt = file.FileName.Substring(intExt);
                //生成随机文件名 
                string saveName = Converts.ToDateTime(DateTime.Now, "ddHHmmss") + new Random().Next(1111, 9999) + strExt;
                //保存地址
                string uploadPath = "/UploadFiles/" + Converts.ToDateTime(DateTime.Now, "yyyy") + "/" + Converts.ToDateTime(DateTime.Now, "MM") + "/";
                string savePath = Server.MapPath(uploadPath);
                //判断是否存在该地址
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);//若不存在则新建地址
                }
                filePath = uploadPath + saveName;
                if (fileType == 0)
                {
                    //水印图片
                    string wateRmarkImage = "";
                    //水印位置
                    int wateRmarkPosition = 7;
                    //图片最小宽度
                    int wateRmarkWidth = 0;
                    //图片最小高度
                    int wateRmarkHeight = 0;
                    //水印边距-左右
                    int wateRmarkLeftRight = 0;
                    //水印边距-上下
                    int wateRmarkUpDown = 0;
                    ImageHelper.WaterMark(file.InputStream, Server.MapPath(filePath), wateRmarkImage, wateRmarkPosition.ToString(), wateRmarkWidth, wateRmarkHeight, wateRmarkLeftRight, wateRmarkUpDown);
                    //单个文件
                    if (isSingle)
                    {
                        //生成缩略图
                        ImageHelper.CutForCustom(file.InputStream, Server.MapPath(Converts.SmallImageFilePath(filePath, "x_")), 40, 30, 20, "", wateRmarkImage, wateRmarkPosition.ToString(), wateRmarkLeftRight, wateRmarkUpDown);
                    }
                    //多个文件
                    else
                    {
                        //生成缩略图
                        ImageHelper.CutForCustom(file.InputStream, Server.MapPath(Converts.SmallImageFilePath(filePath, "x_")), 20, 20, 20, "", wateRmarkImage, wateRmarkPosition.ToString(), wateRmarkLeftRight, wateRmarkUpDown);
                        //生成缩略图
                        ImageHelper.CutForCustom(file.InputStream, Server.MapPath(Converts.SmallImageFilePath(filePath, "60x60_")), 60, 60, 20, "", wateRmarkImage, wateRmarkPosition.ToString(), wateRmarkLeftRight, wateRmarkUpDown);
                    }
                    if (!string.IsNullOrEmpty(thumbnailConfig))
                    {
                        string[] thumbnailRow = thumbnailConfig.Split(',');
                        for (int i = 0; i < thumbnailRow.Length; i++)
                        {
                            string[] thumbnailColumn = thumbnailRow[i].Split('|');
                            int thumbnailWidth = DataConvert.ToInt32(thumbnailColumn[0]);
                            int thumbnailHeight = DataConvert.ToInt32(thumbnailColumn[1]);
                            ImageHelper.CutForCustom(file.InputStream, Server.MapPath(Converts.SmallImageFilePath(filePath, thumbnailWidth + "x" + thumbnailHeight + "_")), thumbnailWidth, thumbnailHeight, 20, "", wateRmarkImage, wateRmarkPosition.ToString(), wateRmarkLeftRight, wateRmarkUpDown);
                        }
                    }
                }
                else
                {
                    file.SaveAs(savePath + saveName);
                }
            }
            return filePath;
        }
        #endregion
    }
}