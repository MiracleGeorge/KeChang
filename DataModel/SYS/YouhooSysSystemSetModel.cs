using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysSystemSetModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016-11-8 20:21:49
	/// </summary>
	[Serializable]
	public class YouhooSysSystemSetModel
	{
		public YouhooSysSystemSetModel()
		{
			_system_set_id = 0;
		}

		#region Model
		private int _system_set_id;
		private string _system_set_name;
		private string _system_set_hou_logo;
		private string _system_set_login_biaozhi;
		private string _system_set_icon;
		private string _initial_pwd;
		private int _list_show_count;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysSystemSetModel(DataRow dr)
		{
			if (dr["system_set_id"] != null && dr["system_set_id"].ToString().Trim() != "") _system_set_id = Int32.Parse(dr["system_set_id"].ToString().Trim());
			if (dr["system_set_name"] != null) _system_set_name = dr["system_set_name"].ToString().Trim();
			if (dr["system_set_hou_logo"] != null) _system_set_hou_logo = dr["system_set_hou_logo"].ToString().Trim();
			if (dr["system_set_login_biaozhi"] != null) _system_set_login_biaozhi = dr["system_set_login_biaozhi"].ToString().Trim();
			if (dr["system_set_icon"] != null) _system_set_icon = dr["system_set_icon"].ToString().Trim();
			if (dr["initial_pwd"] != null) _initial_pwd = dr["initial_pwd"].ToString().Trim();
			if (dr["list_show_count"] != null && dr["list_show_count"].ToString().Trim() != "") _list_show_count = Int32.Parse(dr["list_show_count"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// ID
		/// </summary>
		public int SystemSetId
		{
			set{ _system_set_id=value;}
			get{return _system_set_id;}
		}
		/// <summary>
		/// ϵͳ����
		/// </summary>
		public string SystemSetName
		{
			set{ _system_set_name=value;}
			get{return _system_set_name;}
		}
		/// <summary>
		/// ϵͳlogo
		/// </summary>
		public string SystemSetHouLogo
		{
			set{ _system_set_hou_logo=value;}
			get{return _system_set_hou_logo;}
		}
		/// <summary>
		/// ϵͳ��½ҳ��ʶ
		/// </summary>
		public string SystemSetLoginBiaozhi
		{
			set{ _system_set_login_biaozhi=value;}
			get{return _system_set_login_biaozhi;}
		}
		/// <summary>
		/// ϵͳͼ��
		/// </summary>
		public string SystemSetIcon
		{
			set{ _system_set_icon=value;}
			get{return _system_set_icon;}
		}
		/// <summary>
		/// ��ʼ����
		/// </summary>
		public string InitialPwd
		{
			set{ _initial_pwd=value;}
			get{return _initial_pwd;}
		}
		/// <summary>
		/// �б���ʾ����
		/// </summary>
		public int ListShowCount
		{
			set{ _list_show_count=value;}
			get{return _list_show_count;}
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
