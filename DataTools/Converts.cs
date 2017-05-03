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
    /// 转换类型类（防止转换失败报错）
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



        #region 指定字符串长度
        /// <summary>
        /// 判断句子中是否含有中文
        /// </summary>
        /// <param >字符串</param>
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
        /// 得到指定长度，汉字当2个字符计算
        /// </summary>
        /// <param name="aOrgStr"></param>
        /// <param name="aLength"></param>
        /// <param name="aStrEnd">结束字符</param>
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
            //如果返回的长度大于截取长度
            if (intLen > end)
                return aOrgStr.Substring(0, end) + aStrEnd;
            else
                return aOrgStr;
        }

        /// <summary>
        /// 得到指定长度，汉字当2个字符计算
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
                        //先判断加字段的数据
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
        /// 判断字符串数组中是否有values
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="split">分割字节</param>
        /// <param name="values">判断字符</param>
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
        /// 判断字符串数组中是否有values
        /// </summary>
        /// <param name="str">字符串数组</param>
        /// <param name="split">分割字节</param>
        /// <param name="values">判断字符</param>
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
        /// 得到文件的扩展名
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string SubFileExt(string strName)
        {
            return SubFileExt(strName, '.');
        }

        /// <summary>
        /// 得到文件的扩展名
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SubFileExt(string strName, char str)
        {
            //取得文件名(包括路径)里最后一个"."的索引
            int intExt = strName.LastIndexOf(str);
            //取得文件扩展名
            if (intExt != -1)
                return strName.Substring(intExt).Trim(str);
            else
                return strName;
        }

        /// <summary>
        /// 得到两个字符串之间的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <returns></returns>
        public static string SubString(string str, string start, string end)
        {
            return SubString(str, start, end, true);
        }

        /// <summary>
        /// 得到两个字符串之间的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="isEmpty">如果为true 则返回空</param>
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
        /// md5加密码
        /// </summary>
        /// <param name="swhere"></param>
        /// <returns></returns>
        public static string MD5(string swhere)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(swhere, "md5");
        }
        /// <summary>
        /// 在图片名称前加入一个字符，得到缩略图的地址
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
                    //最后一个
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
        /// 在图片名称前加入一个字符，得到缩略图的地址
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
        /// 得到控件参数值
        /// </summary>
        /// <param name="control">控件</param>
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
        /// 设置控件的值
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="values">值</param>
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
                // 按值找
                ListItem listItem = radioButtonList.Items.FindByValue(values);
                if (listItem == null)
                {
                    // 按显示的文本找
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
                    // 设置为被选中状态
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
                // 按值找
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
                    // 设置为被选中状态
                    listItem.Selected = true;
                }
            }
            return str;
        }

        /// <summary>
        /// 根据字符串，自动勾选CheckBoxList对应项
        /// </summary>
        /// <param name="checkBoxList">CheckBoxList控件</param>
        /// <param name="str">字符串，格式要求为“A,B,C”</param>
        public static void SetCheckBoxListData(CheckBoxList checkBoxList, string str)
        {
            string[] items = str.Split(',');
            //遍历items
            foreach (string item in items)
            {
                //如果值相等，则选中该项
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
        /// 根据CheckBoxList中选中的项，获得字符串
        /// </summary>
        /// <param name="checkBoxList">CheckBoxList控件</param>
        /// <returns>字符串，格式为“A,B,C”</returns>
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
        /// 转换为时间格式为yyyy-MM-dd
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static string ToDate(object obj)
        {
            return ToDateTime(obj, "yyyy-MM-dd");
        }

        /// <summary>
        /// 转换为时间格式为yyyy-MM-dd HH:mm;ss
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static string ToDateTime(object obj)
        {
            return ToDateTime(obj, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 转换为时间类型（格式自定义）
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <param name="format">自定义格式</param>
        /// <returns></returns>
        public static string ToDateTime(object obj, string format)
        {
            try
            {
                return Convert.ToDateTime(obj).ToString(format);
            }
            catch
            {
                return String.Empty;//转换失败返回空对象，防止报错
            }
        }

        /// <summary>
        /// 转换为int类型
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static int ToInt32(object obj)
        {
            return ToInt32(obj, 0);
        }
        /// <summary>
        /// 转换为int类型
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static int ToInt32(object obj, int reutndefault)
        {
            try
            {
                //如果为0，则返回默认值
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
        /// 转换为decimal类型
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static Decimal ToDecimal(object obj)
        {
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return 0;//转换失败返回0，防止报错
            }
        }

        /// <summary>
        /// 转换为bool类型
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static bool ToBool(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return false;//转换失败返回false，防止报错
            }
        }

        /// <summary>
        /// 替换SQL不安全字符
        /// </summary>
        /// <param name="s">待转换对象</param>
        /// <returns></returns>
        public static string ToSafeString(string s)
        {
            if (s != null)
            {
                StringBuilder str = new StringBuilder(s);
                str = str.Replace("'", "‘");
                //str = str.Replace("&", "&amp;");
                return str.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="obdata">要截取的对象</param>
        /// <param name="obLength">截取的长度</param>
        /// <returns>截取后的值</returns>
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
                        row[column_name] = "├ " + _Symbol(irow - 1, "─ ") + o[column_name];
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
                                row[column_name] = "├ " + _Symbol(irow - 1, "─ ") + o[column_name];
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
        /// 判断index是否存在于str中
        /// </summary>
        /// <param name="str">总的字符串</param>
        /// <param name="c">分隔符</param>
        /// <param name="index">要进行判断的字符串</param>
        /// <returns></returns>
        public static bool IsStringSplit(string str, char c, string index)
        {
            foreach (string s in str.Split(new char[] { c }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s == index) return true;
            }
            return false;
        }

        #region 文件是否存在
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
        /// 文字换行转html换行
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



        # region dataTable转换成Json格式
        /// <summary>  
        /// DataTable 对象 转换为Json 字符串  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string ConvertDataTableToJson(DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值  
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合  
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值  
            }
            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串  
        }

        /// <summary>  
        /// Json 字符串 转换为 DataTable数据集合  
        /// </summary>  
        /// <param name="json"></param>  
        /// <returns></returns>  
        public static DataTable ConvertJsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化  
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值  
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
                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中  
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




    #region 参数
    public class PublicParameters
    {
        /// <summary>
        /// 参数零
        /// </summary>
        public const int ZeroPram = 0;
        /// <summary>
        /// 参数一
        /// </summary>
        public const int OnePram = 1;
        /// <summary>
        /// 参数二
        /// </summary>
        public const int TwoPram = 2;
        /// <summary>
        /// 参数三
        /// </summary>
        public const int ThreePram = 3;
        /// <summary>
        /// 参数四
        /// </summary>
        public const int FourPram = 4;
        /// <summary>
        /// 参数五
        /// </summary>
        public const int FivePram = 5;
        /// <summary>
        /// 参数六
        /// </summary>
        public const int SixPram = 6;

        /// <summary>
        /// 参数七
        /// </summary>
        public const int SevenPram = 7;
        /// <summary>
        /// 参数八
        /// </summary>
        public const int EightPram = 8;
        /// <summary>
        /// 参数九
        /// </summary>
        public const int NinePram = 9;
        /// <summary>
        /// 参数十
        /// </summary>
        public const int TenPram = 10;

        /// <summary>
        /// 参数十一
        /// </summary>
        public const int ElevenPram = 11;
        /// <summary>
        /// 参数十二
        /// </summary>
        public const int TwelvePram = 12;
        /// <summary>
        /// 参数十二
        /// </summary>
        public const int ThirteenPram = 13;
    }
    #endregion




}
