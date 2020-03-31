using System.Windows.Forms;

namespace NsisoLauncher_updata
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_mods = new System.Windows.Forms.ListView();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.md5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.packname_t = new System.Windows.Forms.TextBox();
            this.vision_t = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.INFO = new System.Windows.Forms.Label();
            this.gen_json = new System.Windows.Forms.Button();
            this.re_mods = new System.Windows.Forms.Button();
            this.mods_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chose_mods = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mods_server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.old_json = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.old_mod = new System.Windows.Forms.Label();
            this.old_resourcepacks = new System.Windows.Forms.Label();
            this.old_scripts = new System.Windows.Forms.Label();
            this.old_other = new System.Windows.Forms.Label();
            this.new_other = new System.Windows.Forms.Label();
            this.new_scripts = new System.Windows.Forms.Label();
            this.new_resourcepacks = new System.Windows.Forms.Label();
            this.new_mod = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.old_json_open = new System.Windows.Forms.OpenFileDialog();
            this.old_json_clear = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mc_vision = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_mods);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "资源列表";
            // 
            // listView_mods
            // 
            this.listView_mods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.type,
            this.modid,
            this.md5,
            this.url});
            this.listView_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_mods.FullRowSelect = true;
            this.listView_mods.GridLines = true;
            this.listView_mods.HideSelection = false;
            this.listView_mods.Location = new System.Drawing.Point(3, 17);
            this.listView_mods.MultiSelect = false;
            this.listView_mods.Name = "listView_mods";
            this.listView_mods.Size = new System.Drawing.Size(662, 406);
            this.listView_mods.TabIndex = 1;
            this.listView_mods.UseCompatibleStateImageBehavior = false;
            this.listView_mods.View = System.Windows.Forms.View.Details;
            this.listView_mods.SelectedIndexChanged += new System.EventHandler(this.listView_mods_SelectedIndexChanged);
            // 
            // type
            // 
            this.type.Text = "类型";
            this.type.Width = 40;
            // 
            // modid
            // 
            this.modid.Text = "资源名称";
            this.modid.Width = 150;
            // 
            // md5
            // 
            this.md5.Text = "md5";
            this.md5.Width = 211;
            // 
            // url
            // 
            this.url.Text = "下载地址";
            this.url.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(686, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "整合包名字";
            // 
            // packname_t
            // 
            this.packname_t.Location = new System.Drawing.Point(688, 29);
            this.packname_t.Name = "packname_t";
            this.packname_t.Size = new System.Drawing.Size(247, 21);
            this.packname_t.TabIndex = 2;
            this.packname_t.Text = "modpack";
            // 
            // vision_t
            // 
            this.vision_t.Location = new System.Drawing.Point(688, 70);
            this.vision_t.Name = "vision_t";
            this.vision_t.Size = new System.Drawing.Size(247, 21);
            this.vision_t.TabIndex = 4;
            this.vision_t.Text = "1.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "版本号";
            // 
            // INFO
            // 
            this.INFO.AutoSize = true;
            this.INFO.Location = new System.Drawing.Point(10, 441);
            this.INFO.Name = "INFO";
            this.INFO.Size = new System.Drawing.Size(41, 12);
            this.INFO.TabIndex = 5;
            this.INFO.Text = "状态：";
            // 
            // gen_json
            // 
            this.gen_json.Location = new System.Drawing.Point(860, 415);
            this.gen_json.Name = "gen_json";
            this.gen_json.Size = new System.Drawing.Size(75, 23);
            this.gen_json.TabIndex = 6;
            this.gen_json.Text = "生成json";
            this.gen_json.UseVisualStyleBackColor = true;
            this.gen_json.Click += new System.EventHandler(this.gen_json_Click);
            // 
            // re_mods
            // 
            this.re_mods.Location = new System.Drawing.Point(779, 415);
            this.re_mods.Name = "re_mods";
            this.re_mods.Size = new System.Drawing.Size(75, 23);
            this.re_mods.TabIndex = 7;
            this.re_mods.Text = "刷新资源";
            this.re_mods.UseVisualStyleBackColor = true;
            this.re_mods.Click += new System.EventHandler(this.re_mods_Click);
            // 
            // mods_t
            // 
            this.mods_t.Location = new System.Drawing.Point(688, 111);
            this.mods_t.Name = "mods_t";
            this.mods_t.Size = new System.Drawing.Size(247, 21);
            this.mods_t.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "本地资源文件夹";
            // 
            // chose_mods
            // 
            this.chose_mods.Location = new System.Drawing.Point(698, 415);
            this.chose_mods.Name = "chose_mods";
            this.chose_mods.Size = new System.Drawing.Size(75, 23);
            this.chose_mods.TabIndex = 10;
            this.chose_mods.Text = "选择资源";
            this.chose_mods.UseVisualStyleBackColor = true;
            this.chose_mods.Click += new System.EventHandler(this.chose_mods_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "资源列表|*.json";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // mods_server
            // 
            this.mods_server.Location = new System.Drawing.Point(688, 152);
            this.mods_server.Name = "mods_server";
            this.mods_server.Size = new System.Drawing.Size(247, 21);
            this.mods_server.TabIndex = 12;
            this.mods_server.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(686, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "服务器地址目录";
            // 
            // old_json
            // 
            this.old_json.Location = new System.Drawing.Point(721, 386);
            this.old_json.Name = "old_json";
            this.old_json.Size = new System.Drawing.Size(104, 23);
            this.old_json.TabIndex = 13;
            this.old_json.Text = "导入旧资源json";
            this.old_json.UseVisualStyleBackColor = true;
            this.old_json.Click += new System.EventHandler(this.old_json_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(686, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "旧资源文件：";
            // 
            // old_mod
            // 
            this.old_mod.AutoSize = true;
            this.old_mod.Location = new System.Drawing.Point(686, 252);
            this.old_mod.Name = "old_mod";
            this.old_mod.Size = new System.Drawing.Size(59, 12);
            this.old_mod.TabIndex = 15;
            this.old_mod.Text = "模组：xxx";
            // 
            // old_resourcepacks
            // 
            this.old_resourcepacks.AutoSize = true;
            this.old_resourcepacks.Location = new System.Drawing.Point(686, 273);
            this.old_resourcepacks.Name = "old_resourcepacks";
            this.old_resourcepacks.Size = new System.Drawing.Size(71, 12);
            this.old_resourcepacks.TabIndex = 16;
            this.old_resourcepacks.Text = "材质包：xxx";
            // 
            // old_scripts
            // 
            this.old_scripts.AutoSize = true;
            this.old_scripts.Location = new System.Drawing.Point(813, 252);
            this.old_scripts.Name = "old_scripts";
            this.old_scripts.Size = new System.Drawing.Size(41, 12);
            this.old_scripts.TabIndex = 17;
            this.old_scripts.Text = "魔改：";
            // 
            // old_other
            // 
            this.old_other.AutoSize = true;
            this.old_other.Location = new System.Drawing.Point(813, 273);
            this.old_other.Name = "old_other";
            this.old_other.Size = new System.Drawing.Size(83, 12);
            this.old_other.TabIndex = 18;
            this.old_other.Text = "其他资源：xxx";
            // 
            // new_other
            // 
            this.new_other.AutoSize = true;
            this.new_other.Location = new System.Drawing.Point(813, 336);
            this.new_other.Name = "new_other";
            this.new_other.Size = new System.Drawing.Size(83, 12);
            this.new_other.TabIndex = 23;
            this.new_other.Text = "其他资源：xxx";
            // 
            // new_scripts
            // 
            this.new_scripts.AutoSize = true;
            this.new_scripts.Location = new System.Drawing.Point(813, 315);
            this.new_scripts.Name = "new_scripts";
            this.new_scripts.Size = new System.Drawing.Size(41, 12);
            this.new_scripts.TabIndex = 22;
            this.new_scripts.Text = "魔改：";
            // 
            // new_resourcepacks
            // 
            this.new_resourcepacks.AutoSize = true;
            this.new_resourcepacks.Location = new System.Drawing.Point(686, 336);
            this.new_resourcepacks.Name = "new_resourcepacks";
            this.new_resourcepacks.Size = new System.Drawing.Size(71, 12);
            this.new_resourcepacks.TabIndex = 21;
            this.new_resourcepacks.Text = "材质包：xxx";
            // 
            // new_mod
            // 
            this.new_mod.AutoSize = true;
            this.new_mod.Location = new System.Drawing.Point(686, 315);
            this.new_mod.Name = "new_mod";
            this.new_mod.Size = new System.Drawing.Size(59, 12);
            this.new_mod.TabIndex = 20;
            this.new_mod.Text = "模组：xxx";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(686, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "新资源文件：";
            // 
            // old_json_open
            // 
            this.old_json_open.DefaultExt = "json";
            this.old_json_open.Filter = "json文件|*.json";
            this.old_json_open.RestoreDirectory = true;
            // 
            // old_json_clear
            // 
            this.old_json_clear.Location = new System.Drawing.Point(831, 386);
            this.old_json_clear.Name = "old_json_clear";
            this.old_json_clear.Size = new System.Drawing.Size(104, 23);
            this.old_json_clear.TabIndex = 24;
            this.old_json_clear.Text = "清除旧资源json";
            this.old_json_clear.UseVisualStyleBackColor = true;
            this.old_json_clear.Click += new System.EventHandler(this.old_json_clear_Click);
            // 
            // mc_vision
            // 
            this.mc_vision.Location = new System.Drawing.Point(688, 193);
            this.mc_vision.Name = "mc_vision";
            this.mc_vision.Size = new System.Drawing.Size(247, 21);
            this.mc_vision.TabIndex = 28;
            this.mc_vision.Text = "1.12";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(686, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "MC版本号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "更新MD5";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 459);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mc_vision);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.old_json_clear);
            this.Controls.Add(this.new_other);
            this.Controls.Add(this.new_scripts);
            this.Controls.Add(this.new_resourcepacks);
            this.Controls.Add(this.new_mod);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.old_other);
            this.Controls.Add(this.old_scripts);
            this.Controls.Add(this.old_resourcepacks);
            this.Controls.Add(this.old_mod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.old_json);
            this.Controls.Add(this.mods_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chose_mods);
            this.Controls.Add(this.mods_t);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.re_mods);
            this.Controls.Add(this.gen_json);
            this.Controls.Add(this.INFO);
            this.Controls.Add(this.vision_t);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.packname_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NsisoLauncher专用资源更新生成器";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_mods;
        private System.Windows.Forms.ColumnHeader modid;
        private System.Windows.Forms.ColumnHeader md5;
        private System.Windows.Forms.ColumnHeader url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox packname_t;
        private System.Windows.Forms.TextBox vision_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label INFO;
        private System.Windows.Forms.Button gen_json;
        private System.Windows.Forms.Button re_mods;
        private System.Windows.Forms.TextBox mods_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button chose_mods;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox mods_server;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Button old_json;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label old_mod;
        private System.Windows.Forms.Label old_resourcepacks;
        private System.Windows.Forms.Label old_scripts;
        private System.Windows.Forms.Label old_other;
        private System.Windows.Forms.Label new_other;
        private System.Windows.Forms.Label new_scripts;
        private System.Windows.Forms.Label new_resourcepacks;
        private System.Windows.Forms.Label new_mod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog old_json_open;
        private System.Windows.Forms.Button old_json_clear;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox mc_vision;
        private System.Windows.Forms.Label label6;
        private Button button1;
    }
}

