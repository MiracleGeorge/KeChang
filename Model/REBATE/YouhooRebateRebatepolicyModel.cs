using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooRebateRebatepolicyModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2017/4/5 23:45:03
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
		private int _brand_id;
		private int? _channel_id;
		private int? _item_id;
		private int? _price_id;
		private int? _region_id;
		private int? _sort_id_id;
		private int? _SupportWay_id;
		private int? _SupportPrice_id;
		private int? _RebateType_id;
		private int? _time_id;
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
			if (dr["brand_id"] != null && dr["brand_id"].ToString().Trim() != "") _brand_id = Int32.Parse(dr["brand_id"].ToString().Trim());
			if (dr["channel_id"] != null && dr["channel_id"].ToString().Trim() != "") _channel_id = Int32.Parse(dr["channel_id"].ToString().Trim());
			if (dr["item_id"] != null && dr["item_id"].ToString().Trim() != "") _item_id = Int32.Parse(dr["item_id"].ToString().Trim());
			if (dr["price_id"] != null && dr["price_id"].ToString().Trim() != "") _price_id = Int32.Parse(dr["price_id"].ToString().Trim());
			if (dr["region_id"] != null && dr["region_id"].ToString().Trim() != "") _region_id = Int32.Parse(dr["region_id"].ToString().Trim());
			if (dr["sort_id_id"] != null && dr["sort_id_id"].ToString().Trim() != "") _sort_id_id = Int32.Parse(dr["sort_id_id"].ToString().Trim());
			if (dr["SupportWay_id"] != null && dr["SupportWay_id"].ToString().Trim() != "") _SupportWay_id = Int32.Parse(dr["SupportWay_id"].ToString().Trim());
			if (dr["SupportPrice_id"] != null && dr["SupportPrice_id"].ToString().Trim() != "") _SupportPrice_id = Int32.Parse(dr["SupportPrice_id"].ToString().Trim());
			if (dr["RebateType_id"] != null && dr["RebateType_id"].ToString().Trim() != "") _RebateType_id = Int32.Parse(dr["RebateType_id"].ToString().Trim());
			if (dr["time_id"] != null && dr["time_id"].ToString().Trim() != "") _time_id = Int32.Parse(dr["time_id"].ToString().Trim());
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
		/// �������߱���
		/// </summary>
		public string Code
		{
			set{ _Code=value;}
			get{return _Code;}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		/// <summary>
		/// Ʒ��
		/// </summary>
		public int BrandId
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? ChannelId
		{
			set{ _channel_id=value;}
			get{return _channel_id;}
		}
		/// <summary>
		/// Ʒ��
		/// </summary>
		public int? ItemId
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// �۸�
		/// </summary>
		public int? PriceId
		{
			set{ _price_id=value;}
			get{return _price_id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? RegionId
		{
			set{ _region_id=value;}
			get{return _region_id;}
		}
		/// <summary>
		/// Ʒ��
		/// </summary>
		public int? SortIdId
		{
			set{ _sort_id_id=value;}
			get{return _sort_id_id;}
		}
		/// <summary>
		/// ֧�ַ�ʽ
		/// </summary>
		public int? SupportwayId
		{
			set{ _SupportWay_id=value;}
			get{return _SupportWay_id;}
		}
		/// <summary>
		/// ֧�ּ۸�
		/// </summary>
		public int? SupportpriceId
		{
			set{ _SupportPrice_id=value;}
			get{return _SupportPrice_id;}
		}
		/// <summary>
		/// ������ʽ
		/// </summary>
		public int? RebatetypeId
		{
			set{ _RebateType_id=value;}
			get{return _RebateType_id;}
		}
		/// <summary>
		/// ʱ��
		/// </summary>
		public int? TimeId
		{
			set{ _time_id=value;}
			get{return _time_id;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// �߼�״̬��1�����ڣ�0�������ڣ�
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string Createoperator
		{
			set{ _createoperator=value;}
			get{return _createoperator;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? Createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// �޸���
		/// </summary>
		public string Updateoperator
		{
			set{ _updateoperator=value;}
			get{return _updateoperator;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public DateTime? Updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model
	}
}
