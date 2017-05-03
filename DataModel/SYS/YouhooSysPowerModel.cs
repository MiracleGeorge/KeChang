using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysPowerModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016/9/24 17:41:42
	/// </summary>
	[Serializable]
	public class YouhooSysPowerModel
	{
		public YouhooSysPowerModel()
		{
			_power_id = 0;
		}

		#region Model
		private int _power_id;
		private int _module_id;
		private int _action_id;
		private string _power_value;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysPowerModel(DataRow dr)
		{
			if (dr["power_id"] != null && dr["power_id"].ToString().Trim() != "") _power_id = Int32.Parse(dr["power_id"].ToString().Trim());
			if (dr["module_id"] != null && dr["module_id"].ToString().Trim() != "") _module_id = Int32.Parse(dr["module_id"].ToString().Trim());
			if (dr["action_id"] != null && dr["action_id"].ToString().Trim() != "") _action_id = Int32.Parse(dr["action_id"].ToString().Trim());
			if (dr["power_value"] != null) _power_value = dr["power_value"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// Ȩ�ޱ��
		/// </summary>
		[RemarkAttribute(Remark = "Ȩ�ޱ��")]
		public int PowerId
		{
			set{ _power_id=value;}
			get{return _power_id;}
		}
		/// <summary>
		/// ģ����
		/// </summary>
		[RemarkAttribute(Remark = "ģ����")]
		public int ModuleId
		{
			set{ _module_id=value;}
			get{return _module_id;}
		}
		/// <summary>
		/// �������
		/// </summary>
		[RemarkAttribute(Remark = "�������")]
		public int ActionId
		{
			set{ _action_id=value;}
			get{return _action_id;}
		}
		/// <summary>
		/// ��ʶ���
		/// </summary>
		[RemarkAttribute(Remark = "��ʶ���")]
		public string PowerValue
		{
			set{ _power_value=value;}
			get{return _power_value;}
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
