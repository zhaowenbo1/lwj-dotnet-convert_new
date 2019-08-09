namespace FurniturefFOB
{
    partial class FrmSyspram
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSyspram));
            this.sysgrid = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysPramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new FurniturefFOB.Liweijia.Meta.myDataSet();
            this.sysPramTableAdapter = new FurniturefFOB.Liweijia.Meta.myDataSetTableAdapters.SysPramTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.xiugai = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.sysgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysgrid
            // 
            this.sysgrid.AllowUserToAddRows = false;
            this.sysgrid.AllowUserToResizeRows = false;
            this.sysgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sysgrid.AutoGenerateColumns = false;
            this.sysgrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sysgrid.ColumnHeadersHeight = 25;
            this.sysgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sysgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.knameDataGridViewTextBoxColumn,
            this.inameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.sysgrid.DataSource = this.sysPramBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.830189F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sysgrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.sysgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.sysgrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.sysgrid.Location = new System.Drawing.Point(0, 30);
            this.sysgrid.Name = "sysgrid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.830189F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sysgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sysgrid.RowHeadersWidth = 20;
            this.sysgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sysgrid.RowTemplate.Height = 24;
            this.sysgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sysgrid.Size = new System.Drawing.Size(619, 356);
            this.sysgrid.TabIndex = 4;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "分类";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            // 
            // knameDataGridViewTextBoxColumn
            // 
            this.knameDataGridViewTextBoxColumn.DataPropertyName = "Kname";
            this.knameDataGridViewTextBoxColumn.HeaderText = "酷家乐变量";
            this.knameDataGridViewTextBoxColumn.Name = "knameDataGridViewTextBoxColumn";
            // 
            // inameDataGridViewTextBoxColumn
            // 
            this.inameDataGridViewTextBoxColumn.DataPropertyName = "Iname";
            this.inameDataGridViewTextBoxColumn.HeaderText = "IMOS变量";
            this.inameDataGridViewTextBoxColumn.Name = "inameDataGridViewTextBoxColumn";
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "说明";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            // 
            // sysPramBindingSource
            // 
            this.sysPramBindingSource.DataMember = "SysPram";
            this.sysPramBindingSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sysPramTableAdapter
            // 
            this.sysPramTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xiugai,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(619, 27);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // xiugai
            // 
            this.xiugai.Image = ((System.Drawing.Image)(resources.GetObject("xiugai.Image")));
            this.xiugai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xiugai.Name = "xiugai";
            this.xiugai.Size = new System.Drawing.Size(59, 24);
            this.xiugai.Text = "编辑";
            this.xiugai.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(59, 24);
            this.toolStripButton2.Text = "保存";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // FrmSyspram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 385);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.sysgrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSyspram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统变量";
            this.Load += new System.EventHandler(this.FrmSyspram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysPramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView sysgrid;
        private Liweijia.Meta.myDataSet myDataSet;
        private System.Windows.Forms.BindingSource sysPramBindingSource;
        private Liweijia.Meta.myDataSetTableAdapters.SysPramTableAdapter sysPramTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn knameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton xiugai;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}