using System;
namespace Model
{
	/// <summary>
	/// Page:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserPage
	{
        public UserPage()
		{}
		#region Model
		private int _id;
		private string _text;
		private int  _no;
		private string _comment;
		private string _url;
		private string _imageurl;
		private int  _mark;
		private int  _showmark;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
		public int  NO
		{
			set{ _no=value;}
			get{return _no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
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
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ShowMark
		{
			set{ _showmark=value;}
			get{return _showmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}
		#endregion Model

	}
}

