using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
namespace SdlDB.Entity
{
    [Serializable()]
    public class Sdl_FunctionsInRoles
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
        /// 功能ID
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
    }
}