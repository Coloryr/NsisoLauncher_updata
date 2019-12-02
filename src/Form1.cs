using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsisoLauncher_updata
{
    public partial class Form1 : Form
    {
        public static updata_obj updata_obj = new updata_obj() { };
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
                Action<int> action = (data) =>
                {
                    listView_mods.Items.Clear();
                    if (updata_obj.mods.Count != 0)
                    {
                        foreach (updata_item save in updata_obj.mods)
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
                    INFO.Text = "状态：等待操作";
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
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(updata_obj, Formatting.Indented));
                INFO.Text = "状态：等待操作";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            server_info.server_local = mods_server.Text;
        }
    }
}
