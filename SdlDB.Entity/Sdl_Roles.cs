using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Roles
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public string ROLEID
        {
            set
            {
                rOLEID = value;
            }
            get
            {
                return rOLEID;
            }
        }
        private string rOLEID = string.Empty;


        /// <summary>
        /// 角色名称
        /// </summary>
        public string ROLENAME
        {
            set
            {
                rOLENAME = value;
            }
            get
            {
                return rOLENAME;
            }
        }
        private string rOLENAME = string.Empty;


        /// <summary>
        /// 角色描述
        /// </summary>
        public string ROLEDESC
        {
            set
            {
                rOLEDESC = value;
            }
            get
            {
                return rOLEDESC;
            }
        }
        private string rOLEDESC = string.Empty;
    }
}