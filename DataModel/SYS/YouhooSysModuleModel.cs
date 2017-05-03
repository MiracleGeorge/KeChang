using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysModuleModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016/9/24 17:41:42
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
		/// ģ����
		/// </summary>
		[RemarkAttribute(Remark = "ģ����")]
		public int ModuleId
		{
			set{ _module_id=value;}
			get{return _module_id;}
		}
		/// <summary>
		/// ģ������
		/// </summary>
		[RemarkAttribute(Remark = "ģ������")]
		public string ModuleName
		{
			set{ _module_name=value;}
			get{return _module_name;}
		}
		/// <summary>
		/// ����ģ��id
		/// </summary>
		[RemarkAttribute(Remark = "����ģ��id")]
		public int ParentmoduleId
		{
			set{ _parentmodule_id=value;}
			get{return _parentmodule_id;}
		}
		/// <summary>
		/// ģ�����ӵ�ַ
		/// </summary>
		[RemarkAttribute(Remark = "ģ�����ӵ�ַ")]
		public string ModuleUrl
		{
			set{ _module_url=value;}
			get{return _module_url;}
		}
		/// <summary>
		/// ��ʶ���
		/// </summary>
		[RemarkAttribute(Remark = "��ʶ���")]
		public string ModuleValue
		{
			set{ _module_value=value;}
			get{return _module_value;}
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
