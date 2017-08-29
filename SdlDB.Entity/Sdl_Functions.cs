using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_Functions
    {
        /// <summary>
        /// 功能ID
        /// </summary>
        public string FUNCTIONID
        {
            set
            {
                fUNCTIONID = value;
            }
            get
            {
                return fUNCTIONID;
            }
        }
        private string fUNCTIONID = string.Empty;


        /// <summary>
        /// 功能名称
        /// </summary>
        public string FUNCTIONNAME
        {
            set
            {
                fUNCTIONNAME = value;
            }
            get
            {
                return fUNCTIONNAME;
            }
        }
        private string fUNCTIONNAME = string.Empty;


        /// <summary>
        /// 功能描述
        /// </summary>
        public string FUNCTIONDESC
        {
            set
            {
                fUNCTIONDESC = value;
            }
            get
            {
                return fUNCTIONDESC;
            }
        }
        private string fUNCTIONDESC = string.Empty;


        /// <summary>
        /// 功能键值
        /// </summary>
        public string FUNCTIONKEY
        {
            set
            {
                fUNCTIONKEY = value;
            }
            get
            {
                return fUNCTIONKEY;
            }
        }
        private string fUNCTIONKEY = string.Empty;

        /// <summary>
        /// 父键值
        /// </summary>
        public string FUNCTIONPARENT
        {
            set
            {
                fUNCTIONPARENT = value;
            }
            get
            {
                return fUNCTIONPARENT;
            }
        }
        private string fUNCTIONPARENT = string.Empty;
    }
}