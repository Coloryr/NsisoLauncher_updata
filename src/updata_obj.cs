using System.Collections.Generic;

namespace NsisoLauncher_updata
{
    public class server_info
    { 
        /// <summary>
        /// 更新的网址根目录
        /// </summary>
        public static string server_local { get; set; }
    }
    public class updata_obj
    {
        /// <summary>
        /// 整合包名字
        /// </summary>
        public string packname { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Vision { get; set; }
        /// <summary>
        /// mod列表
        /// </summary>
        public List<updata_mod> mods { get; set; }
    }

    public class updata_mod
    {
        /// <summary>
        /// mod名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string vision { get; set; }
        /// <summary>
        /// MD5
        /// </summary>
        public string check { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 本地地址
        /// </summary>
        public string local { get; set; }
    }
}
