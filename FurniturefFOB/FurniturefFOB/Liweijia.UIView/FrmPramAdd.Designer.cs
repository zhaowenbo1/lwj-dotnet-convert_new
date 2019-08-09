namespace FurniturefFOB
{
    partial class FrmPramAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPramAdd));
            this.Inametxt = new System.Windows.Forms.TextBox();
            this.Knametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.remarktxt = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Inametxt
            // 
            this.Inametxt.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Inametxt.Location = new System.Drawing.Point(115, 73);
            this.Inametxt.Name = "Inametxt";
            this.Inametxt.Size = new System.Drawing.Size(149, 27);
            this.Inametxt.TabIndex = 1;
            // 
            // Knametxt
            // 
            this.Knametxt.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Knametxt.Location = new System.Drawing.Point(115, 25);
            this.Knametxt.Name = "Knametxt";
            this.Knametxt.Size = new System.Drawing.Size(149, 27);
            this.Knametxt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(33, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "IMOS变量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "酷家乐变量";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "保存后自动关闭窗口";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // closebtn
            // 
            this.closebtn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.closebtn.Location = new System.Drawing.Point(197, 195);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(66, 27);
            this.closebtn.TabIndex = 5;
            this.closebtn.Text = "撤销";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.savebtn.Location = new System.Drawing.Point(115, 195);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(66, 27);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "保存";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // remarktxt
            // 
            this.remarktxt.Location = new System.Drawing.Point(115, 119);
            this.remarktxt.Name = "remarktxt";
            this.remarktxt.Size = new System.Drawing.Size(148, 48);
            this.remarktxt.TabIndex = 2;
            this.remarktxt.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(70, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "备注";
            // 
            // FrmPramAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 237);
            this.Controls.Add(this.remarktxt);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.Inametxt);
            this.Controls.Add(this.Knametxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPramAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量新增参数";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPramAdd_FormClosed);
            this.Load += new System.EventHandler(this.FrmPramAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Inametxt;
        private System.Windows.Forms.TextBox Knametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.RichTextBox remarktxt;
        private System.Windows.Forms.Label label3;
    }
}