using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooSysDictionaryChildModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2016/9/24 17:41:40
	/// </summary>
	[Serializable]
	public class YouhooSysDictionaryChildModel
	{
		public YouhooSysDictionaryChildModel()
		{
			_dictionary_child_id = 0;
		}

		#region Model
		private int _dictionary_child_id;
		private string _dictionary_child_name;
		private int _dictionary_id;
		private int _parent_dictionary_child_id;
		private int _is_start;
		private int _sort;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysDictionaryChildModel(DataRow dr)
		{
			if (dr["dictionary_child_id"] != null && dr["dictionary_child_id"].ToString().Trim() != "") _dictionary_child_id = Int32.Parse(dr["dictionary_child_id"].ToString().Trim());
			if (dr["dictionary_child_name"] != null) _dictionary_child_name = dr["dictionary_child_name"].ToString().Trim();
			if (dr["dictionary_id"] != null && dr["dictionary_id"].ToString().Trim() != "") _dictionary_id = Int32.Parse(dr["dictionary_id"].ToString().Trim());
			if (dr["parent_dictionary_child_id"] != null && dr["parent_dictionary_child_id"].ToString().Trim() != "") _parent_dictionary_child_id = Int32.Parse(dr["parent_dictionary_child_id"].ToString().Trim());
			if (dr["is_start"] != null && dr["is_start"].ToString().Trim() != "") _is_start = Int32.Parse(dr["is_start"].ToString().Trim());
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
		/// 选项编号
		/// </summary>
		[RemarkAttribute(Remark = "选项编号")]
		public int DictionaryChildId
		{
			set{ _dictionary_child_id=value;}
			get{return _dictionary_child_id;}
		}
		/// <summary>
		/// 选项名称
		/// </summary>
		[RemarkAttribute(Remark = "选项名称")]
		public string DictionaryChildName
		{
			set{ _dictionary_child_name=value;}
			get{return _dictionary_child_name;}
		}
		/// <summary>
		/// 所属字典（引用字典表，用于判断此选项属于哪一类字典）
		/// </summary>
		[RemarkAttribute(Remark = "所属字典（引用字典表，用于判断此选项属于哪一类字典）")]
		public int DictionaryId
		{
			set{ _dictionary_id=value;}
			get{return _dictionary_id;}
		}
		/// <summary>
		/// 所属父级
		/// </summary>
		[RemarkAttribute(Remark = "所属父级")]
		public int ParentDictionaryChildId
		{
			set{ _parent_dictionary_child_id=value;}
			get{return _parent_dictionary_child_id;}
		}
		/// <summary>
		/// 是否启用（1：是；0：否）
		/// </summary>
		[RemarkAttribute(Remark = "是否启用（1：是；0：否）")]
		public int IsStart
		{
			set{ _is_start=value;}
			get{return _is_start;}
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
