using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;

namespace YouHoo.DataTools
{
    /// <summary>
    /// �ַ�������
    /// </summary>
    public class StringOperate
    {
        #region ����ָ�����ȵ���������ַ���
        /// <summary>
        /// ����ָ�����ȵ���������ַ���
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
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
        public static int GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt32(buffer, 0);
        }

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
        public static string Combination(string[] obj, string separator)
        {
            string str = "";
            if (obj != null)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    str += obj[i] + separator;
                }
                str = str.Substring(0, str.LastIndexOf(separator));
            }
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
        public static string NoHtml(string html)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }
        #endregion

        #region ��ȡ�ַ������ȣ����Դ�Сд��
        /// <summary>
        /// ��ȡ�ַ������ȣ����Դ�Сд��
        /// </summary>
        /// <param name="title"></param>
        /// <param name="length"></param>
        /// <returns></returns>
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
        public static string SubString(string str, string start, string end)
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

        #region ����ͼƬ�ӳټ���
        /// <summary>
        /// ����ͼƬ�ӳټ���
        /// </summary>
        public static string Lazyload(string htmlCode)
        {
            while (htmlCode.IndexOf("src=") != -1)
            {
                //��ȡsrc֮���·����Ϣ
                string src = SubString(htmlCode, "src=\"", "\"");
                string str = "src=\"" + src + "\"";
                string strp = "data-url=\"" + src + "\" class=\"lazyload\"";
                htmlCode = htmlCode.Replace(str, strp);
            }
            return htmlCode;
        }
        #endregion

        #region ���ݱ�Ź�����ɱ��
        /// <summary>
        /// ���ݱ�Ź�����ɱ��
        /// </summary>
        public static string CreateNumberByRule(string numberRule)
        {
            while (numberRule.IndexOf("{") != -1)
            {
                int number = DataConvert.ToInt32(SubString(numberRule, "{", "}"));
                string str = "{" + number + "}";
                string strp = GetRangeNumber(number);
                numberRule = numberRule.Replace(str, strp);
            }
            return numberRule;
        }
        #endregion
    }
}
