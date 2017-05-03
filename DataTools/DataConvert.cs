using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace YouHoo.DataTools
{
    public class DataConvert
    {
        #region Stringת��
        [RemarkAttribute(Remark = "Stringת��")]
        public static string ToString(object o)
        {
            return ToString(o, "");
        }
        [RemarkAttribute(Remark = "Stringת�����Զ���Ĭ��ֵ��")]
        public static string ToString(object o, string defaultValue)
        {
            try
            {
                return o.ToString();
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region Intת��
        [RemarkAttribute(Remark = "Intת��")]
        public static int ToInt32(object o)
        {
            return ToInt32(o, 0);
        }
        [RemarkAttribute(Remark = "Intת�����Զ���Ĭ��ֵ��")]
        public static int ToInt32(object o, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region Longת��
        [RemarkAttribute(Remark = "Longת��")]
        public static long ToInt64(object o)
        {
            return ToInt64(o, 0);
        }
        [RemarkAttribute(Remark = "Longת�����Զ���Ĭ��ֵ��")]
        public static long ToInt64(object o, long defaultValue)
        {
            try
            {
                return Convert.ToInt64(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region Floatת��
        [RemarkAttribute(Remark = "Floatת��")]
        public static float ToSingle(object o)
        {
            return ToSingle(o, 0);
        }
        [RemarkAttribute(Remark = "Floatת�����Զ���Ĭ��ֵ��")]
        public static float ToSingle(object o, float defaultValue)
        {
            try
            {
                return Convert.ToSingle(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region Dobuleת��
        [RemarkAttribute(Remark = "Dobuleת��")]
        public static double ToDouble(object o)
        {
            return ToDouble(o, 0);
        }
        [RemarkAttribute(Remark = "Dobuleת�����Զ���Ĭ��ֵ��")]
        public static double ToDouble(object o, double defaultValue)
        {
            try
            {
                return Convert.ToDouble(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region Decimalת��
        [RemarkAttribute(Remark = "Decimalת��")]
        public static decimal ToDecimal(object o)
        {
            return ToDecimal(o, 0);
        }
        [RemarkAttribute(Remark = "Decimalת�����Զ���Ĭ��ֵ��")]
        public static decimal ToDecimal(object o, decimal defaultValue)
        {
            try
            {
                return Convert.ToDecimal(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region DateTimeת��
        [RemarkAttribute(Remark = "DateTimeת��")]
        public static DateTime ToDateTime(object o)
        {
            return ToDateTime(o, DateTime.Now);
        }
        [RemarkAttribute(Remark = "DateTimeת�����Զ���Ĭ��ֵ��")]
        public static DateTime ToDateTime(object o, DateTime defaultValue)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        [RemarkAttribute(Remark = "DateTimeתString")]
        public static string ToDateTimeString(object o)
        {
            try
            {
                return Convert.ToDateTime(o).ToString();
            }
            catch (Exception)
            {
                return DateTime.Now.ToString();
            }
        }
        [RemarkAttribute(Remark = "DateTimeתString���Զ����ʽ��")]
        public static string ToDateTimeString(object o, string Format)
        {
            try
            {
                return Convert.ToDateTime(o).ToString(Format);
            }
            catch (Exception)
            {
                return DateTime.Now.ToString(Format);
            }
        }
        [RemarkAttribute(Remark = "DateTimeתInt")]
        public static int ToDateTimeInt(DateTime dt)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(dt - startTime).TotalSeconds;
        }
        #endregion

        #region Boolת��
        [RemarkAttribute(Remark = "Boolת��")]
        public static bool ToBoolean(object o)
        {
            return ToBoolean(o, false);
        }
        [RemarkAttribute(Remark = "Boolת�����Զ���Ĭ��ֵ��")]
        public static bool ToBoolean(object o, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(o);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

       
    }
}
