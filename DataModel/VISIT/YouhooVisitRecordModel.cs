using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooVisitRecordModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2017/4/25 17:35:22
	/// </summary>
	[Serializable]
	public class YouhooVisitRecordModel
	{
		public YouhooVisitRecordModel()
		{
			_visit_id = 0;
		}

		#region Model
		private int _visit_id;
		private string _cCusName;
		private string _cCusAbbName;
		private string _cCusCode;
		private string _phoneNumber;
		private string _cCusPerson;
		private DateTime _visit_date;
		private string _visit_location;
		private string _visit_person;
		private DateTime _visit_startTime;
		private DateTime _visit_endTime;
		private int? _visit_way_id;
		private string _visit_content;
		private string _visit_NextPlan;
		private string _visit_ManagerOpinion;
		private int _verifi_state;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooVisitRecordModel(DataRow dr)
		{
			if (dr["visit_id"] != null && dr["visit_id"].ToString().Trim() != "") _visit_id = Int32.Parse(dr["visit_id"].ToString().Trim());
			if (dr["cCusName"] != null) _cCusName = dr["cCusName"].ToString().Trim();
			if (dr["cCusAbbName"] != null) _cCusAbbName = dr["cCusAbbName"].ToString().Trim();
			if (dr["cCusCode"] != null) _cCusCode = dr["cCusCode"].ToString().Trim();
			if (dr["phoneNumber"] != null) _phoneNumber = dr["phoneNumber"].ToString().Trim();
			if (dr["cCusPerson"] != null) _cCusPerson = dr["cCusPerson"].ToString().Trim();
			if (dr["visit_date"] != null && dr["visit_date"].ToString().Trim() != "") _visit_date = DateTime.Parse(dr["visit_date"].ToString().Trim());
			if (dr["visit_location"] != null) _visit_location = dr["visit_location"].ToString().Trim();
			if (dr["visit_person"] != null) _visit_person = dr["visit_person"].ToString().Trim();
			if (dr["visit_startTime"] != null && dr["visit_startTime"].ToString().Trim() != "") _visit_startTime = DateTime.Parse(dr["visit_startTime"].ToString().Trim());
			if (dr["visit_endTime"] != null && dr["visit_endTime"].ToString().Trim() != "") _visit_endTime = DateTime.Parse(dr["visit_endTime"].ToString().Trim());
			if (dr["visit_way_id"] != null && dr["visit_way_id"].ToString().Trim() != "") _visit_way_id = Int32.Parse(dr["visit_way_id"].ToString().Trim());
			if (dr["visit_content"] != null) _visit_content = dr["visit_content"].ToString().Trim();
			if (dr["visit_NextPlan"] != null) _visit_NextPlan = dr["visit_NextPlan"].ToString().Trim();
			if (dr["visit_ManagerOpinion"] != null) _visit_ManagerOpinion = dr["visit_ManagerOpinion"].ToString().Trim();
			if (dr["verifi_state"] != null && dr["verifi_state"].ToString().Trim() != "") _verifi_state = Int32.Parse(dr["verifi_state"].ToString().Trim());
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
		public int VisitId
		{
			set{ _visit_id=value;}
			get{return _visit_id;}
		}
		/// <summary>
		/// �ͻ�����
		/// </summary>
		public string Ccusname
		{
			set{ _cCusName=value;}
			get{return _cCusName;}
		}
		/// <summary>
		/// �ͻ����
		/// </summary>
		public string Ccusabbname
		{
			set{ _cCusAbbName=value;}
			get{return _cCusAbbName;}
		}
		/// <summary>
		/// �ͻ�����
		/// </summary>
		public string Ccuscode
		{
			set{ _cCusCode=value;}
			get{return _cCusCode;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string Phonenumber
		{
			set{ _phoneNumber=value;}
			get{return _phoneNumber;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Ccusperson
		{
			set{ _cCusPerson=value;}
			get{return _cCusPerson;}
		}
		/// <summary>
		/// �ݷ�����
		/// </summary>
		public DateTime VisitDate
		{
			set{ _visit_date=value;}
			get{return _visit_date;}
		}
		/// <summary>
		/// ��̸�ص�
		/// </summary>
		public string VisitLocation
		{
			set{ _visit_location=value;}
			get{return _visit_location;}
		}
		/// <summary>
		/// ��̸��
		/// </summary>
		public string VisitPerson
		{
			set{ _visit_person=value;}
			get{return _visit_person;}
		}
		/// <summary>
		/// ��̸��ʼʱ��
		/// </summary>
		public DateTime VisitStarttime
		{
			set{ _visit_startTime=value;}
			get{return _visit_startTime;}
		}
		/// <summary>
		/// ��̸����ʱ��
		/// </summary>
		public DateTime VisitEndtime
		{
			set{ _visit_endTime=value;}
			get{return _visit_endTime;}
		}
		/// <summary>
		/// ��̸��ʽid
		/// </summary>
		public int? VisitWayId
		{
			set{ _visit_way_id=value;}
			get{return _visit_way_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VisitContent
		{
			set{ _visit_content=value;}
			get{return _visit_content;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string VisitNextplan
		{
			set{ _visit_NextPlan=value;}
			get{return _visit_NextPlan;}
		}
		/// <summary>
		/// ���ܽ���
		/// </summary>
		public string VisitManageropinion
		{
			set{ _visit_ManagerOpinion=value;}
			get{return _visit_ManagerOpinion;}
		}
		/// <summary>
		/// ���״̬ 0��Ϊ�� 1������
		/// </summary>
		public int VerifiState
		{
			set{ _verifi_state=value;}
			get{return _verifi_state;}
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
