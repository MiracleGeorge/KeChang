using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysModuleModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2016/9/24 17:41:42
	/// </summary>
	[Serializable]
	public class YouhooSysModuleModel
	{
		public YouhooSysModuleModel()
		{
			_module_id = 0;
		}

		#region Model
		private int _module_id;
		private string _module_name;
		private int _parentmodule_id;
		private string _module_url;
		private string _module_value;
		private int _sort;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysModuleModel(DataRow dr)
		{
			if (dr["module_id"] != null && dr["module_id"].ToString().Trim() != "") _module_id = Int32.Parse(dr["module_id"].ToString().Trim());
			if (dr["module_name"] != null) _module_name = dr["module_name"].ToString().Trim();
			if (dr["parentmodule_id"] != null && dr["parentmodule_id"].ToString().Trim() != "") _parentmodule_id = Int32.Parse(dr["parentmodule_id"].ToString().Trim());
			if (dr["module_url"] != null) _module_url = dr["module_url"].ToString().Trim();
			if (dr["module_value"] != null) _module_value = dr["module_value"].ToString().Trim();
			if (dr["sort"] != null && dr["sort"].ToString().Trim() != "") _sort = Int32.Parse(dr["sort"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 模块编号
		/// </summary>
		[RemarkAttribute(Remark = "模块编号")]
		public int ModuleId
		{
			set{ _module_id=value;}
			get{return _module_id;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		[RemarkAttribute(Remark = "模块名称")]
		public string ModuleName
		{
			set{ _module_name=value;}
			get{return _module_name;}
		}
		/// <summary>
		/// 父级模块id
		/// </summary>
		[RemarkAttribute(Remark = "父级模块id")]
		public int ParentmoduleId
		{
			set{ _parentmodule_id=value;}
			get{return _parentmodule_id;}
		}
		/// <summary>
		/// 模块链接地址
		/// </summary>
		[RemarkAttribute(Remark = "模块链接地址")]
		public string ModuleUrl
		{
			set{ _module_url=value;}
			get{return _module_url;}
		}
		/// <summary>
		/// 标识编号
		/// </summary>
		[RemarkAttribute(Remark = "标识编号")]
		public string ModuleValue
		{
			set{ _module_value=value;}
			get{return _module_value;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		[RemarkAttribute(Remark = "排序")]
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
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
