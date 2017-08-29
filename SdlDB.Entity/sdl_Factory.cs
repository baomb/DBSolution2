using System;
using System.Data;
namespace SdlDB.Entity
{
    /// <summary>
    /// sdl_Factory 的摘要说明
    /// </summary>
    [Serializable()]
    public class Sdl_Factory
    {
        public Sdl_Factory()
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
        /// 
        /// </summary>
        public string NAME1
        {
            set
            {
                nAME1 = value;
            }
            get
            {
                return nAME1;
            }
        }
        private string nAME1 = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ZBUKRS
        {
            set
            {
                zBUKRS = value;
            }
            get
            {
                return zBUKRS;
            }
        }
        private string zBUKRS = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ZWERKS
        {
            set
            {
                zWERKS = value;
            }
            get
            {
                return zWERKS;
            }
        }
        private string zWERKS = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string ZLGORT
        {
            set
            {
                zLGORT = value;
            }
            get
            {
                return zLGORT;
            }
        }
        private string zLGORT = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string ZLGOBE
        {
            set
            {
                zLGOBE = value;
            }
            get
            {
                return zLGOBE;
            }
        }
        private string zLGOBE = string.Empty;

    }
}