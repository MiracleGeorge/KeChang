using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// 实体类：YouhooRebateRebatepolicyModel (属性说明自动提取数据库字段的描述信息)
	/// 时间：2017/5/2 17:32:11
	/// </summary>
	[Serializable]
	public class YouhooRebateRebatepolicyModel
	{
		public YouhooRebateRebatepolicyModel()
		{
			_id = 0;
		}

		#region Model
		private int _id;
		private string _Code;
		private string _Name;
		private int? _channel_id;
		private decimal? _price;
		private int? _region_id;
		private int? _sort_id_id;
		private int? _PayWay_id;
		private int? _RebateType_id;
		private DateTime? _EndDate;
		private DateTime? _StartDate;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooRebateRebatepolicyModel(DataRow dr)
		{
			if (dr["id"] != null && dr["id"].ToString().Trim() != "") _id = Int32.Parse(dr["id"].ToString().Trim());
			if (dr["Code"] != null) _Code = dr["Code"].ToString().Trim();
			if (dr["Name"] != null) _Name = dr["Name"].ToString().Trim();
			if (dr["channel_id"] != null && dr["channel_id"].ToString().Trim() != "") _channel_id = Int32.Parse(dr["channel_id"].ToString().Trim());
			if (dr["price"] != null && dr["price"].ToString().Trim() != "") _price = decimal.Parse(dr["price"].ToString().Trim());
			if (dr["region_id"] != null && dr["region_id"].ToString().Trim() != "") _region_id = Int32.Parse(dr["region_id"].ToString().Trim());
			if (dr["sort_id_id"] != null && dr["sort_id_id"].ToString().Trim() != "") _sort_id_id = Int32.Parse(dr["sort_id_id"].ToString().Trim());
			if (dr["PayWay_id"] != null && dr["PayWay_id"].ToString().Trim() != "") _PayWay_id = Int32.Parse(dr["PayWay_id"].ToString().Trim());
			if (dr["RebateType_id"] != null && dr["RebateType_id"].ToString().Trim() != "") _RebateType_id = Int32.Parse(dr["RebateType_id"].ToString().Trim());
			if (dr["EndDate"] != null && dr["EndDate"].ToString().Trim() != "") _EndDate = DateTime.Parse(dr["EndDate"].ToString().Trim());
			if (dr["StartDate"] != null && dr["StartDate"].ToString().Trim() != "") _StartDate = DateTime.Parse(dr["StartDate"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 返利政策编码
		/// </summary>
		public string Code
		{
			set{ _Code=value;}
			get{return _Code;}
		}
		/// <summary>
		/// 返利政策名称
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		/// <summary>
		/// 渠道
		/// </summary>
		public int? ChannelId
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 地区
		/// </summary>
		public int? RegionId
		{
			set{ _region_id=value;}
			get{return _region_id;}
		}
		/// <summary>
		/// 品类
		/// </summary>
		public int? SortIdId
		{
			set{ _sort_id_id=value;}
			get{return _sort_id_id;}
		}
		/// <summary>
		/// 支持方式
		/// </summary>
		public int? PaywayId
		{
			set{ _PayWay_id=value;}
			get{return _PayWay_id;}
		}
		/// <summary>
		/// 返利方式
		/// </summary>
		public int? RebatetypeId
		{
			set{ _RebateType_id=value;}
			get{return _RebateType_id;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? Enddate
		{
			set{ _EndDate=value;}
			get{return _EndDate;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? Startdate
		{
			set{ _StartDate=value;}
			get{return _StartDate;}
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
