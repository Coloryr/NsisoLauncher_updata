﻿namespace NsisoLauncher_updata
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
            this.modid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modvision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.md5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.packname_t = new System.Windows.Forms.TextBox();
            this.vision_t = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gen_json = new System.Windows.Forms.Button();
            this.re_mods = new System.Windows.Forms.Button();
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
            this.groupBox1.Text = "mod列表";
            // 
            // listView_mods
            // 
            this.listView_mods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.modid,
            this.modvision,
            this.md5,
            this.localname});
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
            // modid
            // 
            this.modid.Text = "MOD名称";
            this.modid.Width = 150;
            // 
            // modvision
            // 
            this.modvision.Text = "MOD版本";
            this.modvision.Width = 100;
            // 
            // md5
            // 
            this.md5.Text = "md5";
            this.md5.Width = 330;
            // 
            // localname
            // 
            this.localname.Text = "本地文件名";
            this.localname.Width = 203;
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
            // 
            // vision_t
            // 
            this.vision_t.Location = new System.Drawing.Point(688, 70);
            this.vision_t.Name = "vision_t";
            this.vision_t.Size = new System.Drawing.Size(247, 21);
            this.vision_t.TabIndex = 4;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "状态：";
            // 
            // gen_json
            // 
            this.gen_json.Location = new System.Drawing.Point(860, 415);
            this.gen_json.Name = "gen_json";
            this.gen_json.Size = new System.Drawing.Size(75, 23);
            this.gen_json.TabIndex = 6;
            this.gen_json.Text = "生成json";
            this.gen_json.UseVisualStyleBackColor = true;
            // 
            // re_mods
            // 
            this.re_mods.Location = new System.Drawing.Point(779, 415);
            this.re_mods.Name = "re_mods";
            this.re_mods.Size = new System.Drawing.Size(75, 23);
            this.re_mods.TabIndex = 7;
            this.re_mods.Text = "刷新mods";
            this.re_mods.UseVisualStyleBackColor = true;
            this.re_mods.Click += new System.EventHandler(this.re_mods_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.Controls.Add(this.re_mods);
            this.Controls.Add(this.gen_json);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vision_t);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.packname_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NsisoLauncher专用mod更新器";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_mods;
        private System.Windows.Forms.ColumnHeader modid;
        private System.Windows.Forms.ColumnHeader modvision;
        private System.Windows.Forms.ColumnHeader md5;
        private System.Windows.Forms.ColumnHeader localname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox packname_t;
        private System.Windows.Forms.TextBox vision_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button gen_json;
        private System.Windows.Forms.Button re_mods;
    }
}

