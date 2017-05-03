using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysDictionaryModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016/9/24 17:41:40
	/// </summary>
	[Serializable]
	public class YouhooSysDictionaryModel
	{
		public YouhooSysDictionaryModel()
		{
			_dictionary_id = 0;
		}

		#region Model
		private int _dictionary_id;
		private string _dictionary_name;
		private int _is_multilayer;
		private int _sort;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysDictionaryModel(DataRow dr)
		{
			if (dr["dictionary_id"] != null && dr["dictionary_id"].ToString().Trim() != "") _dictionary_id = Int32.Parse(dr["dictionary_id"].ToString().Trim());
			if (dr["dictionary_name"] != null) _dictionary_name = dr["dictionary_name"].ToString().Trim();
			if (dr["is_multilayer"] != null && dr["is_multilayer"].ToString().Trim() != "") _is_multilayer = Int32.Parse(dr["is_multilayer"].ToString().Trim());
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
		/// �ֵ���
		/// </summary>
		[RemarkAttribute(Remark = "�ֵ���")]
		public int DictionaryId
		{
			set{ _dictionary_id=value;}
			get{return _dictionary_id;}
		}
		/// <summary>
		/// �ֵ�����
		/// </summary>
		[RemarkAttribute(Remark = "�ֵ�����")]
		public string DictionaryName
		{
			set{ _dictionary_name=value;}
			get{return _dictionary_name;}
		}
		/// <summary>
		/// �Ƿ�Ϊ��㼶�ṹ��1���ǣ�0����
		/// </summary>
		[RemarkAttribute(Remark = "�Ƿ�Ϊ��㼶�ṹ��1���ǣ�0����")]
		public int IsMultilayer
		{
			set{ _is_multilayer=value;}
			get{return _is_multilayer;}
		}
		/// <summary>
		/// ����
		/// </summary>
		[RemarkAttribute(Remark = "����")]
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		[RemarkAttribute(Remark = "��ע")]
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// �߼�״̬��1�����ڣ�0�������ڣ�
		/// </summary>
		[RemarkAttribute(Remark = "�߼�״̬��1�����ڣ�0�������ڣ�")]
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		[RemarkAttribute(Remark = "������ID")]
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		[RemarkAttribute(Remark = "������")]
		public string Createoperator
		{
			set{ _createoperator=value;}
			get{return _createoperator;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		[RemarkAttribute(Remark = "����ʱ��")]
		public DateTime? Createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// �޸���
		/// </summary>
		[RemarkAttribute(Remark = "�޸���")]
		public string Updateoperator
		{
			set{ _updateoperator=value;}
			get{return _updateoperator;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		[RemarkAttribute(Remark = "�޸�ʱ��")]
		public DateTime? Updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model
	}
}
