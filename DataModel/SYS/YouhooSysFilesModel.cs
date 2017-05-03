using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YouHoo.DataTools;

namespace YouHoo.DataModel
{
	/// <summary>
	/// ʵ���ࣺYouhooSysFilesModel (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// ʱ�䣺2016/9/24 17:41:41
	/// </summary>
	[Serializable]
	public class YouhooSysFilesModel
	{
        public static string CacheName = "YouhooSysFilesDAL-";

		public YouhooSysFilesModel()
		{
			_file_id = 0;
		}

		#region Model
		private int _file_id;
		private int _table_id;
		private int _table_file_id;
		private string _file_name;
		private string _file_path;
		private string _file_size;
		private string _remark;
		private int? _flag;
		private int _user_id;
		private string _createoperator;
		private DateTime? _createdate;
		private string _updateoperator;
		private DateTime? _updatedate;

		public YouhooSysFilesModel(DataRow dr)
		{
			if (dr["file_id"] != null && dr["file_id"].ToString().Trim() != "") _file_id = Int32.Parse(dr["file_id"].ToString().Trim());
			if (dr["table_id"] != null && dr["table_id"].ToString().Trim() != "") _table_id = Int32.Parse(dr["table_id"].ToString().Trim());
			if (dr["table_file_id"] != null && dr["table_file_id"].ToString().Trim() != "") _table_file_id = Int32.Parse(dr["table_file_id"].ToString().Trim());
			if (dr["file_name"] != null) _file_name = dr["file_name"].ToString().Trim();
			if (dr["file_path"] != null) _file_path = dr["file_path"].ToString().Trim();
			if (dr["file_size"] != null) _file_size = dr["file_size"].ToString().Trim();
			if (dr["remark"] != null) _remark = dr["remark"].ToString().Trim();
			if (dr["flag"] != null && dr["flag"].ToString().Trim() != "") _flag = Int32.Parse(dr["flag"].ToString().Trim());
			if (dr["user_id"] != null && dr["user_id"].ToString().Trim() != "") _user_id = Int32.Parse(dr["user_id"].ToString().Trim());
			if (dr["createoperator"] != null) _createoperator = dr["createoperator"].ToString().Trim();
			if (dr["createdate"] != null && dr["createdate"].ToString().Trim() != "") _createdate = DateTime.Parse(dr["createdate"].ToString().Trim());
			if (dr["updateoperator"] != null) _updateoperator = dr["updateoperator"].ToString().Trim();
			if (dr["updatedate"] != null && dr["updatedate"].ToString().Trim() != "") _updatedate = DateTime.Parse(dr["updatedate"].ToString().Trim());
		}

		/// <summary>
		/// �ļ����
		/// </summary>
		[RemarkAttribute(Remark = "�ļ����")]
		public int FileId
		{
			set{ _file_id=value;}
			get{return _file_id;}
		}
		/// <summary>
		/// ��ID
		/// </summary>
		[RemarkAttribute(Remark = "��ID")]
		public int TableId
		{
			set{ _table_id=value;}
			get{return _table_id;}
		}
		/// <summary>
		/// ���¼ID
		/// </summary>
		[RemarkAttribute(Remark = "���¼ID")]
		public int TableFileId
		{
			set{ _table_file_id=value;}
			get{return _table_file_id;}
		}
		/// <summary>
		/// �ļ���
		/// </summary>
		[RemarkAttribute(Remark = "�ļ���")]
		public string FileName
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// �ļ�·��
		/// </summary>
		[RemarkAttribute(Remark = "�ļ�·��")]
		public string FilePath
		{
			set{ _file_path=value;}
			get{return _file_path;}
		}
		/// <summary>
		/// �ļ���С
		/// </summary>
		[RemarkAttribute(Remark = "�ļ���С")]
		public string FileSize
		{
			set{ _file_size=value;}
			get{return _file_size;}
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
