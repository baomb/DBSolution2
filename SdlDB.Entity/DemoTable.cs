using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    public class DemoTable
    {
        public DemoTable()
        {
            
        }
        private int id;
        private string name;
        private DateTime input_Date;

        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        public DateTime Input_Date
        {
            get { return input_Date; }
            set { input_Date = value; }
        }
    }
}
