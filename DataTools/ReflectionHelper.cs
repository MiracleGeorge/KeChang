using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YouHoo.DataTools
{
    /// <summary>
    /// ���������
    /// </summary>
    public class ReflectionHelper
    {
        #region ʵ��������
        /// <summary>
        /// ʵ��������
        /// </summary>
        /// <param name="type">����</param>
        /// <returns></returns>
        public static object CreateInstance(Type type)
        {
            try
            {
                return Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                //��¼������־
                Logger.Error("YouHoo.DataTools.ReflectionHelper." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region ִ�з���
        /// <summary>
        /// ִ�з���
        /// </summary>
        /// <param name="type">����</param>
        /// <param name="methodName">��������</param>
        /// <param name="parameter">����</param>
        /// <returns></returns>
        public static object ExecMethod(Type type, string methodName, object[] parameter)
        {
            try
            {
                object meObj = CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod(methodName);
                return methodInfo.Invoke(meObj, parameter);
            }
            catch (Exception ex)
            {
                //��¼������־
                Logger.Error("YouHoo.DataTools.ReflectionHelper." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// ִ�з����������������
        /// </summary>
        /// <param name="type">����</param>
        /// <param name="methodName">��������</param>
        /// <param name="parameter">����</param>
        /// <returns></returns>
        public static object ExecMethod(Type type, string methodName, object[] parameter, out object[] outParameter)
        {
            try
            {
                object meObj = CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object obj = methodInfo.Invoke(meObj, parameter);
                outParameter = parameter;
                return obj;
            }
            catch (Exception ex)
            {
                //��¼������־
                Logger.Error("YouHoo.DataTools.ReflectionHelper." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region ��������ֵ
        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            try
            {
                //��ȡ������Ϣ
                PropertyInfo pi = obj.GetType().GetProperty(propertyName);
                //��������ת��
                if (pi.PropertyType == typeof(Int32))
                {
                    value = DataConvert.ToInt32(value);
                }
                else if (pi.PropertyType == typeof(Int32?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToInt32(value);
                }
                else if (pi.PropertyType == typeof(Int64))
                {
                    value = DataConvert.ToInt64(value);
                }
                else if (pi.PropertyType == typeof(Int64?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToInt64(value);
                }
                else if (pi.PropertyType == typeof(float))
                {
                    value = DataConvert.ToSingle(value);
                }
                else if (pi.PropertyType == typeof(float?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToSingle(value);
                }
                else if (pi.PropertyType == typeof(double))
                {
                    value = DataConvert.ToDouble(value);
                }
                else if (pi.PropertyType == typeof(double?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToDouble(value);
                }
                else if (pi.PropertyType == typeof(decimal))
                {
                    value = DataConvert.ToDecimal(value);
                }
                else if (pi.PropertyType == typeof(decimal?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToDecimal(value);
                }
                else if (pi.PropertyType == typeof(DateTime))
                {
                    value = DataConvert.ToDateTime(value);
                }
                else if (pi.PropertyType == typeof(DateTime?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToDateTime(value);
                }
                else if (pi.PropertyType == typeof(bool))
                {
                    value = DataConvert.ToBoolean(value);
                }
                else if (pi.PropertyType == typeof(bool?))
                {
                    if (value == "") value = null;
                    else value = DataConvert.ToBoolean(value);
                }
                //��������ֵ
                pi.SetValue(obj, value, null);
            }
            catch (Exception ex)
            {
                //��¼������־
                Logger.Error("YouHoo.DataTools.ReflectionHelper." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region ��ȡ����ֵ
        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            try
            {
                PropertyInfo pi = obj.GetType().GetProperty(propertyName);
                return pi.GetValue(obj, null);
            }
            catch (Exception ex)
            {
                //��¼������־
                Logger.Error("YouHoo.DataTools.ReflectionHelper." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region ��ȡ�����༯��
        /// <summary>
        /// ��ȡ�����༯��
        /// </summary>
        /// <returns></returns>
        public static Type[] GetTypes(string className)
        {
            return Assembly.Load(className).GetTypes();
        }
        #endregion

        #region ��ȡ���󷽷�����
        /// <summary>
        /// ��ȡ���󷽷�����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethodInfo(Type type)
        {
            MethodInfo[] mis = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return mis;
        }
        #endregion

        #region ��ȡ���󷽷���������
        /// <summary>
        /// ��ȡ���󷽷���������
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static ParameterInfo[] GetParameterInfo(MethodInfo mi)
        {
            ParameterInfo[] pis = mi.GetParameters();
            return pis;
        }

        public static string GetParameterInfoToString(MethodInfo mi, bool drawing)
        {
            string pis = "";
            foreach (ParameterInfo pi in ReflectionHelper.GetParameterInfo(mi))
            {
                string typeName = pi.ParameterType.Name;
                if (typeName == "Int32") typeName = "Int";
                else if (typeName == "Int64") typeName = "Long";
                else if (typeName == "Int32&") typeName = "out Int";
                if (drawing)
                {
                    pis += "<span style=\"color:#002fea\">" + typeName + "</span> " + pi.Name + ", ";
                }
                else
                {
                    pis += typeName + " " + pi.Name + ", ";
                }
            }
            if (pis != "") pis = pis.Trim().Trim(',');
            return pis;
        }
        #endregion

        #region ��ȡ�����ֶμ���
        /// <summary>
        /// ��ȡ�����ֶμ���
        /// </summary>
        /// <returns></returns>
        public static FieldInfo[] GetFieldInfo(Type type)
        {
            FieldInfo[] fis = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return fis;
        }
        #endregion

        #region ��ȡ�������Լ���
        /// <summary>
        /// ��ȡ�������Լ���
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfo(Type type)
        {
            PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return pis;
        }
        #endregion

        #region ��ȡ����ָ�����Եı�עֵ
        /// <summary>
        /// ��ȡ����ָ�����Եı�עֵ
        /// </summary>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyRemark(Type type, string property)
        {
            PropertyInfo pi = type.GetProperty(property);
            return (pi.GetCustomAttributes(typeof(RemarkAttribute), false)[0] as RemarkAttribute).Remark;
        }
        #endregion
    }
}
