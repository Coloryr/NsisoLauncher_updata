using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NsisoLauncher_updata.Check;
using NsisoLauncherCore.Util.Checker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsisoLauncher_updata
{
    public partial class Form1 : Form
    {
        public static UpdataOBJ UpdataOBJ { get; set; } = new UpdataOBJ();
        public static UpdataOBJ OldUpdata { get; set; } = new UpdataOBJ();
        public static List<string> get_ok = new List<string>();
        private bool is_busy = false;
        public Form1()
        {
            InitializeComponent();
            INFO.Text = "状态：等待操作";
        }

        private void listView_mods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReModsClick(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            string[] folders = Directory.GetDirectories(modsT.Text, ".minecraft");
            if (folders.Length == 0)
            {
                MessageBox.Show("选择的目录下没有.minecraft文件夹");
                return;
            }
            INFO.Text = "状态：更新列表中";
            Task.Factory.StartNew(() =>
            {
                is_busy = true;
                get_ok.Clear();
                try
                {
                    UpdataOBJ.mods = new ModCheck().ReadModInfo(modsT.Text);
                    UpdataOBJ.scripts = new ScriptsCheck().ReadscriptsInfo(modsT.Text);
                    UpdataOBJ.config = new OtherCheck().ReadOtherInfo(modsT.Text);
                    UpdataOBJ.resourcepacks = new ResourcepacksCheck().ReadresourcepacksInfo(modsT.Text);
                    UpdataOBJ.launch = new LaunchCheck().ReadLaunchrInfo(modsT.Text);
                    UpdataOBJ.self = new LaunchSelfCheck().ReadLaunchrSelfInfo(modsT.Text);
                    Action<int> action = (data) =>
                    {
                        listView_mods.Items.Clear();
                        if (UpdataOBJ.mods.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.mods.Values)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (UpdataOBJ.scripts.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.scripts)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (UpdataOBJ.config.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.config)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (UpdataOBJ.resourcepacks.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.resourcepacks)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (UpdataOBJ.launch.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.launch)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (UpdataOBJ.self.Count != 0)
                        {
                            foreach (UpdataItem save in UpdataOBJ.self)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        INFO.Text = "状态：等待操作";
                        new_mod.Text = "模组：" + (UpdataOBJ.mods.Count != 0 ? "" + UpdataOBJ.mods.Count : "无");
                        new_scripts.Text = "魔改：" + (UpdataOBJ.scripts.Count != 0 ? "" + UpdataOBJ.scripts.Count : "无");
                        new_resourcepacks.Text = "材质包：" + (UpdataOBJ.resourcepacks.Count != 0 ? "" + UpdataOBJ.resourcepacks.Count : "无");
                        int a = UpdataOBJ.config.Count + UpdataOBJ.launch.Count + UpdataOBJ.self.Count;
                        new_other.Text = "其他资源：" + (a != 0 ? "" + a : "无");
                    };
                    Invoke(action, 0);
                }
                catch (Exception exz)
                {
                    MessageBox.Show(exz.Message);
                }
                is_busy = false;
            });
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void ChoseModsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(modsT.Text))
                folderBrowserDialog1.SelectedPath = modsT.Text;
            folderBrowserDialog1.Description = "请选择游戏路径";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                modsT.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void GenJsonClick(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            INFO.Text = "状态：保存中";
            is_busy = true;
            saveFileDialog1.DefaultExt = UpdataOBJ.packname + @".json";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UpdataOBJ.packname = packname_t.Text;
                UpdataOBJ.Version = vision_t.Text;
                UpdataOBJ.LastVersion = LastVersion_t.Text;
                if (OldUpdata.mods != null)
                {
                    Dictionary<string, UpdataItem> temp = new Dictionary<string, UpdataItem>(OldUpdata.mods);
                    foreach (KeyValuePair<string, UpdataItem> new_item in UpdataOBJ.mods)
                    {
                        if (OldUpdata.mods.ContainsKey(new_item.Key))
                        {
                            temp.Remove(new_item.Key);
                        }
                    }
                    Dictionary<string, UpdataItem> temp1 = new Dictionary<string, UpdataItem>(temp);
                    if (temp1.Count != 0)
                    {
                        foreach (UpdataItem old_item in temp1.Values)
                        {
                            UpdataOBJ.mods.Add(old_item.name, new UpdataItem
                            {
                                name = old_item.name,
                                check = old_item.check,
                                type = "模组",
                                function = "delete",
                                filename = old_item.filename
                            });
                        }
                    }
                }
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(UpdataOBJ, Formatting.Indented));
                    INFO.Text = "状态：等待操作";
            }
            is_busy = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ServerInfo.ServerLocal = mods_server.Text;
        }

        private void OldJsonClick(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            is_busy = true;
            if (old_json_open.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(old_json_open.FileName))
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                JObject json = JObject.Parse(File.ReadAllText(old_json_open.FileName));
                OldUpdata = json.ToObject<UpdataOBJ>();
                packname_t.Text = OldUpdata.packname;
                vision_t.Text = OldUpdata.Version;
                LastVersion_t.Text = OldUpdata.LastVersion;
                OldMod.Text = "模组：" + (OldUpdata.mods != null ? "" + OldUpdata.mods.Count : "无");
                oldScripts.Text = "魔改：" + (OldUpdata.scripts != null ? "" + OldUpdata.scripts.Count : "无");
                OldResourcepacks.Text = "材质包：" + (OldUpdata.resourcepacks != null ? "" + OldUpdata.resourcepacks.Count : "无");
                int a = 0;
                if (OldUpdata.config != null)
                {
                    a += OldUpdata.config.Count;
                }
                if (OldUpdata.launch != null)
                {
                    a += OldUpdata.launch.Count;
                }
                if (OldUpdata.self != null)
                {
                    a += OldUpdata.self.Count;
                }
                OldOther.Text = "其他资源：" + (a == 0 ? a.ToString() : "无");
                packname_t.Text = OldUpdata.packname;
                vision_t.Text = OldUpdata.Version;
                LastVersion_t.Text = OldUpdata.LastVersion;
                listView_mods.Items.Clear();
                if (OldUpdata.mods?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.mods.Values)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (OldUpdata.scripts?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.scripts)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (OldUpdata.config?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.config)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (OldUpdata.resourcepacks?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.resourcepacks)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (OldUpdata.launch?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.launch)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (OldUpdata.self?.Count != 0)
                {
                    foreach (UpdataItem save in OldUpdata.self)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                UpdataOBJ.packname = OldUpdata.packname;
                UpdataOBJ.Version = OldUpdata.Version;
                UpdataOBJ.LastVersion = OldUpdata.LastVersion;
                if (OldUpdata.mods != null)
                    UpdataOBJ.mods = new Dictionary<string, UpdataItem>(OldUpdata.mods);
                if (OldUpdata.scripts != null)
                    UpdataOBJ.scripts = new List<UpdataItem>(OldUpdata.scripts);
                if (OldUpdata.resourcepacks != null)
                    UpdataOBJ.resourcepacks = new List<UpdataItem>(OldUpdata.resourcepacks);
                if (OldUpdata.config != null)
                    UpdataOBJ.config = new List<UpdataItem>(OldUpdata.config);
                if (OldUpdata.launch != null)
                    UpdataOBJ.launch = new List<UpdataItem>(OldUpdata.launch);
                if (OldUpdata.self != null)
                    UpdataOBJ.self = new List<UpdataItem>(OldUpdata.self);
            }
            is_busy = false;
        }
        public static T DeepCopy<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj == null || obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }
        private void OldJsonClearClick(object sender, EventArgs e)
        {
            OldUpdata = null;
            OldMod.Text = "模组：无";
            oldScripts.Text = "魔改：无";
            OldResourcepacks.Text = "材质包：无";
            OldOther.Text = "其他资源：无";
        }
        private string GetMd5(UpdataItem mod)
        {
            INFO.Text = "正在获取：" + mod.name;
            IChecker checker = new MD5Checker();
            try
            {
                checker.FilePath = modsT.Text + @"/mods/" + mod.filename;
                return checker.GetFileChecksum();
            }
            catch
            {
                return "null";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            else if (string.IsNullOrWhiteSpace(modsT.Text))
            {
                MessageBox.Show("请选择根目录");
                return;
            }
            string[] folders = Directory.GetDirectories(modsT.Text, ".minecraft");
            if (folders.Length == 0)
            {
                MessageBox.Show("选择的目录下没有.minecraft文件夹");
                return;
            }
            INFO.Text = "状态：获取中";
            Task.Factory.StartNew(() =>
            {
                is_busy = true;
                if (UpdataOBJ != null && UpdataOBJ.mods.Count != 0)
                {
                    Action<int> action = (data) =>
                    {
                        foreach (KeyValuePair<string, UpdataItem> item in UpdataOBJ.mods)
                        {
                            string a = GetMd5(item.Value);
                            if (a != "null")
                            {
                                UpdataOBJ.mods[item.Key].check = a;
                                Action<string> action1 = (data1) =>
                                {
                                    for (int temp = 0; temp < listView_mods.Items.Count; temp++)
                                    {
                                        foreach (ListViewItem.ListViewSubItem temp1 in listView_mods.Items[temp].SubItems)
                                        {
                                            if (temp1.Text == item.Key)
                                            {
                                                listView_mods.Items[temp].SubItems[2].Text = data1;
                                            }
                                        }
                                    }
                                };
                                Invoke(action1, a);
                            }
                        }
                        INFO.Text = "状态：等待操作";
                        is_busy = false;
                    };
                    Invoke(action, 0);
                }
            });
        }
    }
}
