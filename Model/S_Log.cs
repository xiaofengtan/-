using System;
namespace Model
{
	/// <summary>
	/// S_Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_Log
	{
		public S_Log()
		{}
		#region Model
		private int _id;
		private DateTime _datetime;
		private string _loginfo;
		private string _particular;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginfo
		{
			set{ _loginfo=value;}
			get{return _loginfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Particular
		{
			set{ _particular=value;}
			get{return _particular;}
		}
		#endregion Model

	}
}

