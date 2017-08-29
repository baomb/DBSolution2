using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Users
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID
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
        private string iD = string.Empty;


        /// <summary>
        /// 用户名
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
        /// 用户角色
        /// </summary>
        public string ROLE
        {
            set
            {
                rOLE = value;
            }
            get
            {
                return rOLE;
            }
        }
        private string rOLE = string.Empty;


        /// <summary>
        /// 用户密码
        /// </summary>
        public string PASSWORD
        {
            set
            {
                pASSWORD = value;
            }
            get
            {
                return pASSWORD;
            }
        }
        private string pASSWORD = string.Empty;


        /// <summary>
        /// 用户描述
        /// </summary>
        public string USERDESC
        {
            set
            {
                uSERDESC = value;
            }
            get
            {
                return uSERDESC;
            }
        }
        private string uSERDESC = string.Empty;


        /// <summary>
        /// 状态
        /// </summary>
        public bool ISLOCKED
        {
            set
            {
                iSLOCKED = value;
            }
            get
            {
                return iSLOCKED;
            }
        }
        private bool iSLOCKED = false;


        /// <summary>
        /// 工厂
        /// </summary>
        public string WERKS
        {
            set
            {
                wERKS = value;
            }
            get
            {
                return wERKS;
            }
        }
        private string wERKS = string.Empty;


        /// <summary>
        /// 查询工厂
        /// </summary>
        public string QUERY
        {
            set
            {
                qUERY = value;
            }
            get
            {
                return qUERY;
            }
        }
        private string qUERY = string.Empty;
    }
}