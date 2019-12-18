using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NsisoLauncherCore.Net;
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
        public static updata_obj updata_obj { get; set; } = new updata_obj();
        public static updata_obj old_updata { get; set; } = new updata_obj();
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
            saveFileDialog1.DefaultExt = updata_obj.packname + @".json";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                updata_obj.packname = packname_t.Text;
                updata_obj.Vision = vision_t.Text;
                if (old_updata.mods != null)
                {
                    Dictionary<string, updata_item> temp = new Dictionary<string, updata_item>(old_updata.mods);
                    foreach (KeyValuePair<string, updata_item> new_item in updata_obj.mods)
                    {
                        if (old_updata.mods.ContainsKey(new_item.Key))
                        {
                            temp.Remove(new_item.Key);
                        }
                    }
                    Dictionary<string, updata_item> temp1 = new Dictionary<string, updata_item>(temp);
                    if (temp1.Count != 0)
                    {
                        foreach (updata_item old_item in temp1.Values)
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
            is_busy = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            server_info.server_local = mods_server.Text;
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
                old_updata = json.ToObject<updata_obj>();
                packname_t.Text = old_updata.packname;
                vision_t.Text = old_updata.Vision;
                old_mod.Text = "模组：" + (old_updata.mods != null ? "" + old_updata.mods.Count : "无");
                old_scripts.Text = "魔改：" + (old_updata.scripts != null ? "" + old_updata.scripts.Count : "无");
                old_resourcepacks.Text = "材质包：" + (old_updata.resourcepacks != null ? "" + old_updata.resourcepacks.Count : "无");
                old_other.Text = "其他资源：" + (old_updata.config != null ? "" + old_updata.config.Count : "无");
                packname_t.Text = old_updata.packname;
                vision_t.Text = old_updata.Vision;
                listView_mods.Items.Clear();
                if (old_updata.mods.Count != 0)
                {
                    foreach (updata_item save in old_updata.mods.Values)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (old_updata.scripts.Count != 0)
                {
                    foreach (updata_item save in old_updata.scripts)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (old_updata.config.Count != 0)
                {
                    foreach (updata_item save in old_updata.config)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                if (old_updata.resourcepacks.Count != 0)
                {
                    foreach (updata_item save in old_updata.resourcepacks)
                    {
                        ListViewItem test = new ListViewItem(save.type);
                        test.SubItems.Add(save.name);
                        test.SubItems.Add(save.check);
                        test.SubItems.Add(save.url);
                        listView_mods.Items.Add(test);
                    }
                }
                updata_obj = DeepCopy<updata_obj>(old_updata);
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
            old_updata = null;
            old_mod.Text = "模组：无";
            old_scripts.Text = "魔改：无";
            old_resourcepacks.Text = "材质包：无";
            old_other.Text = "其他资源：无";
        }

        private void curseforge_Click(object sender, EventArgs e)
        {
            if (is_busy)
            {
                MessageBox.Show("上一个操作在进行中");
                return;
            }
            INFO.Text = "状态：获取中";
            Task.Factory.StartNew(() =>
            {
                is_busy = true;
                if (updata_obj != null && updata_obj.mods.Count != 0)
                {
                    Action<int> action = async (data) =>
                    {
                        foreach (KeyValuePair<string, updata_item> item in updata_obj.mods)
                        {
                            if (!get_ok.Contains(item.Key))
                            {
                                string a = await get_urlAsync(item.Value);
                                if (a != "null")
                                {
                                    if (!a.Contains(item.Value.filename))
                                    {
                                        item.Value.filename = get_string(a, "/" + item.Value.filename.Substring(0, 2));
                                    }
                                    updata_obj.mods[item.Key].url = a;
                                    get_ok.Add(item.Key);
                                    Action<string> action1 = (data1) =>
                                    {
                                        for (int temp = 0; temp < listView_mods.Items.Count; temp++)
                                        {
                                            foreach (ListViewSubItem temp1 in listView_mods.Items[temp].SubItems)
                                            {
                                                if (temp1.Text == item.Key)
                                                {
                                                    listView_mods.Items[temp].SubItems[3].Text = data1;
                                                }
                                            }
                                        }
                                    };
                                    Invoke(action1, a);
                                }
                            }
                        }
                        INFO.Text = "状态：等待操作";
                        is_busy = false;
                    };
                    Invoke(action, 0);
                }
            });
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
        private async Task<string> get_urlAsync(updata_item mod)
        {
            string base_url = @"https://addons-ecs.forgesvc.net/api/v2/addon/{0}/file/{1}";
            string re_url = @"https://api.cfwidget.com/minecraft/mc-mods/";
            string mod_name = mod.name.Trim(' ').Replace(' ', '-').Replace("!", "").Replace(@"'", "")
                .Replace(",", "").Replace(":", "").Replace("_","-").Replace("+","-").TrimEnd('-');
            if (mod_name.Contains("(") && mod_name.Contains(")"))
            {
                mod_name = get_string(mod_name, "(", ")");
            }
            else if (tran_1_12.ContainsKey(mod_name) && mc_vision.Text.Contains("1.12"))
                mod_name = tran_1_12[mod_name];
            re_url += mod_name;
            INFO.Text = "正在获取：" + mod_name;
            try
            {
                string res = await APIRequester.HttpGetStringAsync(re_url);
                if (string.IsNullOrWhiteSpace(res))
                    return "null";
                JObject c = JObject.Parse(res);
                mod_re_obj obj = c.ToObject<mod_re_obj>();
                foreach (file file in obj.files)
                {
                    if (file.version.Contains(mc_vision.Text) || file.versions.Contains(mc_vision.Text))
                    {
                        INFO.Text = "正在读取：" + mod_name;
                        res = await APIRequester.HttpGetStringAsync(string.Format(base_url, obj.id, file.id));
                        if (string.IsNullOrWhiteSpace(res))
                            return "null";
                        var obj1 = JObject.Parse(res).ToObject<mod_re_obj1>();
                        return obj1.downloadUrl;
                    }
                }
                return "null";
            }
            catch
            {
                return "null";
            }
        }
        private string get_md5(updata_item mod)
        {
            INFO.Text = "正在获取：" + mod.name;
            IChecker checker = new MD5Checker();
            try
            {

                checker.FilePath = mods_t.Text + @"/" + mod.filename;
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
                if (updata_obj != null && updata_obj.mods.Count != 0)
                {
                    Action<int> action = (data) =>
                    {
                        foreach (KeyValuePair<string, updata_item> item in updata_obj.mods)
                        {
                            if (!get_ok.Contains(item.Key))
                            {
                                string a = get_md5(item.Value);
                                if (a != "null")
                                {
                                    updata_obj.mods[item.Key].url = a;
                                    get_ok.Add(item.Key);
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
                        }
                        INFO.Text = "状态：等待操作";
                        is_busy = false;
                    };
                    Invoke(action, 0);
                }
            });
        }
        private static Dictionary<string, string> tran_1_12 = new Dictionary<string, string>()
        {
            {"AngelRing-2-Bauble","angel-ring-to-bauble"},
            {"Avaritia", "avaritia-1-10"},
            {"Avaritia-Recipe-Maker", "avaritia-recipe-generator"},
            {"BD-Lib", "BDLib"},
            {"CodeChicken-Lib", "codechicken-lib-1-8"},
            {"CraftTweaker2", "CraftTweaker"},
            {"Cucumber-Library","cucumber"},
            {"Draconic-Additions","draconicadditions"},
            {"EnderStorage", "ender-storage-1-8"},
            {"Extra-Cells-2", "ExtraCells2"},
            {"Extra-Utilities-2", "Extra-Utilities"},
            {"ET-Lunar", "environmental-lunartech"},
            {"FoamFix", "foamfix-for-minecraft"},
            {"FTB-Library", "ftblib"},
            {"FTB-Utilitie:-Backups", "ftb-backups"},
            {"Grimoire-of-Gaia-3", "Grimoire-of-gaia"},
            {"Waila", "Hwyla"},
            {"IndustrialExpansion", "industrial-expansion-te-addon"},
            {"Just-Enough-Items", "jei"},
            {"JMap-Staged","journeymapstages"},
            {"Just-Enough-Energistics", "just-enough-energistics-jee"},
            {"Just-Enough-Resources", "just-enough-resources-jer"},
            {"MakeZoomZoom", "make-zoom-zoom"},
            {"MineTweakerRecipeMaker","minetweaker-recipemaker"},
            {"MoreOverlays","more-overlays"},
            {"NoMoreRecipeConflict","stimmedcow-nomorerecipeconflict"},
            {"OreExcavation","Ore-Excavation"},
            {"p455w0rdslib", "p455w0rds-library"},
            {"Salty-Mod","SaltyMod"},
            {"SelfControl", "Self-Control"},
            {"SonarCore", "Sonar-Core"},
            {"Standard-Expansion","better-questing-standard-expansion"},
            {"Tinker-Stages","TinkerStages"},
            {"Tree-Growing-Simulator-2016","Tree-Growing-Simulator"},
            {"Up-Sizer","upsizer-mod"},
            {"Valkyrie-Lib","valkyrielib"},
            {"WaterPower","Water-Power"},
            {"Winter-WonderLand","winter-wonder-land"},
            {"Wireless-Crafting-Terminal","wireless-crafting-terminal"},
            {"Zero-CORE","zerocore"},
            {"CustomNPCs","custom-npcs"},
            {"I18n-Update-Mod","i18nupdatemod"},
            {"Placeable-Items-Mod","placeable-items"},
            {"Real-First-Person-2","real-first-person-render"},
            {"B.A.S.E","base"},
            {"Barrels-Drums-Storage-&-More", "barrels-drums-storage-more"},
            {"Chisels-&-Bits","chisels-bits"},
            {"CommonCapabilities", "Common-Capabilities"},
            {"Compact-Machines-3", "Compact-Machines"},
            {"InControl", "In-Control"},
            {"Simple-Inventory-sorting", "inventory-sorter"},
            {"Elevator-Mod","openblocks-elevator"},
            {"MatterOverdrive-Legacy-Edition","matteroverdrive"},
            {"Mod-Tweaker","modtweaker"},
            {"ModPack-Basic-Tools", "mputils-basic-tools"},
            {"ModPack-Utilities", "mputils"},
            {"NuclearCraft", "nuclearcraft-mod"},
            {"OpenComputers-Xnet-Driver","oc-xnet-driver"},
            {"OG-Dragon","ogdragon"},
            {"PlaneFix1","PlaneFix"},
            {"PortalGun","Portal-Gun"},
            {"RecipeStages","Recipe-Stages"},
            {"rftoolspower","rftools-power"},
            {"SkyBonsais", "Sky-Bonsais"},
            {"Squeezer-Patch","id-squeezer-tweak"},
            {"Statues-mod","Statues"},
            {"TogetherForever","Together-Forever"},
            {"Translocators","translocators-1-8"},
            {"ViesCraft","viescraft-airships"},
            {"What-Are-We-Looking-At","wawla-what-are-we-looking-at"},
            {"Wither-Crumbs","witherCrumbs"},
            {"XC-Patch","XCPatch"},
            {"HydroGel","ignition-hydrogel"}
        };
    }
}
