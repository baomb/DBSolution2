using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Feedback
    {
        /// <summary>
        /// 反馈ID
        /// </summary>
        public int ID
        {
            set
            {
                iD = value;
            }
            get
            {
                return iD;
            }
        }
        private int iD = 0;


        /// <summary>
        /// 反馈时间
        /// </summary>
        public SqlDateTime DATETIME
        {
            set
            {
                dATETIME = value;
            }
            get
            {
                return dATETIME;
            }
        }
        private SqlDateTime dATETIME = SqlDateTime.MinValue;


        /// <summary>
        /// 回复时间
        /// </summary>
        public SqlDateTime RESPTIME
        {
            set
            {
                rESPTIME = value;
            }
            get
            {
                return rESPTIME;
            }
        }
        private SqlDateTime rESPTIME = SqlDateTime.MinValue;


        /// <summary>
        /// 处理完毕
        /// </summary>
        public bool RESULT
        {
            set
            {
                rESULT = value;
            }
            get
            {
                return rESULT;
            }
        }
        private bool rESULT = false;


        /// <summary>
        /// 是否解决
        /// </summary>
        public bool RESOLVED
        {
            set
            {
                rESOLVED = value;
            }
            get
            {
                return rESOLVED;
            }
        }
        private bool rESOLVED = false;


        /// <summary>
        /// 反馈用户
        /// </summary>
        public string USERNAME
        {
            set
            {
                uSERNAME = value;
            }
            get
            {
                return uSERNAME;
            }
        }
        private string uSERNAME = string.Empty;


        /// <summary>
        /// 反馈标题
        /// </summary>
        public string TITLE
        {
            set
            {
                tITLE = value;
            }
            get
            {
                return tITLE;
            }
        }
        private string tITLE = string.Empty;


        /// <summary>
        /// 反馈建议
        /// </summary>
        public string COMMENT
        {
            set
            {
                cOMMENT = value;
            }
            get
            {
                return cOMMENT;
            }
        }
        private string cOMMENT = string.Empty;


        /// <summary>
        /// 处理反馈
        /// </summary>
        public string RESPONSE
        {
            set
            {
                rESPONSE = value;
            }
            get
            {
                return rESPONSE;
            }
        }
        private string rESPONSE = string.Empty;


        /// <summary>
        /// 处理反馈
        /// </summary>
        public string RESPNAME
        {
            set
            {
                rESPNAME = value;
            }
            get
            {
                return rESPNAME;
            }
        }
        private string rESPNAME = string.Empty;
    }
}
