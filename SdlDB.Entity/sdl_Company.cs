using System;
using System.Data;

namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_Company 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_Company
    {
        public Sdl_Company()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 
        /// </summary>
        public string BUKRS
        {
            set
            {
                bUKRS = value;
            }
            get
            {
                return bUKRS;
            }
        }
        private string bUKRS = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string BUTXT
        {
            set
            {
                bUTXT = value;
            }
            get
            {
                return bUTXT;
            }
        }
        private string bUTXT = string.Empty;


    }
}