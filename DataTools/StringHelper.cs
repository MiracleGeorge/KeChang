using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace YouHoo.DataTools
{
    /// <summary>
    /// 字符操作类
    /// </summary>
    public class StringHelper
    {
        #region 生成指定长度的随机数字字符串
        /// <summary>
        /// 生成指定长度的随机数字字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "生成指定长度的随机数字字符串")]
        public static string GetRangeNumber(int length)
        {
            int range = 1;
            for (int i = 0; i < length; i++)
            {
                range = range * 10;
            }
            Random random = new Random();
            int ran = random.Next(range / 10, range);
            return ran.ToString();
        }
        #endregion

        #region 生成全局唯一标识
        /// <summary>
        /// 生成全局唯一标识
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "生成全局唯一标识（int）")]
        public static int GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return Math.Abs(BitConverter.ToInt32(buffer, 0)) * -1;
        }

        [RemarkAttribute(Remark = "生成全局唯一标识（string）")]
        public static string GenerateStringID()
        {
            return GenerateIntID().ToString();
        }
        #endregion

        #region 将数组根据指定的分隔符进行组合
        /// <summary>
        /// 将数组根据指定的分隔符进行组合
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "将数组根据指定的分隔符进行组合")]
        public static string Combination(string[] obj, string separator)
        {
            string str = "";
            if (obj != null)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    str += obj[i] + separator;
                }
            }
            if (str != "") str = str.Substring(0, str.LastIndexOf(separator));
            return str;
        }
        #endregion

        #region 将字符串按指定的分隔符分割成数组
        /// <summary>
        /// 将字符串按指定的分隔符分割成数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "将字符串按指定的分隔符分割成数组")]
        public static string[] Split(string str, string separator)
        {
            List<string> list = new List<string>();
            SplitMethod(list, str, separator);
            string[] array = list.ToArray();
            return array;
        }

        private static void SplitMethod(List<string> list, string str, string separator)
        {
            if (str.Length != 0)
            {
                if (str.IndexOf(separator) == -1)
                {
                    list.Add(str);
                }
                else
                {
                    list.Add(str.Substring(0, str.IndexOf(separator)));
                    str = str.Remove(0, str.IndexOf(separator) + separator.Length);
                    SplitMethod(list, str, separator);
                }
            }
        }

        [RemarkAttribute(Remark = "将字符串按指定的分隔符分割成数组，并返回指定索引对应的值")]
        public static string SplitNum(string str, string separator, int index)
        {
            return Split(str, separator)[index];
        }
        #endregion

        #region 替换文本中的双引号、单引号，使其能够正常显示
        /// <summary>
        /// 替换文本中的双引号、单引号，使其能够正常显示
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "替换文本中的双引号、单引号，使其能够正常显示")]
        public static string ReplaceSpecial(string txt)
        {
            string dst = txt;
            dst = dst.Replace("\"", "\\\"");
            dst = dst.Replace("\\r\\n", "");
            dst = dst.Replace("\\r", "");
            dst = dst.Replace("\\n", "");
            dst = dst.Replace("\r\n", "");
            dst = dst.Replace("\r", "");
            dst = dst.Replace("\n", "");
            return dst;
        }
        #endregion

        #region 删除文本中的所有HTML标签
        /// <summary>
        /// 删除文本中的所有HTML标签
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "删除文本中的所有HTML标签")]
        public static string NoHtml(string html)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }
        #endregion

        #region 截取字符串长度（忽略中英文【中文代表2个字节】）
        /// <summary>
        /// 截取字符串长度（忽略中英文【中文代表2个字节】）
        /// </summary>
        /// <param name="title"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "截取字符串长度（忽略中英文【中文代表2个字节】）")]
        public static string Substring(string content, int length)
        {
            string temp = content.ToString().Replace("<br/>", "").Replace("<br>", "");
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= length)
            {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i);
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= length - 3)
                {
                    return temp + "...";
                }
            }
            return "";
        }
        #endregion

        #region 得到两个字符串之间的内容
        /// <summary>
        /// 得到两个字符串之间的内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "得到两个字符串之间的内容")]
        public static string SubstringAmong(string str, string start, string end)
        {
            if (String.IsNullOrEmpty(str)) return str;
            int istart = str.IndexOf(start);
            if (istart == -1) return "";
            istart += start.Length;
            int iend = str.IndexOf(end, istart);
            if (iend == -1) return "";
            str = str.Substring(istart, iend - istart);
            return str;
        }

        #endregion

        #region 创建自定义脚本
        /// <summary>
        /// 创建自定义脚本
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptContent"></param>
        public static void CustomScript(string scriptContent, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), GenerateStringID(), scriptContent, true);
        }
        #endregion

        #region 转换数字可读性（如大于10000，以万计算，大于10000000以亿计算等）
        /// <summary>
        /// 转换数字可读性（如大于10000，以万计算，大于10000000以亿计算等）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "转换数字可读性（如大于10000，以万计算，大于10000000以亿计算等）")]
        public static string ConvertNumberReadability(int number)
        {
            if (number >= 100000000)
            {
                return Math.Round(DataConvert.ToDecimal(number) / 100000000, 1, MidpointRounding.AwayFromZero) + "亿";
            }
            else if (number >= 10000)
            {
                return Math.Round(DataConvert.ToDecimal(number) / 10000, 1, MidpointRounding.AwayFromZero) + "万";
            }
            else
            {
                return number.ToString();
            }
        }
        #endregion

        #region 获取Json字符串某节点的值
        /// <summary>
        /// 获取Json字符串某节点的值
        /// </summary>
        [RemarkAttribute(Remark = "获取Json字符串某节点的值")]
        public static string GetJsonValue(string jsonStr, string key)
        {
            string result = "";
            Dictionary<string, string> dictType = new Dictionary<string, string>();
            Dictionary<string, string> dictionary = JsonConvert.DeserializeAnonymousType<Dictionary<string, string>>(jsonStr, dictType);
            if (dictionary.ContainsKey(key)) result = dictionary[key];
            return result;
        }
        #endregion

        #region md5加密
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "md5加密")]
        public static string Md5(string password)
        {
            string md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
            for (int i = 0; i < 5; i++)
            {
                md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(md5.Substring(0, 20 + i), "md5");
            }
            return md5;
        }
        #endregion
    }
}
