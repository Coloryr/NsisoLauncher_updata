using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsisoLauncher_updata
{
    public partial class Form1 : Form
    {
        class mod_list
        {
            public List<mod_save> list = new List<mod_save> { };
        }
        class mod_save
        {
            public string name;
            public string version;
            public string md5;
            public string file;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void listView_mods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void re_mods_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                mod_list list = mod.ReadModInfo(server_save.server_local);
                if (list != null)
                {
                    Action<int> action = (data) =>
                    {
                        listView_mods.Items.Clear();
                        foreach (plugin_mod_save save in list.list)
                        {
                            ListViewItem test = new ListViewItem(save.name);
                            test.SubItems.Add(save.version);
                            test.SubItems.Add(save.auth);
                            test.SubItems.Add(save.file);
                            listView_mods.Items.Add(test);

                        }
                    };
                    Invoke(action, 0);
                }
                mods_run = false;
            });
        }
    }
}
