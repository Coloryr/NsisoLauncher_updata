using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsisoLauncher_updata.Properties
{
    class mod_md5
    {
        class mod_obj
        {
            /// <summary>
            /// MOD id
            /// </summary>
            public string modid { get; set; }
            /// <summary>
            /// 名字
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 版本
            /// </summary>
            public string version { get; set; }
            /// <summary>
            /// MC版本
            /// </summary>
            public string mcversion { get; set; }
            /// <summary>
            /// 网址
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 更新网站
            /// </summary>
            public string updateUrl { get; set; }
            /// <summary>
            /// 作者列表
            /// </summary>
            public List<string> authorList { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string credits { get; set; }
            /// <summary>
            /// 日志文件
            /// </summary>
            public string logoFile { get; set; }
            /// <summary>
            /// 截图
            /// </summary>
            public List<string> screenshots { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public List<string> dependencies { get; set; }
        }
        public List<updata_mod> ReadModInfo(string path)
        {
            if (!Directory.Exists(path + @"\mods\"))
            {
                return null;
            }
            string[] files = Directory.GetFiles(path + @"\mods\", "*.jar");
            List<updata_mod> list = new List<updata_mod>();
            foreach (string file in files)
            {
                foreach (updata_mod save in GetModsInfo(path, file))
                {
                    if (list.Contains(save) == false)
                        list.Add(save);
                }
            }
            return list;
        }
        public List<updata_mod> GetModsInfo(string path, string fileName)
        {
            List<updata_mod> mods = new List<updata_mod>();
            try
            {
                ZipFile zip = new ZipFile(fileName);
                ZipEntry zp = zip.GetEntry("mcmod.info");
                if (zp == null)
                {
                    mods.Add(new updata_mod
                    {
                        name = fileName.Replace(path + @"mods\", "")
                    });
                    return mods;
                }
                Stream stream = zip.GetInputStream(zp);
                TextReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                zip.Close();
                stream.Close();
                foreach (JToken modinfo in JArray.Parse(text))
                {
                    var b = modinfo.ToObject<mod_obj>();
                    MD5 md5 = new MD5CryptoServiceProvider();//创建SHA1对象
                    byte[] md5Bytes = md5.ComputeHash(new FileStream(fileName, FileMode.Open));//Hash运算
                    md5.Dispose();//释放当前实例使用的所有资源
                    if (b.modid != null)
                    {
                        mods.Add(new updata_mod
                        {
                            name = b.name,
                            vision = b.version,
                            check = BitConverter.ToString(md5Bytes)
                        });
                    }
                }
                return mods;
            }
            catch (Exception e)
            {
                mods.Add(new updata_mod
                {
                    name = fileName.Replace(path + @"mods\", "")
                });
                return mods;
            }
        }
    }
}
