using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Manual
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string TYPE
        {
            set
            {
                tYPE = value;
            }
            get
            {
                return tYPE;
            }
        }
        private string tYPE = string.Empty;


        /// <summary>
        /// 操作说明
        /// </summary>
        public string MANUAL
        {
            set
            {
                mANUAL = value;
            }
            get
            {
                return mANUAL;
            }
        }
        private string mANUAL = string.Empty;
    }
}