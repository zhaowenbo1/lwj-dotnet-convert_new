using System;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public partial class FrmSyspram : Form
    {
        public FrmSyspram()
        {
            InitializeComponent();
        }

        private void FrmSyspram_Load(object sender, EventArgs e)
        {
            this.sysPramTableAdapter.Fill(this.myDataSet.SysPram);
            xiugai.Text = "编辑";
            sysgrid.ReadOnly = true;
            this.sysgrid.AllowUserToAddRows = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            xiugai.Text = "正在编辑...";
            sysgrid.ReadOnly = false;
            this.sysgrid.AllowUserToAddRows = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            sysgrid.EndEdit();
            this.sysPramBindingSource.EndEdit();
            if (this.myDataSet.GetChanges() == null)
            {
                return;
            }
            this.sysPramTableAdapter.Update(this.myDataSet);
            this.myDataSet.AcceptChanges();
            this.sysPramTableAdapter.Fill(this.myDataSet.SysPram);
            this.sysgrid.ReadOnly = true;
            this.sysgrid.AllowUserToAddRows = false;
            xiugai.Text = "编辑";
            MessageBox.Show("保存成功！", "提示！！！",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
