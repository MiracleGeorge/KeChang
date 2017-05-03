using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouHoo.DataTools
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class RemarkAttribute : Attribute
    {
        private string remark;
        /// <summary>
        /// ±¸×¢
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
