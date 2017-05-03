using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysPowergroupModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2016-11-09 15:56:33
	/// </summary>
	[Serializable]
	public class YouhooSysPowergroupModel
	{
		public YouhooSysPowergroupModel()
		{
			_powergroup_id = 0;
		}

		#region Model
		private int _powergroup_id;
		private int _StoreId;
		private string _powergroup_name;
		private string _powergroup_value;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysPowergroupModel(DataRow dr)
		{
			if (dr["powergroup_id"] != null && dr["powergroup_id"].ToString().Trim() != "") _powergroup_id = Int32.Parse(dr["powergroup_id"].ToString().Trim());
			if (dr["StoreId"] != null && dr["StoreId"].ToString().Trim() != "") _StoreId = Int32.Parse(dr["StoreId"].ToString().Trim());
			if (dr["powergroup_name"] != null) _powergroup_name = dr["powergroup_name"].ToString().Trim();
			if (dr["powergroup_value"] != null) _powergroup_value = dr["powergroup_value"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 权限组编号
		/// </summary>
		public int PowergroupId
		{
			set{ _powergroup_id=value;}
			get{return _powergroup_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Storeid
		{
			set{ _StoreId=value;}
			get{return _StoreId;}
		}
		/// <summary>
		/// 权限组名称
		/// </summary>
		public string PowergroupName
		{
			set{ _powergroup_name=value;}
			get{return _powergroup_name;}
		}
		/// <summary>
		/// 标识编号
		/// </summary>
		public string PowergroupValue
		{
			set{ _powergroup_value=value;}
			get{return _powergroup_value;}
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
		/// 创建者ID
		/// </summary>
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
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
		#endregion Model
	}
}
