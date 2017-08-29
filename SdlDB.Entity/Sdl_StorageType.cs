using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_StorageType
    {
        
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TYPENAME
        {
            set
            {
                tYPENAME = value;
            }
            get
            {
                return tYPENAME;
            }
        }
        private string tYPENAME = string.Empty;


        /// <summary>
        /// 类型描述
        /// </summary>
        public string TYPEDESC
        {
            set
            {
               tYPEDESC = value;
            }
            get
            {
                return tYPEDESC;
            }
        }
        private string tYPEDESC = string.Empty;


        //类型ID
        public int TYPEID
        {
            set
            {
                tYPEID = value;
            }
            get
            {
                return tYPEID;
            }
        }
        private int tYPEID = 0;
    }
}