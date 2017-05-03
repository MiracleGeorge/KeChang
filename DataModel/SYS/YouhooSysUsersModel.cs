using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysUsersModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2016-11-10 11:28:27
	/// </summary>
	[Serializable]
	public class YouhooSysUsersModel
	{
		public YouhooSysUsersModel()
		{
			_user_id = 0;
		}

		#region Model
		private int _user_id;
		private string _usercode;
		private string _username;
		private string _password;
		private string _real_name;
		private int _StoreId;
		private int _departmentId;
		private string _phone;
		private string _tel;
		private string _email;
		private int _powergroup_id;
		private bool _IsSaleMan;
		private int _status;
		private string _remark;
		private int? _flag;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;
        private string _powergroup_value;

		public YouhooSysUsersModel(DataRow dr)
		{
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["usercode"] != null) _usercode = dr["usercode"].ToString().Trim();
			if (dr["username"] != null) _username = dr["username"].ToString().Trim();
			if (dr["password"] != null) _password = dr["password"].ToString().Trim();
			if (dr["real_name"] != null) _real_name = dr["real_name"].ToString().Trim();
			if (dr["StoreId"] != null && dr["StoreId"].ToString().Trim() != "") _StoreId = Int32.Parse(dr["StoreId"].ToString().Trim());
			if (dr["departmentId"] != null && dr["departmentId"].ToString().Trim() != "") _departmentId = Int32.Parse(dr["departmentId"].ToString().Trim());
			if (dr["phone"] != null) _phone = dr["phone"].ToString().Trim();
			if (dr["tel"] != null) _tel = dr["tel"].ToString().Trim();
			if (dr["email"] != null) _email = dr["email"].ToString().Trim();
			if (dr["powergroup_id"] != null && dr["powergroup_id"].ToString().Trim() != "") _powergroup_id = Int32.Parse(dr["powergroup_id"].ToString().Trim());
			if (dr["IsSaleMan"] != null && dr["IsSaleMan"].ToString().Trim() != "") _IsSaleMan = Boolean.Parse(dr["IsSaleMan"].ToString().Trim());
			if (dr["status"] != null && dr["status"].ToString().Trim() != "") _status = Int32.Parse(dr["status"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
            if (dr["powergroup_value"] != null) _powergroup_value = dr["powergroup_value"].ToString().Trim();
		}

		/// <summary>
		/// 用户编号
		/// </summary>
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 用户编号
		/// </summary>
		public string Usercode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string RealName
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 所属门店
		/// </summary>
		public int Storeid
		{
			set{ _StoreId=value;}
			get{return _StoreId;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public int Departmentid
		{
			set{ _departmentId=value;}
			get{return _departmentId;}
		}
		/// <summary>
		/// 移动电话
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 角色编号（引用权限组表，用于获取用户角色信息）
		/// </summary>
		public int PowergroupId
		{
			set{ _powergroup_id=value;}
			get{return _powergroup_id;}
		}
		/// <summary>
		/// 是否业务员
		/// </summary>
		public bool Issaleman
		{
			set{ _IsSaleMan=value;}
			get{return _IsSaleMan;}
		}
		/// <summary>
		/// 状态（0：正常；1：冻结）
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 逻辑状态（1：存在；0：不存在）
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string Createoperator
		{
			set{ _createoperator=value;}
			get{return _createoperator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? Createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public string Updateoperator
		{
			set{ _updateoperator=value;}
			get{return _updateoperator;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? Updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}

        /// <summary>
        /// 扩展字段：权限组值
        /// </summary>
        public string PowergroupValue
        {
            get { return _powergroup_value; }
            set { _powergroup_value = value; }
        }
		#endregion Model
	}
}
