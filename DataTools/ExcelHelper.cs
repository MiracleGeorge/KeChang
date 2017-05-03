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
        #region �ϴ�Excel/Csv��ת����DataTable
        /// <summary>
        /// �ϴ�Excel/Csv��ת����DataTable
        /// </summary>
        /// <param name="fu_fileUpload">�ϴ��ؼ�</param>
        /// <param name="format">��ʽ��xls/csv��</param>
        /// <param name="dt"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool UploadExcel(FileUpload fu_fileUpload, string format, out DataTable dt, Page page)
        {
            dt = new DataTable();
            if (fu_fileUpload.HasFile == false)//HasFile�������FileUpload�Ƿ���ָ���ļ�
            {
                PublicPrompt.Alert("��ѡ��" + format + "�ļ���", page);
                return false;//�����ļ�ʱ,����
            }
            string extension = System.IO.Path.GetExtension(fu_fileUpload.FileName).ToString().ToLower();//System.IO.Path.GetExtension����ļ�����չ��
            if (extension != "." + format)
            {
                PublicPrompt.Alert("ֻ����ѡ��" + format + "�ļ���", page);
                return false;//��ѡ��Ĳ���Excel�ļ�ʱ,����
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
                PublicPrompt.Alert(format + "�����ݣ�", page);
                return false;
            }
            return true;
        }
        #endregion

        #region ��ȡExcelת����DataTable
        /// <summary>
        /// ��Excelת����DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataFromExcel(FileUpload fu_fileUpload, Page page)
        {
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + fu_fileUpload.FileName;     //��ȡExecle�ļ���  DateTime���ں���
            string directory = page.Server.MapPath("/UploadFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month);
            string savePath = directory + "/" + filename;                              //Server.MapPath ���������������·��
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            fu_fileUpload.SaveAs(savePath);                                                         //SaveAs ���ϴ����ļ����ݱ����ڷ�������

            string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + savePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            odda.Fill(ds, filename);
            return ds.Tables[0];
        }
        #endregion

        #region ��ȡCsv�ļ�����DataTable
        /// <summary>
        /// ��ȡCsv�ļ�����DataTable
        /// ʹ������ʽ
        /// </summary>
        /// <param name="fileload"></param>
        /// <returns></returns>
        public static DataTable GetDataFromCsv(FileUpload fu_fileUpload)
        {
            DataTable dt = new DataTable();

            StreamReader sr = new StreamReader(fu_fileUpload.PostedFile.InputStream, Encoding.Default);

            string strTitle = sr.ReadLine();

            string[] strColumTitle = strTitle.Split(','); //CVS �ļ�Ĭ���Զ��Ÿ���
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

        #region ����DataTable��Excel
        /// <summary>
        /// ����DataTable��Excel
        /// </summary>
        /// <param name="context">context����</param>
        /// <param name="dt">��Ҫ������DataTable</param>
        /// <param name="columnName">�м��ϣ���֮���ԡ�,���ָ����������д���֮���á�|���ָ����磺����ϵ��|linkman,��ϵ�绰|phone��</param>
        public static void ExportDataTable(HttpContext context, DataTable dt, string columnName)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");
            NPOI.SS.UserModel.ICellStyle cs = book.CreateCellStyle();
            cs.WrapText = true;
            float maxHeight = 0;

            //��ȡ�м���
            string[] columnName_array = columnName.Split(',');

            //��������
            NPOI.SS.UserModel.IRow row_columnName = sheet.CreateRow(0);
            for (int c = 0; c < columnName_array.Length; c++)
            {
                row_columnName.CreateCell(c).SetCellValue(columnName_array[c].Split('|')[0]);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //������
                NPOI.SS.UserModel.IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < columnName_array.Length; j++)
                {
                    //������
                    row.CreateCell(j).SetCellValue(dt.Rows[i][columnName_array[j].Split('|')[1]].ToString());
                    row.GetCell(j).CellStyle = cs;
                    float curHeight = dt.Rows[i][columnName_array[j].Split('|')[1]].ToString().Replace("\r\n", "|").Split('|').Length * 12.75f;
                    if (curHeight > maxHeight)
                        maxHeight = curHeight;
                }
                row.HeightInPoints = maxHeight;
            }

            // д�뵽�ͻ���
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
