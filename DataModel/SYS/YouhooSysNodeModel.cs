using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysNodeModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2017-03-02 16:08:48
	/// </summary>
	[Serializable]
	public class YouhooSysNodeModel
	{
		public YouhooSysNodeModel()
		{
			_ID = 0;
		}

		#region Model
		private int _ID;
		private string _NodeName;
		private int _ProcessId;
		private int _StoreId;
		private int _RoleId;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysNodeModel(DataRow dr)
		{
			if (dr["ID"] != null && dr["ID"].ToString().Trim() != "") _ID = Int32.Parse(dr["ID"].ToString().Trim());
			if (dr["NodeName"] != null) _NodeName = dr["NodeName"].ToString().Trim();
			if (dr["ProcessId"] != null && dr["ProcessId"].ToString().Trim() != "") _ProcessId = Int32.Parse(dr["ProcessId"].ToString().Trim());
			if (dr["StoreId"] != null && dr["StoreId"].ToString().Trim() != "") _StoreId = Int32.Parse(dr["StoreId"].ToString().Trim());
			if (dr["RoleId"] != null && dr["RoleId"].ToString().Trim() != "") _RoleId = Int32.Parse(dr["RoleId"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 流程节点ID
		/// </summary>
		public int Id
		{
			set{ _ID=value;}
			get{return _ID;}
		}
		/// <summary>
		/// 流程节点名称
		/// </summary>
		public string Nodename
		{
			set{ _NodeName=value;}
			get{return _NodeName;}
		}
		/// <summary>
		/// 所属流程
		/// </summary>
		public int Processid
		{
			set{ _ProcessId=value;}
			get{return _ProcessId;}
		}
		/// <summary>
		/// 所属公司(实验室)
		/// </summary>
		public int Storeid
		{
			set{ _StoreId=value;}
			get{return _StoreId;}
		}
		/// <summary>
		/// 审核角色
		/// </summary>
		public int Roleid
		{
			set{ _RoleId=value;}
			get{return _RoleId;}
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
		/// 逻辑状态
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
