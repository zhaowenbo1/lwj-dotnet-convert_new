namespace FurniturefFOB
{
    partial class FrmBoardManger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBoardManger));
            this.boardgrid = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardFXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.holeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoleFx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new FurniturefFOB.Liweijia.Meta.myDataSet();
            this.dgvpram = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.boardaddbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.boardInfoTableAdapter = new FurniturefFOB.Liweijia.Meta.myDataSetTableAdapters.BoardInfoTableAdapter();
            this.parametersTableAdapter = new FurniturefFOB.Liweijia.Meta.myDataSetTableAdapters.ParamssTableAdapter();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardInfoparametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.boardgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoparametersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // boardgrid
            // 
            this.boardgrid.AllowUserToAddRows = false;
            this.boardgrid.AllowUserToResizeRows = false;
            this.boardgrid.AutoGenerateColumns = false;
            this.boardgrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.boardgrid.ColumnHeadersHeight = 25;
            this.boardgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.boardgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.cnameDataGridViewTextBoxColumn,
            this.boardFXDataGridViewTextBoxColumn,
            this.holeDataGridViewCheckBoxColumn,
            this.Level,
            this.HoleFx});
            this.boardgrid.DataSource = this.boardInfoBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.boardgrid.DefaultCellStyle = dataGridViewCellStyle10;
            this.boardgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.boardgrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.boardgrid.Location = new System.Drawing.Point(0, 27);
            this.boardgrid.Name = "boardgrid";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.boardgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.boardgrid.RowHeadersWidth = 20;
            this.boardgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.boardgrid.RowTemplate.Height = 24;
            this.boardgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.boardgrid.Size = new System.Drawing.Size(670, 262);
            this.boardgrid.TabIndex = 3;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 40;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "板件编码";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.Width = 150;
            // 
            // cnameDataGridViewTextBoxColumn
            // 
            this.cnameDataGridViewTextBoxColumn.DataPropertyName = "Cname";
            this.cnameDataGridViewTextBoxColumn.HeaderText = "板件名称";
            this.cnameDataGridViewTextBoxColumn.Name = "cnameDataGridViewTextBoxColumn";
            this.cnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // boardFXDataGridViewTextBoxColumn
            // 
            this.boardFXDataGridViewTextBoxColumn.DataPropertyName = "BoardFX";
            this.boardFXDataGridViewTextBoxColumn.HeaderText = "板件方向";
            this.boardFXDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "横向",
            "竖向",
            " "});
            this.boardFXDataGridViewTextBoxColumn.Name = "boardFXDataGridViewTextBoxColumn";
            this.boardFXDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.boardFXDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // holeDataGridViewCheckBoxColumn
            // 
            this.holeDataGridViewCheckBoxColumn.DataPropertyName = "Hole";
            this.holeDataGridViewCheckBoxColumn.HeaderText = "判断孔位";
            this.holeDataGridViewCheckBoxColumn.Name = "holeDataGridViewCheckBoxColumn";
            // 
            // Level
            // 
            this.Level.DataPropertyName = "LevelSeq";
            this.Level.HeaderText = "进板优先级";
            this.Level.Name = "Level";
            // 
            // HoleFx
            // 
            this.HoleFx.DataPropertyName = "HoleFx";
            this.HoleFx.HeaderText = "最小成孔缝隙";
            this.HoleFx.Name = "HoleFx";
            // 
            // boardInfoBindingSource
            // 
            this.boardInfoBindingSource.DataMember = "BoardInfo";
            this.boardInfoBindingSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvpram
            // 
            this.dgvpram.AllowUserToAddRows = false;
            this.dgvpram.AutoGenerateColumns = false;
            this.dgvpram.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvpram.ColumnHeadersHeight = 25;
            this.dgvpram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvpram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.boardIdDataGridViewTextBoxColumn,
            this.knameDataGridViewTextBoxColumn,
            this.inameDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dgvpram.DataSource = this.boardInfoparametersBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvpram.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvpram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvpram.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvpram.Location = new System.Drawing.Point(0, 0);
            this.dgvpram.Name = "dgvpram";
            this.dgvpram.RowHeadersWidth = 20;
            this.dgvpram.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvpram.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dgvpram.RowTemplate.Height = 24;
            this.dgvpram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpram.Size = new System.Drawing.Size(434, 289);
            this.dgvpram.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 90);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.boardgrid);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvpram);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 289);
            this.splitContainer1.SplitterDistance = 670;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boardaddbtn,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(670, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // boardaddbtn
            // 
            this.boardaddbtn.Image = ((System.Drawing.Image)(resources.GetObject("boardaddbtn.Image")));
            this.boardaddbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boardaddbtn.Name = "boardaddbtn";
            this.boardaddbtn.Size = new System.Drawing.Size(59, 24);
            this.boardaddbtn.Text = "修改";
            this.boardaddbtn.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(59, 24);
            this.toolStripButton3.Text = "撤销";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(115, 24);
            this.toolStripButton4.Text = "批量添加参数";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "板件编号或板件名";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBox1.Location = new System.Drawing.Point(186, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // boardInfoTableAdapter
            // 
            this.boardInfoTableAdapter.ClearBeforeFill = true;
            // 
            // parametersTableAdapter
            // 
            this.parametersTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // boardIdDataGridViewTextBoxColumn
            // 
            this.boardIdDataGridViewTextBoxColumn.DataPropertyName = "BoardId";
            this.boardIdDataGridViewTextBoxColumn.HeaderText = "BoardId";
            this.boardIdDataGridViewTextBoxColumn.Name = "boardIdDataGridViewTextBoxColumn";
            this.boardIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.boardIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // knameDataGridViewTextBoxColumn
            // 
            this.knameDataGridViewTextBoxColumn.DataPropertyName = "Kname";
            this.knameDataGridViewTextBoxColumn.HeaderText = "酷家乐变量";
            this.knameDataGridViewTextBoxColumn.Name = "knameDataGridViewTextBoxColumn";
            this.knameDataGridViewTextBoxColumn.Width = 150;
            // 
            // inameDataGridViewTextBoxColumn
            // 
            this.inameDataGridViewTextBoxColumn.DataPropertyName = "Iname";
            this.inameDataGridViewTextBoxColumn.HeaderText = "IMOS变量";
            this.inameDataGridViewTextBoxColumn.Name = "inameDataGridViewTextBoxColumn";
            this.inameDataGridViewTextBoxColumn.Width = 150;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.Width = 300;
            // 
            // boardInfoparametersBindingSource
            // 
            this.boardInfoparametersBindingSource.DataMember = "BoardInfoparameters";
            this.boardInfoparametersBindingSource.DataSource = this.boardInfoBindingSource;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.richTextBox1.Location = new System.Drawing.Point(561, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(551, 82);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // FrmBoardManger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 382);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBoardManger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBoardManger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boardgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpram)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardInfoparametersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView boardgrid;
        private System.Windows.Forms.DataGridView dgvpram;
        private Liweijia.Meta.myDataSet myDataSet;
        private System.Windows.Forms.BindingSource boardInfoBindingSource;
        private Liweijia.Meta.myDataSetTableAdapters.BoardInfoTableAdapter boardInfoTableAdapter;
        private System.Windows.Forms.BindingSource boardInfoparametersBindingSource;
        private Liweijia.Meta.myDataSetTableAdapters.ParamssTableAdapter parametersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn boardFXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn holeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoleFx;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn knameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton boardaddbtn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}