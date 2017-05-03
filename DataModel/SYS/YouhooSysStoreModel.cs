using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysStoreModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2017-03-02 9:52:28
	/// </summary>
	[Serializable]
	public class YouhooSysStoreModel
	{
		public YouhooSysStoreModel()
		{
			_Id = 0;
		}

		#region Model
		private int _Id;
		private string _Code;
		private string _SubCode;
		private string _SubName;
		private string _Name;
		private string _Phone;
		private string _PaymentTerm;
		private string _Adress;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysStoreModel(DataRow dr)
		{
			if (dr["Id"] != null && dr["Id"].ToString().Trim() != "") _Id = Int32.Parse(dr["Id"].ToString().Trim());
			if (dr["Code"] != null) _Code = dr["Code"].ToString().Trim();
			if (dr["SubCode"] != null) _SubCode = dr["SubCode"].ToString().Trim();
			if (dr["SubName"] != null) _SubName = dr["SubName"].ToString().Trim();
			if (dr["Name"] != null) _Name = dr["Name"].ToString().Trim();
			if (dr["Phone"] != null) _Phone = dr["Phone"].ToString().Trim();
			if (dr["PaymentTerm"] != null) _PaymentTerm = dr["PaymentTerm"].ToString().Trim();
			if (dr["Adress"] != null) _Adress = dr["Adress"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// ʵ���ұ�
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		/// <summary>
		/// ʵ���ұ��
		/// </summary>
		public string Code
		{
			set{ _Code=value;}
			get{return _Code;}
		}
		/// <summary>
		/// ����ʵ���Ҵ���
		/// </summary>
		public string Subcode
		{
			set{ _SubCode=value;}
			get{return _SubCode;}
		}
		/// <summary>
		/// ����ʵ��������
		/// </summary>
		public string Subname
		{
			set{ _SubName=value;}
			get{return _SubName;}
		}
		/// <summary>
		/// ʵ��������
		/// </summary>
		public string Name
		{
			set{ _Name=value;}
			get{return _Name;}
		}
		/// <summary>
		/// ʵ���ҵ绰
		/// </summary>
		public string Phone
		{
			set{ _Phone=value;}
			get{return _Phone;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Paymentterm
		{
			set{ _PaymentTerm=value;}
			get{return _PaymentTerm;}
		}
		/// <summary>
		/// ʵ���ҵ�ַ
		/// </summary>
		public string Adress
		{
			set{ _Adress=value;}
			get{return _Adress;}
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
