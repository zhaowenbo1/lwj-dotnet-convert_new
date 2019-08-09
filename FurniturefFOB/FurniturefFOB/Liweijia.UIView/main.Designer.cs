namespace FurniturefFOB
{
    partial class main
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
            System.Windows.Forms.GroupBox groupBox2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.logtxt = new System.Windows.Forms.RichTextBox();
            this.Startjxbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateXmnbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.orderNotxt = new System.Windows.Forms.TextBox();
            this.filepathtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStrip0 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PorcessMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Errortxt = new System.Windows.Forms.RichTextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(this.logtxt);
            groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupBox2.Location = new System.Drawing.Point(0, 174);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(622, 542);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "【转换日志】";
            // 
            // logtxt
            // 
            this.logtxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logtxt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logtxt.Location = new System.Drawing.Point(3, 19);
            this.logtxt.Name = "logtxt";
            this.logtxt.Size = new System.Drawing.Size(616, 520);
            this.logtxt.TabIndex = 0;
            this.logtxt.Text = "";
            // 
            // Startjxbtn
            // 
            this.Startjxbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Startjxbtn.Location = new System.Drawing.Point(780, 30);
            this.Startjxbtn.Name = "Startjxbtn";
            this.Startjxbtn.Size = new System.Drawing.Size(129, 29);
            this.Startjxbtn.TabIndex = 5;
            this.Startjxbtn.Text = "开始监测";
            this.Startjxbtn.UseVisualStyleBackColor = true;
            this.Startjxbtn.Click += new System.EventHandler(this.Startjxbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(777, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "输出路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "监测路径";
            // 
            // CreateXmnbtn
            // 
            this.CreateXmnbtn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.CreateXmnbtn.Location = new System.Drawing.Point(644, 77);
            this.CreateXmnbtn.Name = "CreateXmnbtn";
            this.CreateXmnbtn.Size = new System.Drawing.Size(89, 29);
            this.CreateXmnbtn.TabIndex = 2;
            this.CreateXmnbtn.Text = "生成XML";
            this.CreateXmnbtn.UseVisualStyleBackColor = true;
            this.CreateXmnbtn.Click += new System.EventHandler(this.CreateXmnbtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Location = new System.Drawing.Point(644, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "......";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // orderNotxt
            // 
            this.orderNotxt.Font = new System.Drawing.Font("Tahoma", 12F);
            this.orderNotxt.Location = new System.Drawing.Point(157, 77);
            this.orderNotxt.Name = "orderNotxt";
            this.orderNotxt.Size = new System.Drawing.Size(451, 29);
            this.orderNotxt.TabIndex = 1;
            this.orderNotxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderNotxt_KeyDown);
            // 
            // filepathtxt
            // 
            this.filepathtxt.Font = new System.Drawing.Font("Tahoma", 12F);
            this.filepathtxt.Location = new System.Drawing.Point(157, 30);
            this.filepathtxt.Name = "filepathtxt";
            this.filepathtxt.Size = new System.Drawing.Size(451, 29);
            this.filepathtxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(87, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "订单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "酷家乐JSON地址";
            // 
            // ToolStrip0
            // 
            this.ToolStrip0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip1,
            this.ToolStrip2,
            this.ToolStrip3});
            this.ToolStrip0.Name = "ToolStrip0";
            this.ToolStrip0.Size = new System.Drawing.Size(77, 24);
            this.ToolStrip0.Text = "基础资料";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(136, 24);
            this.ToolStrip1.Text = "板材数据";
            this.ToolStrip1.Click += new System.EventHandler(this.ToolStrip1_Click);
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(136, 24);
            this.ToolStrip2.Text = "文件路径";
            this.ToolStrip2.Click += new System.EventHandler(this.ToolStrip2_Click);
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.Size = new System.Drawing.Size(136, 24);
            this.ToolStrip3.Text = "系统变量";
            this.ToolStrip3.Click += new System.EventHandler(this.ToolStrip3_Click);
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip7,
            this.ToolStrip8});
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.Size = new System.Drawing.Size(49, 24);
            this.ToolStrip4.Text = "帮助";
            // 
            // ToolStrip7
            // 
            this.ToolStrip7.Name = "ToolStrip7";
            this.ToolStrip7.Size = new System.Drawing.Size(136, 24);
            this.ToolStrip7.Text = "更新说明";
            this.ToolStrip7.Click += new System.EventHandler(this.ToolStrip7_Click);
            // 
            // ToolStrip8
            // 
            this.ToolStrip8.Name = "ToolStrip8";
            this.ToolStrip8.Size = new System.Drawing.Size(136, 24);
            this.ToolStrip8.Text = "功能说明";
            this.ToolStrip8.Click += new System.EventHandler(this.ToolStrip8_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip0,
            this.ToolStrip4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Startjxbtn);
            this.groupBox1.Controls.Add(this.filepathtxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CreateXmnbtn);
            this.groupBox1.Controls.Add(this.orderNotxt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 140);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.PorcessMsg);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(628, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 357);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "【转换进度】";
            // 
            // PorcessMsg
            // 
            this.PorcessMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PorcessMsg.Location = new System.Drawing.Point(3, 19);
            this.PorcessMsg.Name = "PorcessMsg";
            this.PorcessMsg.Size = new System.Drawing.Size(410, 332);
            this.PorcessMsg.TabIndex = 0;
            this.PorcessMsg.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Errortxt);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(628, 537);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 179);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "【提示消息】";
            // 
            // Errortxt
            // 
            this.Errortxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Errortxt.Location = new System.Drawing.Point(3, 19);
            this.Errortxt.Name = "Errortxt";
            this.Errortxt.Size = new System.Drawing.Size(410, 157);
            this.Errortxt.TabIndex = 0;
            this.Errortxt.Text = "";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 715);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "酷家乐解析_by 五竹";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Startjxbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateXmnbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox orderNotxt;
        private System.Windows.Forms.TextBox filepathtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox Errortxt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox PorcessMsg;
        private System.Windows.Forms.RichTextBox logtxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip0;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip2;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip3;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip4;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip7;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip8;
    }
}

