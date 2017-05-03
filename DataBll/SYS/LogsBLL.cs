using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YouHoo.DataModel;
using YouHoo.DataOperation;
using YouHoo.DataTools;
using System.Web.Security;

namespace YouHoo.DataBll
{
    /// <summary>
    /// ҵ���߼��ࣺLogsBLL
    /// ʱ�䣺2015/4/8 15:49:38
    /// </summary>
    public class LogsBLL
    {
        private readonly LogsDAL dal = new LogsDAL();

        public LogsBLL()
        { }
        #region  ��Ա����
        /// <summary>
        /// ��������б�
        /// </summary>
        [RemarkAttribute(Remark = "��������б�")]
        public DataTable GetListByPage(int pageIndex, int pageSize, out int count)
        {
            DataTable dt = dal.GetListByPage(pageIndex, pageSize, out count);
            return dt;
        }
        #endregion  ��Ա����
    }
}
