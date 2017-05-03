using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysDepartmentModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2017-03-02 10:43:54
	/// </summary>
	[Serializable]
	public class YouhooSysDepartmentModel
	{
		public YouhooSysDepartmentModel()
		{
			_Id = 0;
		}

		#region Model
		private int _Id;
		private int _StoreId;
		private string _Code;
		private string _Name;
		private string _SubCode;
		private string _SubName;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysDepartmentModel(DataRow dr)
		{
			if (dr["Id"] != null && dr["Id"].ToString().Trim() != "") _Id = Int32.Parse(dr["Id"].ToString().Trim());
			if (dr["StoreId"] != null && dr["StoreId"].ToString().Trim() != "") _StoreId = Int32.Parse(dr["StoreId"].ToString().Trim());
			if (dr["Code"] != null) _Code = dr["Code"].ToString().Trim();
			if (dr["Name"] != null) _Name = dr["Name"].ToString().Trim();
			if (dr["SubCode"] != null) _SubCode = dr["SubCode"].ToString().Trim();
			if (dr["SubName"] != null) _SubName = dr["SubName"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 部门表
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
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
		/// 部门编号
		/// </summary>
		public string Code
		{
			set{ _Code=value;}
			get{return _Code;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		/// <summary>
		/// 二级部门编号
		/// </summary>
		public string Subcode
		{
			set{ _SubCode=value;}
			get{return _SubCode;}
		}
		/// <summary>
		/// 二级部门名称
		/// </summary>
		public string Subname
		{
			set{ _SubName=value;}
			get{return _SubName;}
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
