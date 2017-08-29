using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_DataHistory
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        public string EditTime
        {
            set
            {
                editTime = value;
            }
            get
            {
                return editTime;
            }
        }
        private string editTime = string.Empty;

        /// <summary>
        /// 模块
        /// </summary>
        public string Module
        {
            set
            {
                module = value;
            }
            get
            {
                return module;
            }
        }
        private string module = string.Empty;

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            set
            {
                tableName = value;
            }
            get
            {
                return tableName;
            }
        }
        private string tableName = string.Empty;

        /// <summary>
        /// 字段
        /// </summary>
        public string Field
        {
            set
            {
                field = value;
            }
            get
            {
                return field;
            }
        }
        private string field = string.Empty;

        /// <summary>
        /// 旧值
        /// </summary>
        public string OldValue
        {
            set
            {
                oldValue = value;
            }
            get
            {
                return oldValue;
            }
        }
        private string oldValue = string.Empty;

        /// <summary>
        /// 列1
        /// </summary>
        public string Col1
        {
            set
            {
                col1 = value;
            }
            get
            {
                return col1;
            }
        }
        private string col1 = string.Empty;

        /// <summary>
        /// 列2
        /// </summary>
        public string Col2
        {
            set
            {
                col2 = value;
            }
            get
            {
                return col2;
            }
        }
        private string col2 = string.Empty;

        /// <summary>
        /// 列3
        /// </summary>
        public string Col3
        {
            set
            {
                col3 = value;
            }
            get
            {
                return col3;
            }
        }
        private string col3 = string.Empty;

        /// <summary>
        /// 列4
        /// </summary>
        public string Col4
        {
            set
            {
                col4 = value;
            }
            get
            {
                return col4;
            }
        }
        private string col4 = string.Empty;

        /// <summary>
        /// 列5
        /// </summary>
        public string Col5
        {
            set
            {
                col5 = value;
            }
            get
            {
                return col5;
            }
        }
        private string col5 = string.Empty;

        /// <summary>
        /// 列5
        /// </summary>
        public string Col6
        {
            set
            {
                col6 = value;
            }
            get
            {
                return col6;
            }
        }
        private string col6 = string.Empty;

        /// <summary>
        /// 列字段
        /// </summary>
        public string ColField
        {
            set
            {
                colField = value;
            }
            get
            {
                return colField;
            }
        }
        private string colField = string.Empty;

        /// <summary>
        /// 新值
        /// </summary>
        public string NewValue
        {
            set
            {
                newValue = value;
            }
            get
            {
                return newValue;
            }
        }
        private string newValue = string.Empty;

        /// <summary>
        /// 修改时间
        /// </summary>
        public SqlDateTime Time
        {
            set
            {
                time = value;
            }
            get
            {
                return time;
            }
        }
        private SqlDateTime time = SqlDateTime.MinValue;

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteFlag
        {
            set
            {
                deleteFlag = value;
            }
            get
            {
                return deleteFlag;
            }
        }
        private bool deleteFlag = false;

        /// <summary>
        /// 添加标识
        /// </summary>
        public bool InsertFlag
        {
            set
            {
                insertFlag = value;
            }
            get
            {
                return insertFlag;
            }
        }
        private bool insertFlag = false;

        /// <summary>
        /// 修改标识
        /// </summary>
        public bool EditFlag
        {
            set
            {
                editFlag = value;
            }
            get
            {
                return editFlag;
            }
        }
        private bool editFlag = false;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set
            {
                userName = value;
            }
            get
            {
                return userName;
            }
        }
        private string userName = string.Empty;

        /// <summary>
        /// 随机值
        /// </summary>
        public string Random
        {
            set
            {
                random = value;
            }
            get
            {
                return random;
            }
        }
        private string random = string.Empty;
    }
}
