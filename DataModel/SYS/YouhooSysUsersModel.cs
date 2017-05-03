using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysUsersModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016-11-10 11:28:27
	/// </summary>
	[Serializable]
	public class YouhooSysUsersModel
	{
		public YouhooSysUsersModel()
		{
			_user_id = 0;
		}

		#region Model
		private int _user_id;
		private string _usercode;
		private string _username;
		private string _password;
		private string _real_name;
		private int _StoreId;
		private int _departmentId;
		private string _phone;
		private string _tel;
		private string _email;
		private int _powergroup_id;
		private bool _IsSaleMan;
		private int _status;
		private string _remark;
		private int? _flag;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;
        private string _powergroup_value;

		public YouhooSysUsersModel(DataRow dr)
		{
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["usercode"] != null) _usercode = dr["usercode"].ToString().Trim();
			if (dr["username"] != null) _username = dr["username"].ToString().Trim();
			if (dr["password"] != null) _password = dr["password"].ToString().Trim();
			if (dr["real_name"] != null) _real_name = dr["real_name"].ToString().Trim();
			if (dr["StoreId"] != null && dr["StoreId"].ToString().Trim() != "") _StoreId = Int32.Parse(dr["StoreId"].ToString().Trim());
			if (dr["departmentId"] != null && dr["departmentId"].ToString().Trim() != "") _departmentId = Int32.Parse(dr["departmentId"].ToString().Trim());
			if (dr["phone"] != null) _phone = dr["phone"].ToString().Trim();
			if (dr["tel"] != null) _tel = dr["tel"].ToString().Trim();
			if (dr["email"] != null) _email = dr["email"].ToString().Trim();
			if (dr["powergroup_id"] != null && dr["powergroup_id"].ToString().Trim() != "") _powergroup_id = Int32.Parse(dr["powergroup_id"].ToString().Trim());
			if (dr["IsSaleMan"] != null && dr["IsSaleMan"].ToString().Trim() != "") _IsSaleMan = Boolean.Parse(dr["IsSaleMan"].ToString().Trim());
			if (dr["status"] != null && dr["status"].ToString().Trim() != "") _status = Int32.Parse(dr["status"].ToString().Trim());
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
            if (dr["powergroup_value"] != null) _powergroup_value = dr["powergroup_value"].ToString().Trim();
		}

		/// <summary>
		/// �û����
		/// </summary>
		public int UserId
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// �û����
		/// </summary>
		public string Usercode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string RealName
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// �����ŵ�
		/// </summary>
		public int Storeid
		{
			set{ _StoreId=value;}
			get{return _StoreId;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int Departmentid
		{
			set{ _departmentId=value;}
			get{return _departmentId;}
		}
		/// <summary>
		/// �ƶ��绰
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// ��ɫ��ţ�����Ȩ��������ڻ�ȡ�û���ɫ��Ϣ��
		/// </summary>
		public int PowergroupId
		{
			set{ _powergroup_id=value;}
			get{return _powergroup_id;}
		}
		/// <summary>
		/// �Ƿ�ҵ��Ա
		/// </summary>
		public bool Issaleman
		{
			set{ _IsSaleMan=value;}
			get{return _IsSaleMan;}
		}
		/// <summary>
		/// ״̬��0��������1�����ᣩ
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
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

        /// <summary>
        /// ��չ�ֶΣ�Ȩ����ֵ
        /// </summary>
        public string PowergroupValue
        {
            get { return _powergroup_value; }
            set { _powergroup_value = value; }
        }
		#endregion Model
	}
}
