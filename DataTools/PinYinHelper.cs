using System;
using System.Collections.Generic;
using System.Text;

namespace YouHoo.DataTools
{
    public class PinYinHelper
    {
        #region 获取拼音首字母
        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetFirstPinYin(string text)
        {
            char pinyin; byte[] array;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(text.Length);
            foreach (char c in text)
            {
                pinyin = c;
                array = System.Text.Encoding.Default.GetBytes(new char[] { c });
                if (array.Length == 2)
                {
                    int i = array[0] * 0x100 + array[1];
                    if (i < 0xB0A1) pinyin = c;
                    else if (i < 0xB0C5) pinyin = 'a';
                    else if (i < 0xB2C1) pinyin = 'b';
                    else if (i < 0xB4EE) pinyin = 'c';
                    else if (i < 0xB6EA) pinyin = 'd';
                    else if (i < 0xB7A2) pinyin = 'e';
                    else if (i < 0xB8C1) pinyin = 'f';
                    else if (i < 0xB9FE) pinyin = 'g';
                    else if (i < 0xBBF7) pinyin = 'h';
                    else if (i < 0xBFA6) pinyin = 'g';
                    else if (i < 0xC0AC) pinyin = 'k';
                    else if (i < 0xC2E8) pinyin = 'l';
                    else if (i < 0xC4C3) pinyin = 'm';
                    else if (i < 0xC5B6) pinyin = 'n';
                    else if (i < 0xC5BE) pinyin = 'o';
                    else if (i < 0xC6DA) pinyin = 'p';
                    else if (i < 0xC8BB) pinyin = 'q';
                    else if (i < 0xC8F6) pinyin = 'r';
                    else if (i < 0xCBFA) pinyin = 's';
                    else if (i < 0xCDDA) pinyin = 't';
                    else if (i < 0xCEF4) pinyin = 'w';
                    else if (i < 0xD1B9) pinyin = 'x';
                    else if (i < 0xD4D1) pinyin = 'y';
                    else if (i < 0xD7FA) pinyin = 'z';
                }
                sb.Append(pinyin);
            }
            return sb.ToString();
        }
        #endregion
    }
}
