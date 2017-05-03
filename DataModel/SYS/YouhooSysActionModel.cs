using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysActionModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2016/9/24 17:41:39
	/// </summary>
	[Serializable]
	public class YouhooSysActionModel
	{
		public YouhooSysActionModel()
		{
			_action_id = 0;
		}

		#region Model
		private int _action_id;
		private string _action_name;
		private string _action_value;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysActionModel(DataRow dr)
		{
			if (dr["action_id"] != null && dr["action_id"].ToString().Trim() != "") _action_id = Int32.Parse(dr["action_id"].ToString().Trim());
			if (dr["action_name"] != null) _action_name = dr["action_name"].ToString().Trim();
			if (dr["action_value"] != null) _action_value = dr["action_value"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 动作编号
		/// </summary>
		[RemarkAttribute(Remark = "动作编号")]
		public int ActionId
		{
			set{ _action_id=value;}
			get{return _action_id;}
		}
		/// <summary>
		/// 动作名称
		/// </summary>
		[RemarkAttribute(Remark = "动作名称")]
		public string ActionName
		{
			set{ _action_name=value;}
			get{return _action_name;}
		}
		/// <summary>
		/// 标识编号
		/// </summary>
		[RemarkAttribute(Remark = "标识编号")]
		public string ActionValue
		{
			set{ _action_value=value;}
			get{return _action_value;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		[RemarkAttribute(Remark = "备注")]
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 逻辑状态（1：存在；0：不存在）
		/// </summary>
		[RemarkAttribute(Remark = "逻辑状态（1：存在；0：不存在）")]
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 创建者ID
		/// </summary>
		[RemarkAttribute(Remark = "创建者ID")]
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		[RemarkAttribute(Remark = "创建人")]
		public string Createoperator
		{
			set{ _createoperator=value;}
			get{return _createoperator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		[RemarkAttribute(Remark = "创建时间")]
		public DateTime? Createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		[RemarkAttribute(Remark = "修改人")]
		public string Updateoperator
		{
			set{ _updateoperator=value;}
			get{return _updateoperator;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		[RemarkAttribute(Remark = "修改时间")]
		public DateTime? Updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model
	}
}
