using System;
namespace Model
{
	/// <summary>
	/// S_Tree:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_Tree
	{
		public S_Tree()
		{}
		#region Model
		private int _nodeid;
		private string _text;
		private int _parentid;
		private string _parentpath;
		private string _location;
		private int   _orderid;
		private string _comment;
		private string _url;
		private int   _permissionid;
		private string _imageurl;
		private int   _moduleid;
		private int   _keshidm;
		private string _keshipublic;
		/// <summary>
		/// 
		/// </summary>
		public int NodeID
		{
			set{ _nodeid=value;}
			get{return _nodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Text
		{
			set{ _text=value;}
			get{return _text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentPath
		{
			set{ _parentpath=value;}
			get{return _parentpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int   OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int   PermissionID
		{
			set{ _permissionid=value;}
			get{return _permissionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int   ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int   KeShiDM
		{
			set{ _keshidm=value;}
			get{return _keshidm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeshiPublic
		{
			set{ _keshipublic=value;}
			get{return _keshipublic;}
		}
		#endregion Model

	}
}

