/*----------------------------------------------------------------
 * 作者：谭小峰
 * 时间：2010-10-29
 * ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource
{
    /// <summary>
    ///  指定该属性是否是Table中的主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// 是否是主键
        /// </summary>
        private bool _isprimary;
        /// <summary>
        /// 是否自增长
        /// </summary>
        private bool _isidentity;
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimary
        {
            get { return _isprimary; }
            set { _isprimary = value; }
        }
        /// <summary>
        /// 是否自增长
        /// </summary>
        public bool IsIdentity
        {
            get { return _isidentity; }
            set { _isidentity = value; }
        }
        public string NickName { set; get; }

        public ColumnAttribute()
        {
            IsPrimary = false;
            IsIdentity = false;
        }

    }
}
