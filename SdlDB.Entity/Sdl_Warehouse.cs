using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SdlDB.Entity
{
    public class Sdl_Warehouse
    {
        public Sdl_Warehouse()
        {

        }
        private string bukrs;
        private string werks;
        private string lgort;
        private string lgobe;
        private string house_Keeper;

        /// <summary>
        /// ID
        /// </summary>
        public string Bukrs
        {
            get { return bukrs; }
            set { bukrs = value; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Lgobe
        {
            get { return lgobe; }
            set { lgobe = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string House_Keeper
        {
            get { return house_Keeper; }
            set { house_Keeper = value; }
        }

      
    }
}
