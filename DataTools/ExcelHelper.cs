using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Data.OleDb;

namespace YouHoo.DataTools
{
    public class ExcelHelper
    {
        #region 上传Excel/Csv并转换成DataTable
        /// <summary>
        /// 上传Excel/Csv并转换成DataTable
        /// </summary>
        /// <param name="fu_fileUpload">上传控件</param>
        /// <param name="format">格式（xls/csv）</param>
        /// <param name="dt"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool UploadExcel(FileUpload fu_fileUpload, string format, out DataTable dt, Page page)
        {
            dt = new DataTable();
            if (fu_fileUpload.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {
                PublicPrompt.Alert("请选择" + format + "文件！", page);
                return false;//当无文件时,返回
            }
            string extension = System.IO.Path.GetExtension(fu_fileUpload.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (extension != "." + format)
            {
                PublicPrompt.Alert("只可以选择" + format + "文件！", page);
                return false;//当选择的不是Excel文件时,返回
            }
            if (format == "xls")
            {
                dt = GetDataFromExcel(fu_fileUpload, page);
            }
            else
            {
                dt = GetDataFromCsv(fu_fileUpload);
            }
            if (dt.Rows.Count == 0)
            {
                PublicPrompt.Alert(format + "无数据！", page);
                return false;
            }
            return true;
        }
        #endregion

        #region 读取Excel转换成DataTable
        /// <summary>
        /// 将Excel转换成DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataFromExcel(FileUpload fu_fileUpload, Page page)
        {
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + fu_fileUpload.FileName;     //获取Execle文件名  DateTime日期函数
            string directory = page.Server.MapPath("/UploadFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month);
            string savePath = directory + "/" + filename;                              //Server.MapPath 获得虚拟服务器相对路径
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            fu_fileUpload.SaveAs(savePath);                                                         //SaveAs 将上传的文件内容保存在服务器上

            string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + savePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            odda.Fill(ds, filename);
            return ds.Tables[0];
        }
        #endregion

        #region 读取Csv文件返回DataTable
        /// <summary>
        /// 读取Csv文件返回DataTable
        /// 使用流方式
        /// </summary>
        /// <param name="fileload"></param>
        /// <returns></returns>
        public static DataTable GetDataFromCsv(FileUpload fu_fileUpload)
        {
            DataTable dt = new DataTable();

            StreamReader sr = new StreamReader(fu_fileUpload.PostedFile.InputStream, Encoding.Default);

            string strTitle = sr.ReadLine();

            string[] strColumTitle = strTitle.Split(','); //CVS 文件默认以逗号隔开
            for (int i = 0; i < strColumTitle.Length; i++)
            {
                dt.Columns.Add(strColumTitle[i]);
            }

            while (!sr.EndOfStream)
            {
                string strTest = sr.ReadLine();
                string[] strTestAttribute = strTest.Split(',');

                DataRow dr = dt.NewRow();
                for (int i = 0; i < strColumTitle.Length; i++)
                {
                    dr[strColumTitle[i]] = StrAttribute(strTestAttribute, i, String.Empty);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private static string StrAttribute(string[] strTestAttribute, int iLen, string isDefaule)
        {
            try
            {
                return strTestAttribute[iLen];
            }
            catch
            {
                return isDefaule;
            }
        }
        #endregion

        #region 导出DataTable成Excel
        /// <summary>
        /// 导出DataTable成Excel
        /// </summary>
        /// <param name="context">context对象</param>
        /// <param name="dt">需要导出的DataTable</param>
        /// <param name="columnName">列集合（列之间以‘,’分隔，列名与列代码之间用‘|’分隔）如：（联系人|linkman,联系电话|phone）</param>
        public static void ExportDataTable(HttpContext context, DataTable dt, string columnName)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");
            NPOI.SS.UserModel.ICellStyle cs = book.CreateCellStyle();
            cs.WrapText = true;
            float maxHeight = 0;

            //获取列集合
            string[] columnName_array = columnName.Split(',');

            //生成列名
            NPOI.SS.UserModel.IRow row_columnName = sheet.CreateRow(0);
            for (int c = 0; c < columnName_array.Length; c++)
            {
                row_columnName.CreateCell(c).SetCellValue(columnName_array[c].Split('|')[0]);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //创建行
                NPOI.SS.UserModel.IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < columnName_array.Length; j++)
                {
                    //创建列
                    row.CreateCell(j).SetCellValue(dt.Rows[i][columnName_array[j].Split('|')[1]].ToString());
                    row.GetCell(j).CellStyle = cs;
                    float curHeight = dt.Rows[i][columnName_array[j].Split('|')[1]].ToString().Replace("\r\n", "|").Split('|').Length * 12.75f;
                    if (curHeight > maxHeight)
                        maxHeight = curHeight;
                }
                row.HeightInPoints = maxHeight;
            }

            // 写入到客户端
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            context.Response.BinaryWrite(ms.ToArray());
            book = null;
            ms.Close();
            ms.Dispose();
        }
        #endregion
    }
}
