using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    public class Sdl_Sweight
    {
        public Sdl_Sweight()
        {

        }
       
        /// <summary>
        /// ID
        /// </summary>
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string iD = string.Empty;

        /// <summary>
        /// SWEIGHT
        /// </summary>
        public string SWEIGHT
        {
            get { return sWEIGHT; }
            set { sWEIGHT = value; }
        }
        private string sWEIGHT = string.Empty;

        public string STEXT
        {
            get { return sTEXT; }
            set { sTEXT = value; }
        }
        private string sTEXT = string.Empty;
    }
}
