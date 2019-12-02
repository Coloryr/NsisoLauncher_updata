using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace NsisoLauncher_updata
{
    public partial class Form1 : Form
    {
        public static updata_obj updata_obj { get; set; } = new updata_obj() ;
        public static updata_obj old_updata { get; set; } = new updata_obj();
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
            INFO.Text = "状态：更新列表中";
            Task.Factory.StartNew(() =>
            {
                updata_obj.mods = new mod_check().ReadModInfo(mods_t.Text);
                updata_obj.scripts = new scripts_check().ReadscriptsInfo(mods_t.Text);
                updata_obj.config = new config_check().ReadconfigInfo(mods_t.Text);
                updata_obj.resourcepacks = new resourcepacks_check().ReadresourcepacksInfo(mods_t.Text);
                Action<int> action = (data) =>
                {
                    listView_mods.Items.Clear();
                    if (updata_obj.mods.Count != 0)
                    {
                        foreach (updata_item save in updata_obj.mods.Values)
                        {
                            ListViewItem test = new ListViewItem(save.type);
                            test.SubItems.Add(save.name);
                            test.SubItems.Add(save.check);
                            test.SubItems.Add(save.url);
                            listView_mods.Items.Add(test);
                        }
                    }
                    if (updata_obj.scripts.Count != 0)
                    {
                        foreach (updata_item save in updata_obj.scripts)
                        {
                            ListViewItem test = new ListViewItem(save.type);
                            test.SubItems.Add(save.name);
                            test.SubItems.Add(save.check);
                            test.SubItems.Add(save.url);
                            listView_mods.Items.Add(test);
                        }
                    }
                    if (updata_obj.config.Count != 0)
                    {
                        foreach (updata_item save in updata_obj.config)
                        {
                            ListViewItem test = new ListViewItem(save.type);
                            test.SubItems.Add(save.name);
                            test.SubItems.Add(save.check);
                            test.SubItems.Add(save.url);
                            listView_mods.Items.Add(test);
                        }
                    }
                    if (updata_obj.resourcepacks.Count != 0)
                    {
                        foreach (updata_item save in updata_obj.resourcepacks)
                        {
                            ListViewItem test = new ListViewItem(save.type);
                            test.SubItems.Add(save.name);
                            test.SubItems.Add(save.check);
                            test.SubItems.Add(save.url);
                            listView_mods.Items.Add(test);
                        }
                    }
                    INFO.Text = "状态：等待操作";
                    new_mod.Text = "模组：" + (updata_obj.mods.Count != 0 ? "" + updata_obj.mods.Count : "无");
                    new_scripts.Text = "魔改：" + (updata_obj.scripts.Count != 0 ? "" + updata_obj.scripts.Count : "无");
                    new_resourcepacks.Text = "材质包：" + (updata_obj.resourcepacks.Count != 0 ? "" + updata_obj.resourcepacks.Count : "无");
                    new_other.Text = "其他资源：" + (updata_obj.config.Count != 0 ? "" + updata_obj.config.Count : "无");
                };
                Invoke(action, 0);
            });
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void chose_mods_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择mods文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mods_t.Text = dialog.SelectedPath;
            }
        }

        private void gen_json_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                INFO.Text = "状态：保存中";
                updata_obj.packname = packname_t.Text;
                updata_obj.Vision = vision_t.Text;
                if (old_updata.mods != null)
                {
                    Dictionary<string, updata_item> temp = old_updata.mods;
                    foreach (KeyValuePair<string, updata_item> new_item in updata_obj.mods)
                    {
                        if (temp.ContainsKey(new_item.Key))
                        {
                            temp.Remove(new_item.Key);
                        }
                    }
                    if (temp.Count != 0)
                    {
                        foreach (updata_item old_item in temp.Values)
                        {
                            updata_obj.mods.Add(old_item.name, new updata_item
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
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(updata_obj, Formatting.Indented));
                INFO.Text = "状态：等待操作";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            server_info.server_local = mods_server.Text;
        }

        private void old_json_Click(object sender, EventArgs e)
        {
            if (old_json_open.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(old_json_open.FileName))
                {
                    MessageBox.Show("请选择文件");
                    return;
                }
                JObject json = JObject.Parse(File.ReadAllText(old_json_open.FileName));
                old_updata = json.ToObject<updata_obj>();
                old_mod.Text = "模组：" + (old_updata.mods != null ? "" + old_updata.mods.Count : "无");
                old_scripts.Text = "魔改：" + (old_updata.scripts != null ? "" + old_updata.scripts.Count : "无");
                old_resourcepacks.Text = "材质包：" + (old_updata.resourcepacks != null ? "" + old_updata.resourcepacks.Count : "无");
                old_other.Text = "其他资源：" + (old_updata.config != null ? "" + old_updata.config.Count : "无");
                packname_t.Text = old_updata.packname;
                vision_t.Text = old_updata.Vision;
            }
        }

        private void old_json_clear_Click(object sender, EventArgs e)
        {
            old_updata = null;
            old_mod.Text = "模组：无";
            old_scripts.Text = "魔改：无";
            old_resourcepacks.Text = "材质包：无";
            old_other.Text = "其他资源：无";
        }
    }
}
