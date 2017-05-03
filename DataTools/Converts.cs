using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace YouHoo.DataTools
{
    /// <summary>
    /// ת�������ࣨ��ֹת��ʧ�ܱ���
    /// </summary>
    public class Converts
    {
        public static string GetTreeParentId(DataTable dt, string superior, string parent_id_name, string id_name)
        {
            string str = "";

            DataRow[] rows = dt.Select(id_name + "='" + superior + "'");
            foreach (DataRow row in rows)
            {
                if (row[parent_id_name].ToString() == "0")
                    str = superior;
                else
                    str = GetTreeParentId(dt, row[parent_id_name].ToString(), parent_id_name, id_name);
            }
            return str;
        }

        public static string GetTreeChildId(DataTable dt, string superior, string parent_id_name, string id_column)
        {
            string str = superior + ",";
            DataRow[] rows = dt.Select(parent_id_name + "='" + superior + "'");
            foreach (DataRow row in rows)
            {
                str += GetTreeChildId(dt, row[id_column].ToString(), parent_id_name, id_column);
                str += row[id_column] + ",";
            }
            return str;
        }



        #region ָ���ַ�������
        /// <summary>
        /// �жϾ������Ƿ�������
        /// </summary>
        /// <param >�ַ���</param>
        public static bool IsChinese(string words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string TmmP = words.Substring(i, 1);
                byte[] sarr = Encoding.GetEncoding("gb2312").GetBytes(TmmP);
                if (sarr.Length == 2)
                {
                    return true;
                }
                sarr = Encoding.GetEncoding("utf-8").GetBytes(TmmP);
                if (sarr.Length == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static string StrLength(string str)
        {
            return StrLength(str, 13);
        }

        public static string StrLength(string str, int length)
        {
            if (IsChinese(str))
                return MutiSubString(str, length, "...");
            else
                return EngSubString(str, length, "...");
        }

        public static string StrLength(string str, int length, string aStrEnd)
        {
            if (IsChinese(str))
                return MutiSubString(str, length, aStrEnd);
            else
                return EngSubString(str, length, aStrEnd);
        }

        /// <summary>
        /// �õ�ָ�����ȣ����ֵ�2���ַ�����
        /// </summary>
        /// <param name="aOrgStr"></param>
        /// <param name="aLength"></param>
        /// <param name="aStrEnd">�����ַ�</param>
        /// <returns></returns>
        private static string MutiSubString(String aOrgStr, int aLength, string aStrEnd)
        {
            int intLen = aOrgStr.Length;
            int start = 0;
            int end = intLen;
            int single = 0;
            char[] chars = aOrgStr.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Convert.ToInt32(chars[i]) > 255)
                {
                    start += 2;
                }
                else
                {
                    start += 1;
                    single++;
                }
                if (start >= aLength)
                {
                    if (end % 2 == 0)
                    {
                        if (single % 2 == 0)
                        {
                            end = i + 1;
                        }
                        else
                        {
                            end = i;
                        }
                    }
                    else
                    {
                        end = i + 1;
                    }
                    break;
                }
            }
            //������صĳ��ȴ��ڽ�ȡ����
            if (intLen > end)
                return aOrgStr.Substring(0, end) + aStrEnd;
            else
                return aOrgStr;
        }

        /// <summary>
        /// �õ�ָ�����ȣ����ֵ�2���ַ�����
        /// </summary>
        /// <param name="aOrgStr"></param>
        /// <param name="aLength"></param>
        /// <param name="aStrEnd"></param>
        /// <returns></returns>
        private static string EngSubString(String aOrgStr, int aLength, string aStrEnd)
        {
            if (aOrgStr.Length > aLength)
            {
                if (aOrgStr.Split(' ').Length > 1)
                {
                    int inum = 0;
                    string str = "";
                    foreach (string s in aOrgStr.Split(' '))
                    {
                        //���жϼ��ֶε�����
                        inum += s.Length + 1;
                        if (inum > aLength)
                        {
                            break;
                        }
                        else
                        {
                            str += s + " ";
                        }
                    }
                    return str + aStrEnd;
                }
                else
                    return aOrgStr.Substring(0, aLength) + aStrEnd;
            }
            else
                return aOrgStr;
        }

        #endregion

        /// <summary>
        /// �ж��ַ����������Ƿ���values
        /// </summary>
        /// <param name="str">�ַ�������</param>
        /// <param name="split">�ָ��ֽ�</param>
        /// <param name="values">�ж��ַ�</param>
        /// <returns></returns>
        public static bool StrIndexOf(string str, string values)
        {
            return StrIndexOf(str, new char[] { ',', ';', '|' }, values);

        }
        public static bool StrIndexOf(string str, char split, string values)
        {
            return StrIndexOf(str, new char[] { split }, values);
        }
        /// <summary>
        /// �ж��ַ����������Ƿ���values
        /// </summary>
        /// <param name="str">�ַ�������</param>
        /// <param name="split">�ָ��ֽ�</param>
        /// <param name="values">�ж��ַ�</param>
        /// <returns></returns>
        public static bool StrIndexOf(string str, char[] split, string values)
        {
            if (String.IsNullOrEmpty(str)) return false;
            foreach (string s in str.Split(split, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s == values) return true;
            }
            return false;
        }

        /// <summary>
        /// �õ��ļ�����չ��
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string SubFileExt(string strName)
        {
            return SubFileExt(strName, '.');
        }

        /// <summary>
        /// �õ��ļ�����չ��
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SubFileExt(string strName, char str)
        {
            //ȡ���ļ���(����·��)�����һ��"."������
            int intExt = strName.LastIndexOf(str);
            //ȡ���ļ���չ��
            if (intExt != -1)
                return strName.Substring(intExt).Trim(str);
            else
                return strName;
        }

        /// <summary>
        /// �õ������ַ���֮�������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">��ʼ</param>
        /// <param name="end">����</param>
        /// <returns></returns>
        public static string SubString(string str, string start, string end)
        {
            return SubString(str, start, end, true);
        }

        /// <summary>
        /// �õ������ַ���֮�������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">��ʼ</param>
        /// <param name="end">����</param>
        /// <param name="isEmpty">���Ϊtrue �򷵻ؿ�</param>
        /// <returns></returns>
        public static string SubString(string str, string start, string end, bool isEmpty)
        {
            if (String.IsNullOrEmpty(str)) return str;
            int istart = str.IndexOf(start);
            if (istart == -1) return isEmpty ? String.Empty : str;
            istart += start.Length;
            int iend = str.IndexOf(end, istart);
            if (iend == -1) return isEmpty ? String.Empty : str;
            str = str.Substring(istart, iend - istart);
            return str;
        }
        /// <summary>
        /// md5������
        /// </summary>
        /// <param name="swhere"></param>
        /// <returns></returns>
        public static string MD5(string swhere)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(swhere, "md5");
        }
        /// <summary>
        /// ��ͼƬ����ǰ����һ���ַ����õ�����ͼ�ĵ�ַ
        /// </summary>
        /// <param name="imagefile"></param>
        /// <param name="smallstring"></param>
        /// <returns></returns>
        public static string SmallImageFilePath(string imagefile, string smallstring)
        {
            string stem = "";
            if (!string.IsNullOrEmpty(imagefile))
            {
                string[] str = imagefile.Split('/');
                for (int i = 0; i < str.Length; i++)
                {
                    //���һ��
                    if (str.Length != 0 && i == str.Length - 1)
                    {
                        stem += smallstring + str[i];
                    }
                    else
                    {
                        stem += str[i] + "/";
                    }
                }
            }
            return stem;
        }

        /// <summary>
        /// ��ͼƬ����ǰ����һ���ַ����õ�����ͼ�ĵ�ַ
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="smallString"></param>
        /// <param name="isnotpic"></param>
        /// <returns></returns>
        public static string SmallImageFilePath(string imageFile, string smallString, string isnotpic)
        {
            return !String.IsNullOrEmpty(imageFile) && File.Exists(HttpContext.Current.Server.MapPath(SmallImageFilePath(imageFile, smallString)))
                    ? SmallImageFilePath(imageFile, smallString)
                    : isnotpic;
        }

        /// <summary>
        /// �õ��ؼ�����ֵ
        /// </summary>
        /// <param name="control">�ؼ�</param>
        /// <returns></returns>
        public static string GetControlsValue(Control control)
        {
            string str = "";
            if (control is CheckBoxList)
            {
                CheckBoxList chk = control as CheckBoxList;
                for (int i = 0; i < chk.Items.Count; i++)
                {
                    if (chk.Items[i].Selected)
                    {
                        str += chk.Items[i].Value + ",";
                    }
                }
            }
            else if (control is RadioButtonList)
            {
                RadioButtonList chk = control as RadioButtonList;
                if (chk.SelectedItem != null)
                    str = chk.SelectedValue;
            }
            else if (control is DropDownList)
            {
                DropDownList chk = control as DropDownList;
                if (chk.SelectedItem != null)
                    str = chk.SelectedValue;
            }
            if (str != "") str = str.Trim(',');
            return str;
        }


        public static string SetControlsData(Control control, DataTable dt, string column_text, string column_value, bool isdefault, string default_text)
        {
            string str = "";
            if (control is CheckBoxList)
            {
                CheckBoxList chk = control as CheckBoxList;
                chk.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    chk.Items.Add(new ListItem(row[column_text].ToString(), row[column_value].ToString()));
                }
                if (isdefault)
                {
                    chk.Items.Insert(0, new ListItem(default_text, "0"));
                }
            }
            else if (control is RadioButtonList)
            {
                RadioButtonList chk = control as RadioButtonList;
                chk.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    chk.Items.Add(new ListItem(row[column_text].ToString(), row[column_value].ToString()));
                }
                if (isdefault)
                {
                    chk.Items.Insert(0, new ListItem(default_text, "0"));
                }
            }
            else if (control is DropDownList)
            {
                DropDownList dropDownList = control as DropDownList;
                dropDownList.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dropDownList.Items.Add(new ListItem(row[column_text].ToString(), row[column_value].ToString()));
                }
                if (isdefault)
                {
                    dropDownList.Items.Insert(0, new ListItem(default_text, ""));
                }
            }
            return str;
        }

        /// <summary>
        /// ���ÿؼ���ֵ
        /// </summary>
        /// <param name="control">�ؼ�</param>
        /// <param name="values">ֵ</param>
        /// <returns></returns>
        public static string SetControlsValue(Control control, string values)
        {
            string str = "";
            if (control is CheckBoxList)
            {
                CheckBoxList chk = control as CheckBoxList;
                foreach (string s in values.Split(new char[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach (ListItem item in chk.Items)
                    {
                        if (item.Value == s)
                            item.Selected = true;
                    }
                }
            }
            else if (control is RadioButtonList)
            {

                RadioButtonList radioButtonList = control as RadioButtonList;
                if (radioButtonList.SelectedItem != null)
                {
                    radioButtonList.SelectedItem.Selected = false;
                }
                // ��ֵ��
                ListItem listItem = radioButtonList.Items.FindByValue(values);
                if (listItem == null)
                {
                    // ����ʾ���ı���
                    foreach (ListItem item in radioButtonList.Items)
                    {
                        if (item.Text.Equals(values))
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    // ����Ϊ��ѡ��״̬
                    listItem.Selected = true;
                }
            }
            else if (control is DropDownList)
            {
                DropDownList dropDownList = control as DropDownList;
                if (dropDownList.SelectedItem != null)
                {
                    dropDownList.SelectedItem.Selected = false;
                }
                // ��ֵ��
                ListItem listItem = dropDownList.Items.FindByValue(values);
                if (listItem == null)
                {

                    foreach (ListItem item in dropDownList.Items)
                    {
                        if (item.Text.Equals(values))
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    // ����Ϊ��ѡ��״̬
                    listItem.Selected = true;
                }
            }
            return str;
        }

        /// <summary>
        /// �����ַ������Զ���ѡCheckBoxList��Ӧ��
        /// </summary>
        /// <param name="checkBoxList">CheckBoxList�ؼ�</param>
        /// <param name="str">�ַ�������ʽҪ��Ϊ��A,B,C��</param>
        public static void SetCheckBoxListData(CheckBoxList checkBoxList, string str)
        {
            string[] items = str.Split(',');
            //����items
            foreach (string item in items)
            {
                //���ֵ��ȣ���ѡ�и���
                foreach (ListItem listItem in checkBoxList.Items)
                {
                    if (item == listItem.Value)
                        listItem.Selected = true;
                    else
                        continue;
                }
            }
        }

        /// <summary>
        /// ����CheckBoxList��ѡ�е������ַ���
        /// </summary>
        /// <param name="checkBoxList">CheckBoxList�ؼ�</param>
        /// <returns>�ַ�������ʽΪ��A,B,C��</returns>
        public static string GetCheckBoxListValue(CheckBoxList checkBoxList)
        {
            string str = "";
            foreach (ListItem li in checkBoxList.Items)
            {
                if (li.Selected) str += li.Value + ",";
            }
            return str.TrimEnd(',');
        }

        /// <summary>
        /// ת��Ϊʱ���ʽΪyyyy-MM-dd
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static string ToDate(object obj)
        {
            return ToDateTime(obj, "yyyy-MM-dd");
        }

        /// <summary>
        /// ת��Ϊʱ���ʽΪyyyy-MM-dd HH:mm;ss
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static string ToDateTime(object obj)
        {
            return ToDateTime(obj, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// ת��Ϊʱ�����ͣ���ʽ�Զ��壩
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <param name="format">�Զ����ʽ</param>
        /// <returns></returns>
        public static string ToDateTime(object obj, string format)
        {
            try
            {
                return Convert.ToDateTime(obj).ToString(format);
            }
            catch
            {
                return String.Empty;//ת��ʧ�ܷ��ؿն��󣬷�ֹ����
            }
        }

        /// <summary>
        /// ת��Ϊint����
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static int ToInt32(object obj)
        {
            return ToInt32(obj, 0);
        }
        /// <summary>
        /// ת��Ϊint����
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static int ToInt32(object obj, int reutndefault)
        {
            try
            {
                //���Ϊ0���򷵻�Ĭ��ֵ
                if (Convert.ToInt32(obj) == 0)
                    return reutndefault;
                return Convert.ToInt32(obj);
            }
            catch
            {
                return reutndefault;
            }
        }

        /// <summary>
        /// ת��Ϊdecimal����
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static Decimal ToDecimal(object obj)
        {
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return 0;//ת��ʧ�ܷ���0����ֹ����
            }
        }

        /// <summary>
        /// ת��Ϊbool����
        /// </summary>
        /// <param name="obj">��ת������</param>
        /// <returns></returns>
        public static bool ToBool(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return false;//ת��ʧ�ܷ���false����ֹ����
            }
        }

        /// <summary>
        /// �滻SQL����ȫ�ַ�
        /// </summary>
        /// <param name="s">��ת������</param>
        /// <returns></returns>
        public static string ToSafeString(string s)
        {
            if (s != null)
            {
                StringBuilder str = new StringBuilder(s);
                str = str.Replace("'", "��");
                //str = str.Replace("&", "&amp;");
                return str.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="obdata">Ҫ��ȡ�Ķ���</param>
        /// <param name="obLength">��ȡ�ĳ���</param>
        /// <returns>��ȡ���ֵ</returns>
        public static string GetLength(object obdata, int obLength)
        {

            if (obdata.ToString().Length > obLength)
            {

                return obdata.ToString().Substring(0, obLength) + "...";
            }
            else
            {
                return obdata.ToString();
            }
        }

        public static DataTable ConvertControlTree(DataTable dt, string column_name, string column_id, string parent_column_id, string value)
        {
            if (dt.Rows.Count == 0) return new DataTable();
            DataTable dtree = new DataTable();
            dtree.Columns.Add(column_id);
            dtree.Columns.Add(column_name);
            int irow = 0;
            _Tree(dt, column_name, column_id, parent_column_id, value, ref dtree, ref irow);
            return dtree;
        }

        private static void _Tree(DataTable dt, string column_name, string column_id, string parent_column_id, string value, ref DataTable dtree, ref int irow)
        {
            DataRow[] dr = dt.Select("" + parent_column_id + "='" + value + "'");
            if (dr.Length != 0)
            {
                foreach (DataRow o in dr)
                {
                    DataRow row = dtree.NewRow();
                    row[column_id] = o[column_id];
                    if (irow == 0)
                    {
                        row[column_name] = o[column_name];
                    }
                    else
                    {
                        row[column_name] = "�� " + _Symbol(irow - 1, "�� ") + o[column_name];
                    }
                    dtree.Rows.Add(row);
                    irow++;
                    _Tree(dt, column_name, column_id, parent_column_id, o[column_id].ToString(), ref dtree, ref  irow);
                    irow--;
                }
            }
        }


        public static DataTable ConvertTableTree(DataTable dt, string column_name, string column_id, string parent_column_id, string value)
        {
            DataTable dtree = new DataTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    dtree.Columns.Add(c.ColumnName);
                }
                int irow = 0;
                _TableTree(dt, column_name, column_id, parent_column_id, value, ref dtree, ref irow);
            }
            return dtree;
        }

        private static void _TableTree(DataTable dt, string column_name, string column_id, string parent_column_id, string value, ref DataTable dtree, ref int irow)
        {
            DataRow[] dr = dt.Select("" + parent_column_id + "='" + value + "'");
            if (dr.Length != 0)
            {
                foreach (DataRow o in dr)
                {
                    DataRow row = dtree.NewRow();
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (c.ColumnName == column_name)
                        {
                            if (irow == 0)
                            {
                                row[column_name] = o[column_name];
                            }
                            else
                            {
                                row[column_name] = "�� " + _Symbol(irow - 1, "�� ") + o[column_name];
                            }
                        }
                        else
                            row[c.ColumnName] = o[c.ColumnName];
                    }

                    dtree.Rows.Add(row);
                    irow++;
                    _TableTree(dt, column_name, column_id, parent_column_id, o[column_id].ToString(), ref dtree, ref  irow);
                    irow--;
                }
            }
        }

        private static string _Symbol(int inum, string value)
        {
            string str = "";
            for (int i = 0; i < inum; i++)
            {
                str += value;
            }
            return str;
        }

        public static string StringSplit(string str, char c, int index)
        {
            try
            {
                return str.Split(new char[] { c }, StringSplitOptions.RemoveEmptyEntries)[index];
            }
            catch
            {
                return String.Empty;
            }
        }
        public static string StringSplit(string str, string c, int index)
        {
            try
            {
                return str.Split(new string[] { c }, StringSplitOptions.RemoveEmptyEntries)[index];
            }
            catch
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// �ж�index�Ƿ������str��
        /// </summary>
        /// <param name="str">�ܵ��ַ���</param>
        /// <param name="c">�ָ���</param>
        /// <param name="index">Ҫ�����жϵ��ַ���</param>
        /// <returns></returns>
        public static bool IsStringSplit(string str, char c, string index)
        {
            foreach (string s in str.Split(new char[] { c }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s == index) return true;
            }
            return false;
        }

        #region �ļ��Ƿ����
        public static bool IsFileExists(string filename)
        {
            try
            {
                return File.Exists(HttpContext.Current.Request.MapPath(filename));
            }
            catch
            {
                return false;
            }
        }

        #endregion


        /// <summary>
        /// ���ֻ���תhtml����
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string StrToEnter(string txt)
        {
            string dst = txt;
            dst = dst.Replace("\\r\\n", "<br>");
            dst = dst.Replace("\\r", "<br>");
            dst = dst.Replace("\\n", "<br>");
            dst = dst.Replace("\r\n", "<br>");
            dst = dst.Replace("\r", "<br>");
            dst = dst.Replace("\n", "<br>");
            return dst;
        }



        # region dataTableת����Json��ʽ
        /// <summary>  
        /// DataTable ���� ת��ΪJson �ַ���  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string ConvertDataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //ȡ�������ֵ  
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //ʵ����һ����������  
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList��������Ӽ�ֵ  
            }
            return javaScriptSerializer.Serialize(arrayList);  //����һ��json�ַ���  
        }

        /// <summary>  
        /// Json �ַ��� ת��Ϊ DataTable���ݼ���  
        /// </summary>  
        /// <param name="json"></param>  
        /// <returns></returns>  
        public static DataTable ConvertJsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //ʵ����  
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //ȡ�������ֵ  
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count == 0)
                        {
                            result = dataTable;
                            return result;
                        }

                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }

                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        dataTable.Rows.Add(dataRow); //ѭ������е�DataTable��  
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }

        #endregion

    }




    #region ����
    public class PublicParameters
    {
        /// <summary>
        /// ������
        /// </summary>
        public const int ZeroPram = 0;
        /// <summary>
        /// ����һ
        /// </summary>
        public const int OnePram = 1;
        /// <summary>
        /// ������
        /// </summary>
        public const int TwoPram = 2;
        /// <summary>
        /// ������
        /// </summary>
        public const int ThreePram = 3;
        /// <summary>
        /// ������
        /// </summary>
        public const int FourPram = 4;
        /// <summary>
        /// ������
        /// </summary>
        public const int FivePram = 5;
        /// <summary>
        /// ������
        /// </summary>
        public const int SixPram = 6;

        /// <summary>
        /// ������
        /// </summary>
        public const int SevenPram = 7;
        /// <summary>
        /// ������
        /// </summary>
        public const int EightPram = 8;
        /// <summary>
        /// ������
        /// </summary>
        public const int NinePram = 9;
        /// <summary>
        /// ����ʮ
        /// </summary>
        public const int TenPram = 10;

        /// <summary>
        /// ����ʮһ
        /// </summary>
        public const int ElevenPram = 11;
        /// <summary>
        /// ����ʮ��
        /// </summary>
        public const int TwelvePram = 12;
        /// <summary>
        /// ����ʮ��
        /// </summary>
        public const int ThirteenPram = 13;
    }
    #endregion




}
