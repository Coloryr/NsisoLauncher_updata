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
using static System.Windows.Forms.ListViewItem;

namespace NsisoLauncher_updata
{
    public partial class Form1 : Form
    {
        public static UpdataOBJ updataobj { get; set; } = new UpdataOBJ();
        public static UpdataOBJ oldupdata { get; set; } = new UpdataOBJ();
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

        private void re_mods_Click(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            INFO.Text = "状态：更新列表中";
            Task.Factory.StartNew(() =>
            {
                is_busy = true;
                get_ok.Clear();
                try
                {
                    updataobj.mods = new ModCheck().ReadModInfo(mods_t.Text);
                    updataobj.scripts = new ScriptsCheck().ReadscriptsInfo(mods_t.Text);
                    updataobj.config = new OtherCheck().ReadOtherInfo(mods_t.Text);
                    updataobj.resourcepacks = new ResourcepacksCheck().ReadresourcepacksInfo(mods_t.Text);
                    Action<int> action = (data) =>
                    {
                        listView_mods.Items.Clear();
                        if (updataobj.mods.Count != 0)
                        {
                            foreach (UpdataItem save in updataobj.mods.Values)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (updataobj.scripts.Count != 0)
                        {
                            foreach (UpdataItem save in updataobj.scripts)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (updataobj.config.Count != 0)
                        {
                            foreach (UpdataItem save in updataobj.config)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        if (updataobj.resourcepacks.Count != 0)
                        {
                            foreach (UpdataItem save in updataobj.resourcepacks)
                            {
                                ListViewItem test = new ListViewItem(save.type);
                                test.SubItems.Add(save.name);
                                test.SubItems.Add(save.check);
                                test.SubItems.Add(save.url);
                                listView_mods.Items.Add(test);
                            }
                        }
                        INFO.Text = "状态：等待操作";
                        new_mod.Text = "模组：" + (updataobj.mods.Count != 0 ? "" + updataobj.mods.Count : "无");
                        new_scripts.Text = "魔改：" + (updataobj.scripts.Count != 0 ? "" + updataobj.scripts.Count : "无");
                        new_resourcepacks.Text = "材质包：" + (updataobj.resourcepacks.Count != 0 ? "" + updataobj.resourcepacks.Count : "无");
                        new_other.Text = "其他资源：" + (updataobj.config.Count != 0 ? "" + updataobj.config.Count : "无");
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

        private void chose_mods_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mods_t.Text))
                folderBrowserDialog1.SelectedPath = mods_t.Text;
            folderBrowserDialog1.Description = "请选择mods文件路径";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                mods_t.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void gen_json_Click(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            INFO.Text = "状态：保存中";
            is_busy = true;
            saveFileDialog1.DefaultExt = updataobj.packname + @".json";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                updataobj.packname = packname_t.Text;
                updataobj.Version = vision_t.Text;
                if (oldupdata.mods != null)
                {
                    Dictionary<string, UpdataItem> temp = new Dictionary<string, UpdataItem>(oldupdata.mods);
                    foreach (KeyValuePair<string, UpdataItem> new_item in updataobj.mods)
                    {
                        if (oldupdata.mods.ContainsKey(new_item.Key))
                        {
                            temp.Remove(new_item.Key);
                        }
                    }
                    Dictionary<string, UpdataItem> temp1 = new Dictionary<string, UpdataItem>(temp);
                    if (temp1.Count != 0)
                    {
                        foreach (UpdataItem old_item in temp1.Values)
                        {
                            updataobj.mods.Add(old_item.name, new UpdataItem
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
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(updataobj, Formatting.Indented));
                    INFO.Text = "状态：等待操作";
            }
            is_busy = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ServerInfo.ServerLocal = mods_server.Text;
        }

        private void old_json_Click(object sender, EventArgs e)
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
                oldupdata = json.ToObject<UpdataOBJ>();
                packname_t.Text = oldupdata.packname;
                vision_t.Text = oldupdata.Version;
                old_mod.Text = "模组：" + (oldupdata.mods != null ? "" + oldupdata.mods.Count : "无");
                old_scripts.Text = "魔改：" + (oldupdata.scripts != null ? "" + oldupdata.scripts.Count : "无");
                old_resourcepacks.Text = "材质包：" + (oldupdata.resourcepacks != null ? "" + oldupdata.resourcepacks.Count : "无");
                old_other.Text = "其他资源：" + (oldupdata.config != null ? "" + oldupdata.config.Count : "无");
                packname_t.Text = oldupdata.packname;
                vision_t.Text = oldupdata.Version;
                listView_mods.Items.Clear();
                if (oldupdata.mods.Count != 0)
                {
                    foreach (UpdataItem save in oldupdata.mods.Values)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (oldupdata.scripts.Count != 0)
                {
                    foreach (UpdataItem save in oldupdata.scripts)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (oldupdata.config.Count != 0)
                {
                    foreach (UpdataItem save in oldupdata.config)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (oldupdata.resourcepacks.Count != 0)
                {
                    foreach (UpdataItem save in oldupdata.resourcepacks)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                updataobj.packname = oldupdata.packname;
                updataobj.Version = oldupdata.Version;
                updataobj.mods = new Dictionary<string, UpdataItem>(oldupdata.mods);
                updataobj.scripts = new List<UpdataItem>(oldupdata.scripts);
                updataobj.resourcepacks = new List<UpdataItem>(oldupdata.resourcepacks);
                updataobj.config = new List<UpdataItem>(oldupdata.config);
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
        private void old_json_clear_Click(object sender, EventArgs e)
        {
            oldupdata = null;
            old_mod.Text = "模组：无";
            old_scripts.Text = "魔改：无";
            old_resourcepacks.Text = "材质包：无";
            old_other.Text = "其他资源：无";
        }
        private string get_string(string a, string b, string c = null)
        {
            int x = a.IndexOf(b) + b.Length;
            int y;
            if (c != null)
            {
                y = a.IndexOf(c, x);
                if (y - x <= 0)
                    return a;
                else
                    return a.Substring(x, y - x);
            }
            else
                return a.Substring(x);
        }
        private string get_md5(UpdataItem mod)
        {
            INFO.Text = "正在获取：" + mod.name;
            IChecker checker = new MD5Checker();
            try
            {
                checker.FilePath = mods_t.Text + @"/mods/" + mod.filename;
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
            else if (string.IsNullOrWhiteSpace(mods_t.Text))
            {
                MessageBox.Show("请选择根目录");
                return;
            }
            INFO.Text = "状态：获取中";
            Task.Factory.StartNew(() =>
            {
                is_busy = true;
                if (updataobj != null && updataobj.mods.Count != 0)
                {
                    Action<int> action = (data) =>
                    {
                        foreach (KeyValuePair<string, UpdataItem> item in updataobj.mods)
                        {
                            string a = get_md5(item.Value);
                            if (a != "null")
                            {
                                updataobj.mods[item.Key].check = a;
                                Action<string> action1 = (data1) =>
                                {
                                    for (int temp = 0; temp < listView_mods.Items.Count; temp++)
                                    {
                                        foreach (ListViewSubItem temp1 in listView_mods.Items[temp].SubItems)
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
