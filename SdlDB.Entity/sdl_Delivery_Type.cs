using System;
using System.Data;

namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_Delivery_Type 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_Delivery_Type
    {
        public Sdl_Delivery_Type()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 
        /// </summary>
        public string VKORG
        {
            set
            {
                vKORG = value;
            }
            get
            {
                return vKORG;
            }
        }
        private string vKORG = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string VTWEG
        {
            set
            {
                vTWEG = value;
            }
            get
            {
                return vTWEG;
            }
        }
        private string vTWEG = string.Empty;


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
        public string ZTEXT
        {
            set
            {
                zTEXT = value;
            }
            get
            {
                return zTEXT;
            }
        }
        private string zTEXT = string.Empty;


    }
}