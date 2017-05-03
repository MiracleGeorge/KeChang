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
    /// �ַ�������
    /// </summary>
    public class StringHelper
    {
        #region ����ָ�����ȵ���������ַ���
        /// <summary>
        /// ����ָ�����ȵ���������ַ���
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����ָ�����ȵ���������ַ���")]
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

        #region ����ȫ��Ψһ��ʶ
        /// <summary>
        /// ����ȫ��Ψһ��ʶ
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����ȫ��Ψһ��ʶ��int��")]
        public static int GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return Math.Abs(BitConverter.ToInt32(buffer, 0)) * -1;
        }

        [RemarkAttribute(Remark = "����ȫ��Ψһ��ʶ��string��")]
        public static string GenerateStringID()
        {
            return GenerateIntID().ToString();
        }
        #endregion

        #region ���������ָ���ķָ����������
        /// <summary>
        /// ���������ָ���ķָ����������
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "���������ָ���ķָ����������")]
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

        #region ���ַ�����ָ���ķָ����ָ������
        /// <summary>
        /// ���ַ�����ָ���ķָ����ָ������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "���ַ�����ָ���ķָ����ָ������")]
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

        [RemarkAttribute(Remark = "���ַ�����ָ���ķָ����ָ�����飬������ָ��������Ӧ��ֵ")]
        public static string SplitNum(string str, string separator, int index)
        {
            return Split(str, separator)[index];
        }
        #endregion

        #region �滻�ı��е�˫���š������ţ�ʹ���ܹ�������ʾ
        /// <summary>
        /// �滻�ı��е�˫���š������ţ�ʹ���ܹ�������ʾ
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "�滻�ı��е�˫���š������ţ�ʹ���ܹ�������ʾ")]
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

        #region ɾ���ı��е�����HTML��ǩ
        /// <summary>
        /// ɾ���ı��е�����HTML��ǩ
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "ɾ���ı��е�����HTML��ǩ")]
        public static string NoHtml(string html)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }
        #endregion

        #region ��ȡ�ַ������ȣ�������Ӣ�ġ����Ĵ���2���ֽڡ���
        /// <summary>
        /// ��ȡ�ַ������ȣ�������Ӣ�ġ����Ĵ���2���ֽڡ���
        /// </summary>
        /// <param name="title"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "��ȡ�ַ������ȣ�������Ӣ�ġ����Ĵ���2���ֽڡ���")]
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

        #region �õ������ַ���֮�������
        /// <summary>
        /// �õ������ַ���֮�������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">��ʼ</param>
        /// <param name="end">����</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "�õ������ַ���֮�������")]
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

        #region �����Զ���ű�
        /// <summary>
        /// �����Զ���ű�
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptContent"></param>
        public static void CustomScript(string scriptContent, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), GenerateStringID(), scriptContent, true);
        }
        #endregion

        #region ת�����ֿɶ��ԣ������10000��������㣬����10000000���ڼ���ȣ�
        /// <summary>
        /// ת�����ֿɶ��ԣ������10000��������㣬����10000000���ڼ���ȣ�
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "ת�����ֿɶ��ԣ������10000��������㣬����10000000���ڼ���ȣ�")]
        public static string ConvertNumberReadability(int number)
        {
            if (number >= 100000000)
            {
                return Math.Round(DataConvert.ToDecimal(number) / 100000000, 1, MidpointRounding.AwayFromZero) + "��";
            }
            else if (number >= 10000)
            {
                return Math.Round(DataConvert.ToDecimal(number) / 10000, 1, MidpointRounding.AwayFromZero) + "��";
            }
            else
            {
                return number.ToString();
            }
        }
        #endregion

        #region ��ȡJson�ַ���ĳ�ڵ��ֵ
        /// <summary>
        /// ��ȡJson�ַ���ĳ�ڵ��ֵ
        /// </summary>
        [RemarkAttribute(Remark = "��ȡJson�ַ���ĳ�ڵ��ֵ")]
        public static string GetJsonValue(string jsonStr, string key)
        {
            string result = "";
            Dictionary<string, string> dictType = new Dictionary<string, string>();
            Dictionary<string, string> dictionary = JsonConvert.DeserializeAnonymousType<Dictionary<string, string>>(jsonStr, dictType);
            if (dictionary.ContainsKey(key)) result = dictionary[key];
            return result;
        }
        #endregion

        #region md5����
        /// <summary>
        /// md5����
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "md5����")]
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
