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
        #region String转换
        [RemarkAttribute(Remark = "String转换")]
        public static string ToString(object o)
        {
            return ToString(o, "");
        }
        [RemarkAttribute(Remark = "String转换（自定义默认值）")]
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

        #region Int转换
        [RemarkAttribute(Remark = "Int转换")]
        public static int ToInt32(object o)
        {
            return ToInt32(o, 0);
        }
        [RemarkAttribute(Remark = "Int转换（自定义默认值）")]
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

        #region Long转换
        [RemarkAttribute(Remark = "Long转换")]
        public static long ToInt64(object o)
        {
            return ToInt64(o, 0);
        }
        [RemarkAttribute(Remark = "Long转换（自定义默认值）")]
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

        #region Float转换
        [RemarkAttribute(Remark = "Float转换")]
        public static float ToSingle(object o)
        {
            return ToSingle(o, 0);
        }
        [RemarkAttribute(Remark = "Float转换（自定义默认值）")]
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

        #region Dobule转换
        [RemarkAttribute(Remark = "Dobule转换")]
        public static double ToDouble(object o)
        {
            return ToDouble(o, 0);
        }
        [RemarkAttribute(Remark = "Dobule转换（自定义默认值）")]
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

        #region Decimal转换
        [RemarkAttribute(Remark = "Decimal转换")]
        public static decimal ToDecimal(object o)
        {
            return ToDecimal(o, 0);
        }
        [RemarkAttribute(Remark = "Decimal转换（自定义默认值）")]
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

        #region DateTime转换
        [RemarkAttribute(Remark = "DateTime转换")]
        public static DateTime ToDateTime(object o)
        {
            return ToDateTime(o, DateTime.Now);
        }
        [RemarkAttribute(Remark = "DateTime转换（自定义默认值）")]
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
        [RemarkAttribute(Remark = "DateTime转String")]
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
        [RemarkAttribute(Remark = "DateTime转String（自定义格式）")]
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
        [RemarkAttribute(Remark = "DateTime转Int")]
        public static int ToDateTimeInt(DateTime dt)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(dt - startTime).TotalSeconds;
        }
        #endregion

        #region Bool转换
        [RemarkAttribute(Remark = "Bool转换")]
        public static bool ToBoolean(object o)
        {
            return ToBoolean(o, false);
        }
        [RemarkAttribute(Remark = "Bool转换（自定义默认值）")]
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
